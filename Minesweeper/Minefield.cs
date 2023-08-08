namespace Minesweeper;
using System;

class Minefield
{
    private bool[,] _bombLocations = new bool[5, 5];

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

    public bool revealSquares(string guess)
    {
        
        int[] coordinates = parseCoordinates(guess);

        if(isMine(coordinates)) // dead 
        {
            return false;
        } 
        else // not dead, reveal surrounding ???
        {
            
        }



        return false;
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

    private bool isMine(int[] coordinates)
    {
        return _bombLocations[coordinates[0], coordinates[1]];
    }


    
}
