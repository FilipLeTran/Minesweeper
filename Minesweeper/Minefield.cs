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
}
