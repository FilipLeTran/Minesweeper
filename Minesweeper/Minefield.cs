namespace Minesweeper;

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
        if(guess.GetLength != 3) 
        {
            throw new InvalidOperationException("Please type the in the following format: 'x y'");
        } 
        else 
        {
            string[] guessValue = guess.Split(' ');
            bool isMine = _bombLocations[guessValue[0], guessValue[1]];
        }

    } 
}
