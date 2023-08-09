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
        for(int x = xCord-1; x < xCord+2; x++)
        {
            for(int y = yCord+1; y > yCord-2; y--)
            {
                if(isMine(x, y))
                {
                    adjacentSquares[index] = -1;    
                }
                else 
                {
                    adjacentSquares[index] = getNeighbours(x, y);
                    index++;
                }
            }
        }
        return adjacentSquares;
    }

    private int getNeighbours(int xCord, int yCord)
    {
        int counter = 0;
        for(int x = xCord-1; x < xCord+2; x++)
        {
            for(int y = yCord+1; y > yCord-2; y--)
            {
                if(isOutsideField(x, y)) continue;
                // Console.Write(x);
                // Console.Write(y);
                // Console.Write("\n");
                if(isMine(x, y)) counter++;
            }
        }
        return counter;
    }

    public int[] parseCoordinates(string guess)
    {
        string[] coordinates = guess.Split(' ');
        return new int[2] {stringToInt(coordinates[0]), stringToInt(coordinates[1])};
    }
    private int stringToInt(string str) 

    {
        return Int32.Parse(str);
    }

    private bool isOutsideField(int x, int y)
    {
        return x < 0 || y < 0 || x >= xLength || y >= yLength;
    }

    private bool isMine(int x, int y)
    {
        return checkMineLocation(x, y);
    }

    private bool checkMineLocation(int x, int y)
    {
        if(isOutsideField(x, y))
        {
            Console.WriteLine("Outside field range!");
            return false;
        } 
        else 
        {
            return _bombLocations[x, y];
        }
    }
}
