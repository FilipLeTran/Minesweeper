namespace Minesweeper;
using System;

class Minefield
{
    private const int xLength = 5;
    private const int yLength = 5;
    private bool[,] visitedSquares = new bool[xLength, yLength];
    private bool[,] _bombLocations = new bool[xLength, yLength];

    public void SetBomb(int x, int y) { _bombLocations[x, y] = true; }

    public bool[,] GetBombs() { return _bombLocations; }

    public int[,] RevealSquares(int x, int y)
    {
        // int[] coordinates = ParseCoordinates(guess);
        if(IsMine(x, y)) // dead 
        {
            return null;
        } 
        else // not dead, reveal surrounding ???
        {
            return RevealAdjacentSquares(x, y);
        }  
    } 

    private int[,] RevealAdjacentSquares(int xCord, int yCord)
    {
        int[,] newGrid = new int[xLength, yLength];
        for(int x = xCord-1; x <= xCord+1; x++)
        {
            for(int y = yCord-1; y <= yCord+1; y++)
            {
                if(IsOutsideField(x, y) || HasVisited(x, y)) continue;
                if(IsMine(x, y))
                {
                    newGrid[x,y] = -1;   
                }
                else 
                {
                    AdjacentCalculator calc = new AdjacentCalculator(x, y, _bombLocations);
                    int totalMines = calc.TotalAdjacentMines();
                    if(totalMines == 10) // if empty
                    {
                        visitedSquares[x, y] = true;
                        RevealAdjacentSquaresAgain(x, y, newGrid);
                    }
                    newGrid[x,y] = totalMines;
                }
                visitedSquares[x, y] = true;
            }
        }
        return newGrid;
    }

    private void RevealAdjacentSquaresAgain(int xCord, int yCord, int[,] previousGrid)
    {
        for(int x = xCord-1; x <= xCord+1; x++)
        {
            for(int y = yCord-1; y <= yCord+1; y++)
            {
                if(IsOutsideField(x, y) || HasVisited(x, y)) continue;
                if(IsMine(x, y))
                {
                    previousGrid[x,y] = -1;    
                }
                else 
                {
                    AdjacentCalculator calc = new AdjacentCalculator(x, y, _bombLocations);
                    int totalMines = calc.TotalAdjacentMines();
                    if(totalMines == 10)
                    {
                        visitedSquares[x, y] = true; //prevent inf loop on empty space
                        RevealAdjacentSquaresAgain(x, y, previousGrid);
                    }
                    previousGrid[x,y] = totalMines;
                }
                visitedSquares[x, y] = true;
            }
        }
    }

    

    public bool IsUnexplored()
    {
        for(int i = 0; i < xLength; i++)
        {
            for(int k = 0; k < yLength; k++)
            {
                if(visitedSquares[i, k] == false)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool IsOutsideField(int x, int y)
    {
        return 0 > x || x >= xLength || 
               0 > y || y >= yLength;
    }
    
    private bool HasVisited(int x, int y) { return visitedSquares[x, y]; }

    private int StringToInt(string str) { return Int32.Parse(str); }

    private bool IsMine(int x, int y) { return _bombLocations[x, y]; }
}
