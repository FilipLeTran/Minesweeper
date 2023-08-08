namespace Minesweeper;
using System;

class Minefield
{
    private const int xLength = 5;
    private const int yLength = 5;

    private bool[,] _bombLocations = new bool[xLength, yLength];

    public void SetBomb(int x, int y)
    {
        _bombLocations[x, y] = true;
    }

    public int[] getSize()
    {
        int[] dimensions = new int[2];
        for(int i = 0; i < 2; i++) 
        {
            dimensions[i] = _bombLocations.GetLength(i);
        }
        return dimensions;
    }

    public int[] revealSquares(string guess)
    {
        int[] coordinates = parseCoordinates(guess);
        if(isMine(coordinates[0], coordinates[1])) // dead 
        {
            return null;
        } 
        else // not dead, reveal surrounding ???
        {
            return revealAdjacentSquares(coordinates[0], coordinates[1]);
        }  
    } 

    private int[] revealAdjacentSquares(int xCord, int yCord)
    {
        int[] adjacentSquares = new int[9];
        int index = 0;
        for(int x = xCord-1; x < x+2; x++)
        {
            for(int y = yCord+1; y > y-2; y--)
            {
                adjacentSquares[index] = getNeighbours(x, y);
                index++;
            }
        }
        
        //      2 1
        // 1 2, 2 2, 3 2
        // 1 1, o G, 3 1
        // 1 0, 2 0, 3 0

        return adjacentSquares;
    }

    private int getNeighbours(int xCord, int yCord)
    {
        int counter = 0;
        for(int x = xCord-1; x < x+2; x++)
        {
            for(int y = yCord+1; y > y-2; y--)
            {
                if(x < 0 || x > xLength || y < 0 || y > yLength) continue;
                if(isMine(x, y)) counter++;
            }
        }
        return counter;
    }

    private int[] parseCoordinates(string guess)
    {
        if(guess.Length != 3) 
        {
            throw new InvalidOperationException("Please type the in the following format: 'x y'");
        } 
        else 
        {
            string[] coordinates = guess.Split(' ');
            return new int[2] {stringToInt(coordinates[0]), stringToInt(coordinates[1])};
        }
    }

    private int stringToInt(string str) 
    {
        return Int32.Parse(str);
    }

    private bool isMine(int x, int y)
    {
        return _bombLocations[x, y];
    }
}
