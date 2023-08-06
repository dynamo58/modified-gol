using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.IO;
using Newtonsoft.Json;

namespace modified_gol
{
    class Cell
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


    internal class Simulation
    {
        public int boardSize;
        public Cell[,] cells;
        public int speed;
        public int randomizationFactor;
        public int generationCount;

        public Simulation(int size, int speed, int randomizationFactor)
        {
            this.speed = speed;
            this.generationCount = 0;
            this.boardSize = size;
            this.randomizationFactor = randomizationFactor;

            this.cells = new Cell[size, size];
            this.Clean();
        }

        // will resize the cell array board according to the new size
        public void Resize(int newSize)
        {
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
        private int getHealthyNeighborCount(int x, int y)
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
                if (this.cells[neighX, neighY].occupier != null && this.cells[neighX, neighY].occupier.kind != Organism.Kind.AggresiveSick)
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
                    if (this.cells[i,j].occupier != null && this.cells[i, j].occupier.kind == Organism.Kind.AggresiveSick)
                        foreach ((int x, int y) in UnagressiveNeighbors(i, j))
                        {
                            Utils.Debug($"{i} {j} eatable neighbor at {x} {y}");
                            this.cells[x, y].occupier = null;
                            (this.cells[i, j].occupier as AggresiveSickOrganism).currentHungerStrike = 0;
                        }

            // ...then the others
            for (int i = 0; i < this.boardSize; i++)
                for (int j = 0; j < this.boardSize; j++)
                {
                    int count = this.getHealthyNeighborCount(i, j);

                    if (this.cells[i, j].occupier == null)
                        newBoard[i, j] = new Cell(Organism.DecideEmptyCellNextState(count));
                    else
                        newBoard[i, j] = new Cell(this.cells[i, j].occupier.DecideNextState(count));
                }

            this.generationCount += 1;
            this.cells = newBoard;
        }

        public void RandomizeCells()
        {
            for (int i = 0; i < this.boardSize; i++)
                for (int j = 0; j < this.boardSize; j++)
                    this.cells[i, j].occupier = (Program._rand.Next(0, 101) < this.randomizationFactor) ? new HealthyOrganism() : null;
        }

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
