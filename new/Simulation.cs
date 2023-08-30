using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace modified_gol
{
    // represents a singular atomic unit in the cells panel
    public class Cell
    {
        public Organism occupier;
        
        public Cell()
        {
            this.occupier = null;
        }

        public Cell(Organism org)
        {
            this.occupier = org;
        }
    }

    // the brain of the simulation
    // also holds all of the dynamic data that is serialized/deserialized when using an external save of the state
    public class Simulation
    {
        // denotes how big the cells panel is (boardSize x boardSize)
        public int boardSize;
        public Cell[,] cells;
        // when the simulation is being played automatically, how many generations a second are to be generated
        public int speed = 4;
        // when the cell randomization button is pressed, whats the chance of each cell to turn int a healthy org.
        public int randomizationFactor = 35;
        // current number of generations since last edit
        public int generationCount = 0;
        // possible amounts of neighbors for an empty cell to become a new org.
        [JsonProperty]
        public static bool[] newCellBeBornConds = new bool[9] {
            false, false, true, false, false, false, false, false, false
        };
        // possible amounts of neighbors for a healthy cell to survive
        [JsonProperty]
        public static bool[] surviveConds = new bool[9] {
            false, true, true, false, false, false, false, false, false
        };
        // how long it takes an infected cell to heal/aggressify
        [JsonProperty]
        public static int incubationPeriod = 3;
        // chance that an infected org. heals at the end of its incubation period
        [JsonProperty]
        public static int chanceOfInfectedHealing = 30;
        // chance that a healthy cell will randomly get infected during a single generation
        [JsonProperty]
        public static int sporadicInfectionChance = 0;
        // how many generations it takes an aggressive cell to die without food
        [JsonProperty]
        public static int hungerStrikeThreshold = 5;


        public Simulation(int size, int speed, int randomizationFactor)
        {
            this.speed = speed;
            this.boardSize = size;
            this.randomizationFactor = randomizationFactor;

            this.cells = new Cell[size, size];
            this.Clean();
        }

        // will resize the cell array board according to the new size
        public void Resize(int newSize)
        {
            this.HandleUserAction();

            // do not proceed if no change to the size was made
            if (newSize == this.boardSize) return;

            // allocate a new array
            Cell[,] newCells = new Cell[newSize, newSize];

            // port over the old cells that finewSizet {this.boardSize}
            for (int i = 0; i < Math.Min(newSize, this.boardSize); i++)
                for (int j = 0; j < Math.Min(newSize, this.boardSize); j++)
                    newCells[i, j] = cells[i, j];

            // if the new size is bigger, fill remaining space with empty cells
            if (newSize > this.boardSize)
            {
                // right + right-down
                for (int i = 0; i < newSize; i++)
                    for (int j = this.boardSize; j < newSize; j++)
                        newCells[i, j] = new Cell();

                // down
                for (int i = this.boardSize; i < newSize; i++)
                    for (int j = 0; j < this.boardSize; j++)
                        newCells[i, j] = new Cell();
            }

            // change the state
            this.cells = newCells;
            this.boardSize = newSize;

        }

        // wipes the whole board clean
        public void Clean()
        {
            this.HandleUserAction();
            for (int i = 0; i < this.boardSize; i++)
                for (int j = 0; j < this.boardSize; j++)
                    this.cells[i, j] = new Cell();
        }

        private readonly (int, int)[] relativPoss = new (int, int)[] {
            (-1, -1), (-1, 0), (-1, 1),
            ( 0, -1),          (0, 1),
            ( 1, -1), ( 1, 0), (1, 1)
        };
        // helper function for calculating number of healthy neighbors of a cell
        private int GetHealthyNeighborCount(int x, int y)
        {
            int count = 0;

            for (int i = 0; i <= 7; i++)
            {
                (int neighX, int neighY) = (x + relativPoss[i].Item1, y + relativPoss[i].Item2);
                if (!Utils.IsWithinBounds((neighX, neighY), 0, this.boardSize - 1)) continue;
                
                if (this.cells[neighX, neighY].occupier != null && this.cells[neighX, neighY].occupier.kind == Organism.Kind.Healthy)
                    count++;
            }

            return count;
        }
        // snitch out the positions of all neighbors that arent aggresive
        private IEnumerable<(int, int)> UnagressiveNeighbors(int x, int y)
        {
            for (int i = 0; i <= 7; i++)
            {
                (int neighX, int neighY) = (x + relativPoss[i].Item1, y + relativPoss[i].Item2);
                if (!Utils.IsWithinBounds((neighX, neighY), 0, this.boardSize - 1)) continue;
                if (this.cells[neighX, neighY].occupier != null && this.cells[neighX, neighY].occupier.kind != Organism.Kind.Aggressive)
                    yield return (neighX, neighY);
            }
        }

        // calculate the next state of the board
        public void AdvanceGeneration()
        {
            Cell[,] newBoard = new Cell[this.boardSize, this.boardSize];

            // firstly take care of all the aggressive cells
            for (int i = 0; i < this.boardSize; i++)
                for (int j = 0; j < this.boardSize; j++)
                    if (this.cells[i,j].occupier != null && this.cells[i, j].occupier.kind == Organism.Kind.Aggressive)
                        foreach ((int x, int y) in UnagressiveNeighbors(i, j))
                        {
                            this.cells[x, y].occupier = null;
                            (this.cells[i, j].occupier as AggressiveOrganism).currentHungerStrike = 0;
                        }

            // ...then the others
            for (int i = 0; i < this.boardSize; i++)
                for (int j = 0; j < this.boardSize; j++)
                {
                    int count = this.GetHealthyNeighborCount(i, j);

                    if (this.cells[i, j].occupier == null)
                        newBoard[i, j] = new Cell(Organism.DecideEmptyCellNextState(count));
                    else
                        newBoard[i, j] = new Cell(this.cells[i, j].occupier.DecideNextState(count));
                }

            this.generationCount += 1;
            this.cells = newBoard;
        }

        public Brush ChangeCellState((int x, int y) coords, string orgStr)
        {

            if (coords.x >= this.boardSize || coords.y >= this.boardSize)
                return null;

            this.HandleUserAction();

            if (this.cells[coords.x, coords.y].occupier != null)
            {
                this.cells[coords.x, coords.y].occupier = null;
                return null;
            }
            else
            {
                Organism newCell = Organism.FromStr(orgStr);

                this.cells[coords.x, coords.y].occupier = newCell;
                return newCell.GetBrush();
            }
        }

        public void RandomizeCells()
        {
            this.HandleUserAction();

            for (int i = 0; i < this.boardSize; i++)
                for (int j = 0; j < this.boardSize; j++)
                    this.cells[i, j].occupier = (Program._rand.Next(0, 101) < this.randomizationFactor) ? new HealthyOrganism() : null;
        }

        public void HandleUserAction()
        {
            this.generationCount = 0;
        }

        // -----------------------------
        // JSON serialization and deserialization functions
        // -----------------------------
        
        public string ToJSON() =>
           JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

        public static Simulation DeserializeFromFile(string path) =>
            JsonConvert.DeserializeObject<Simulation>(File.ReadAllText(path), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
    }
}
