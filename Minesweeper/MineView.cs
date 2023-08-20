namespace Minesweeper;
using System.Text;

class MineView
{

    public Minefield field;
    private string[,] minefield;
    private int xFieldLength, yFieldLength;

    public MineView(Minefield field)
    {
        this.field = field;
        xFieldLength = field.GetBombs().GetLength(0);
        yFieldLength = field.GetBombs().GetLength(1);
        this.minefield = CreateDefaultUnknownField();
        PrintInitialField();
    }

    public void PrintInitialField()
    {
        PrintX(this.field);
        PrintY(this.field);
    }

    public void UpdateBoard(int[,] squares)
    {
        PrintX(this.field);
        for (int y = yFieldLength - 1; y >= 0; y--)
        {
            for (int x = 0; x < xFieldLength; x++)
            {
                int square = squares[x, y];
                if(square != 0) // if square has been "explored"
                {
                    if (square == -1) // if mine
                    {
                        SetMinefieldView(x, y, "X");
                        continue;
                    }
                    else if (square == 10) // if empty
                    {
                        SetMinefieldView(x, y, " ");
                        continue;
                    }
                    else // if tile has value
                    {
                        SetMinefieldView(x, y, square.ToString());
                    }
                }
            }
        }
        PrintY(this.field);
    }

    public void GameCleared() { Console.WriteLine("Victory! You completed the game :)"); }

    public void MineExploded()
    {
        Console.WriteLine("You lost! Mine exploded!");
        System.Environment.Exit(1);
    }
          
    public void CorrectInputFormat() { Console.WriteLine("Please type the in the following format: 'x y'"); }

    public void CorrectInputRange() { 
        Console.WriteLine("Please type the values within the ranges of: 0-" + (xFieldLength-1) + " for the x value and 0-" + (yFieldLength-1) + " for the y value");
    }

    private void PrintX(Minefield field)
    {
        Console.Write("  ");
        for (int i = 0; i < xFieldLength; i++)
        {
            Console.Write(i);
        }
        Console.Write("\n");
    }

    private void PrintY(Minefield field)
    {
        for (int y = yFieldLength - 1; y >= 0; y--)
        {
            Console.Write(y + "|");
            for (int x = 0; x < xFieldLength; x++)
            {
                Console.Write(minefield[x, y]);
            }
            Console.Write("\n");
        }
        Console.WriteLine("-------------");
    }

    private void SetMinefieldView(int x, int y, string value) { minefield[x, y] = value; }

    private string[,] CreateDefaultUnknownField()
    {
        string[,] initialField = new string[xFieldLength, yFieldLength];
        for (int i = 0; i < xFieldLength; i++)
        {
            for (int k = 0; k < yFieldLength; k++)
            {
                initialField[i, k] = "?";
            }
        }
        return initialField;
    }
}