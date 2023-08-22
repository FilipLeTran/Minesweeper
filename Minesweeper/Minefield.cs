namespace Minesweeper
{
    using System;
    public class Minefield : AdjacentConditional
    {
        private const int xLength = 5;
        private const int yLength = 5;
        private const int MINE_VALUE = -1;
        private const int EMPTY_SPACE_VALUE = 10;
    
        private bool[,] visitedCells = new bool[xLength, yLength];
        private bool[,] bombLocations = new bool[xLength, yLength];

        public void SetBomb(int x, int y) { bombLocations[x, y] = true; }

        public bool[,] GetBombs() { return bombLocations; }

        public int[,]? RevealCells(int x, int y)
        {
            if(IsMine(x, y)) // dead 
            {
                return null;
            } 
            else // not dead, reveal surrounding ????
            {
                int[,] newGrid = new int[xLength, yLength];
                return RevealAdjacentCells(x, y, newGrid);
            }  
        } 

        private int[,] RevealAdjacentCells(int xCord, int yCord, int[,] previousGrid)
        {
        
        
            for(int x = xCord - 1; x <= xCord + 1; x++)
            {
                for(int y = yCord - 1; y <= yCord + 1; y++)
                {
                    if(IsOutsideField(x, y, xLength, yLength) || HasVisited(x, y)) continue;
                    visitedCells[x, y] = true; // prevent inf loop on empty space
                    if(IsMine(x, y))
                    {
                        previousGrid[x, y] = MINE_VALUE; // mines are valued as -1
                    }
                    else 
                    {
                        AdjacentCalculator calc = new AdjacentCalculator(x, y, bombLocations);
                        int totalMines = calc.TotalAdjacentMines();
                        if(totalMines == EMPTY_SPACE_VALUE) // mines valued as 10 are empty spaces i.e. no surrounding mines
                        {
                            RevealAdjacentCells(x, y, previousGrid);
                        }
                        previousGrid[x, y] = totalMines;
                    }
                }
            }
            return previousGrid;
        }

        public bool IsUnexplored()
        {
            for(int i = 0; i < xLength; i++)
            {
                for(int k = 0; k < yLength; k++)
                {
                    if(visitedCells[i, k] == false) { return true; }
                }
            }
            return false;
        }

        private bool HasVisited(int x, int y) { return visitedCells[x, y]; }

        private bool IsMine(int x, int y) { return bombLocations[x, y]; }
    }
}