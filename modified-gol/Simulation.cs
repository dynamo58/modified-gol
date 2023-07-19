using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modified_gol
{
    class Cell
    {
        public Organism? occupier;
    }

    internal class Simulation
    {
        public int boardSize;
        public Cell[,] cells;
        public int generationCount;
        public int speed;

        public Simulation(int size, int speed)
        {
            this.speed = speed;
            this.generationCount = 0;
            this.boardSize = size;

            this.cells = new Cell[size, size];
            this.Clean();
        }

        public void NextGeneration()
        {
        }

        // will resize the cell array board according to the new size
        public void Resize(int newSize)
        {
            // do not proceed if no change to the size was made
            if (newSize == this.boardSize) return;
            
            // allocate a new array
            Cell[,] newCells = new Cell[newSize,newSize];

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

        public void Test()
        {
            Console.WriteLine("xd");
        }
    }
}
