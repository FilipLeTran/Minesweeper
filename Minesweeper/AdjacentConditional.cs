namespace Minesweeper;

class AdjacentConditional : Adjacent
{
    public bool IsOutsideField(int x, int y, int xFieldLength, int yFieldLength)
    {
        return 0 > x || x >= xFieldLength || 
               0 > y || y >= yFieldLength;
    }
}