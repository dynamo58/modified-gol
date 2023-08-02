using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
        public int generationCount;
        public int speed;
        // as is visible further below, we first need to iterage over the
        // aggresive ones; let them do their thing and only then iterate over
        // the rest
        public List<(int, int)> aggresiveOrganismPositions;

        private Random _rand;

        public Simulation(int size, int speed)
        {
            this.speed = speed;
            this.generationCount = 0;
            this.boardSize = size;
            this.aggresiveOrganismPositions = new List<(int, int)>();

            this.cells = new Cell[size, size];
            this.Clean();

            this._rand = new Random();
        }

        // will resize the cell array board according to the new size
        public void Resize(int newSize)
        {
            // do not proceed if no change to the size was made
            if (newSize == this.boardSize) return;

            // allocate a new array
            Cell[,] newCells = new Cell[newSize, newSize];

            // port over the old cells that fit
            for (int i = 0; i < Math.Min(newSize, this.boardSize); i++)
                for (int j = 0; i < Math.Min(newSize, this.boardSize); j++)
                    newCells[i, j] = cells[i, j];

            // if the new size is bigger, fill remaining space with empty cells
            if (newSize > this.boardSize)
                for (int i = this.boardSize; i < newSize; i++)
                    for (int j = this.boardSize; j < newSize; j++)
                        newCells[i, j] = new Cell();

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
        private System.Collections.Generic.IEnumerable<(int, int)> UnagressiveNeighbors(int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                (int neighX, int neighY) = (x + relativPoss[i].Item1, y + relativPoss[i].Item2);
                if (this.cells[neighX, neighY].occupier != null && this.cells[neighX, neighY].occupier.kind != Organism.Kind.AggresiveSick)
                    yield return (neighX, neighY);
            }
        }

        // calculate the next state of the board
        public void AdvanceGeneration()
        {
            Cell[,] newBoard = new Cell[this.boardSize, this.boardSize];

            for (int i = 0; i < this.boardSize; i++)
                for (int j = 0; j < this.boardSize; j++)
                {
                    int count = this.getHealthyNeighborCount(i, j);
                    

                    // ================= AggresiveSick cell =================
                    if (this.cells[i, j].occupier != null &&
                        this.cells[i, j].occupier.kind == Organism.Kind.AggresiveSick)
                    {
                        AggresiveSickOrganism org = (this.cells[i, j].occupier as AggresiveSickOrganism);
                        org.currentHungerStrike += 1;

                        // eat all surrounding unaggressive neighbors
                        foreach ((int x, int y) in UnagressiveNeighbors(i, j))
                        {
                            this.cells[x, y] = newBoard[x, y] = new Cell();

                            org.currentHungerStrike = 0;
                        }

                        // if the org. hasn't eaten in a while, it shall die
                        if (org.currentHungerStrike == AggresiveSickOrganism.hungerStrikeThreshold)
                            newBoard[i, j].occupier = this.cells[i, j].occupier = null;
                        else
                            newBoard[i, j] = new Cell(org);

                        continue;
                    }

                    // ================= Healthy cell =================
                    if (this.cells[i, j].occupier != null &&
                        this.cells[i, j].occupier.kind == Organism.Kind.Healthy)
                    {
                        if (HealthyOrganism.surviveConds.Contains(count))
                        {
                            newBoard[i, j] = this.cells[i, j];
                            Utils.Debug($"[{i}, {j}] healthy with {count} neighbors -> healthy");
                        }
                        else
                        {
                            newBoard[i, j] = new Cell();
                            Utils.Debug($"[{i}, {j}] healthy with {count} neighbors -> empty");
                        }

                        continue;
                    }

                    // ================= Infected cell =================
                    if (this.cells[i, j].occupier != null &&
                    this.cells[i, j].occupier.kind == Organism.Kind.Infected)
                    {
                        InfectedOrganism org = (this.cells[i, j].occupier as InfectedOrganism);
                        org.currentDaysIncubating += 1;

                        if (org.currentDaysIncubating == InfectedOrganism.incubationPeriod)
                        {
                            bool newIsAggresive = this._rand.Next(1, 101) < InfectedOrganism.chanceOfInfectectionCausingAggretion;

                            Organism newOrg = (newIsAggresive) ? (new AggresiveSickOrganism() as Organism) : (new PeacefulSickOrganism() as Organism);

                            newBoard[i, j] = new Cell(newOrg);
                        }
                        else
                            newBoard[i, j] = new Cell(org);

                        continue;
                    }


                    // ================= PeacefulSick cell =================
                    if (this.cells[i, j].occupier != null &&
                        this.cells[i, j].occupier.kind == Organism.Kind.PeacefulSick)
                    {
                        PeacefulSickOrganism org = (this.cells[i, j].occupier as PeacefulSickOrganism);

                        org.currentNumberOfGenerationsSick += 1;

                        if (org.currentNumberOfGenerationsSick == PeacefulSickOrganism.generationsUntilRecoveryOrDeath)
                        {
                            // play god
                            bool keepAlive = this._rand.Next(1, 101) < PeacefulSickOrganism.chanceOfRecovery;

                            // the org. has healed!
                            if (keepAlive)
                                newBoard[i, j] = this.cells[i, j] = new Cell(new HealthyOrganism());
                            else // time to kill
                                newBoard[i, j] = this.cells[i, j] = new Cell();
                        }

                        newBoard[i, j] = this.cells[i, j] = new Cell(org);

                        continue;
                    }

                    // ================= EMPTY CELL =================
                    if (this.cells[i, j].occupier == null)
                    {
                        if (Organism.newCellBeBornConds.Contains(count))
                        {
                            newBoard[i, j] = new Cell(new HealthyOrganism());
                            Utils.Debug($"[{i}, {j}] empty with {count} neighbors -> healthy");
                        }
                        else
                        {
                            newBoard[i, j] = new Cell();
                            Utils.Debug($"[{i}, {j}] empty with {count} neighbors -> empty");

                        }

                        continue;
                    }

                }

            this.generationCount += 1;
            this.cells = newBoard;
        }
    }
}
