namespace Minesweeper
{
    using System;

    public class MinesweeperGame
    {
        public static void Main()
        {
            Minefield field = new();

            int xBoardLength = field.GetBombs().GetLength(0);
            int yBoardLength = field.GetBombs().GetLength(1);

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

            MineView fieldView = new(field); 
            while(field.IsUnexplored())
            {
                string userInput = Console.ReadLine();
                
                int[]? coordinates = ParseCoordinates(userInput);
                if (coordinates != null) // if valid input
                {
                    int x = coordinates[0];
                    int y = coordinates[1];
                    if (field.IsOutsideField(x, y, xBoardLength, yBoardLength)) // if outside minefield
                    {
                        fieldView.CorrectInputRange();
                    }
                    else // if inside minefield
                    {
                        int[,]? updatedMinefield = field.RevealCells(x, y);
                        if (updatedMinefield != null) // if not a mine
                        {
                            fieldView.UpdateBoard(updatedMinefield);
                        }
                        else // if mine
                        {
                            fieldView.MineExploded();
                            System.Environment.Exit(1);
                        }
                    }
                }
                else // if invalid input
                {
                    fieldView.CorrectInputFormat();
                }
            }
            fieldView.GameCleared();
        }

        public static int[] ParseCoordinates(string userInput)
        {
            if (userInput.Length != 0 && userInput.Length == 3)
            {
                string[] input = userInput.Split(' ');
                return new int[2] {Int32.Parse(input[0]), Int32.Parse(input[1])};
            }
            else
            {
                return null;
            }
        }
    }
}
