namespace Minesweeper;

class AdjacentCalculator : AdjacentConditional
{
    private int x, y;
    private bool[,] minefield;
    private int xFieldLength, yFieldLength;

    public AdjacentCalculator(int x, int y, bool[,] minefield)
    {

        this.x = x;
        this.y = y;
        this.minefield = minefield;
        this.xFieldLength = this.minefield.GetLength(0);
        this.yFieldLength = this.minefield.GetLength(1);
    }

    public int TotalAdjacentMines()
    {
        int counter = 0;
        for(int x = this.x-1; x <= this.x+1; x++)
        {
            for(int y = this.y-1; y <= this.y+1; y++)
            {
                if(IsOutsideField(x, y, xFieldLength, yFieldLength)) continue;
                if(this.minefield[x, y] == true) counter++;
            }
        }
        if(counter == 0) counter = 10;
        return counter;
    }

    // public bool IsOutsideField(int x, int y)
    // {
    //     return 0 > x || x >= xFieldLength || 
    //            0 > y || y >= yFieldLength;
    // }
}