namespace Minesweeper;
using System;

class Minesweeper
{
    static void Main()
    {
        var field = new Minefield();

        //set the bombs...
        field.SetBomb(0, 0);
        field.SetBomb(0, 1);
        field.SetBomb(1, 1);
        field.SetBomb(1, 4);
        field.SetBomb(4, 2);

        //the mine field should look like this now:
        //  01234
        //4|1X1
        //3|11111
        //2|2211X
        //1|XX111
        //0|X31

        MineView fieldView = new MineView(field); 
        while(field.IsUnexplored())
        {
            string userInput = Console.ReadLine();
            int[] coordinates = ParseCoordinates(userInput);
            int x = coordinates[0];
            int y = coordinates[1];
            if(userInput.Length != 3)
            {
                fieldView.CorrectInputFormat();
            } 
            else if(field.IsOutsideField(x, y, field.GetBombs().GetLength(0), field.GetBombs().GetLength(1)))
            {
                fieldView.CorrectInputRange();
            }
            else 
            {
                int[,] updatedMinefield = field.RevealSquares(x, y);
                if(updatedMinefield != null)  
                {
                    fieldView.UpdateBoard(updatedMinefield);
                }
                else 
                {
                    fieldView.MineExploded();
                }
            }
        }
        fieldView.GameCleared();

        // run by typign dotnet run --project D:\Skolan\minesweeper\Minesweeper\Minesweeper.csproj
    }

    private static int[] ParseCoordinates(string userInput)
    {
        string[] input = userInput.Split(' ');
        return new int[2] {Int32.Parse(input[0]), Int32.Parse(input[1])};
    }
}
