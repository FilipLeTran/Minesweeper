namespace Minesweeper;

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
        while(field.Unexplored())
        {
            string userInput = Console.ReadLine();
            if(userInput.Length != 3)
            {
                Console.WriteLine("Please type the in the following format: 'x y'");
            } 
            else 
            {
                int[,] grid = field.RevealSquares(userInput);
                if(grid != null)  
                {
                    fieldView.UpdateBoard(grid);
                }
                else 
                {
                    Console.WriteLine("You lost! Mine exploded!");
                    System.Environment.Exit(1);
                }
            }
        }
        Console.WriteLine("Victory! You completed the game :)");

        // Game code...
        // run by typign dotnet run --project D:\Skolan\minesweeper\Minesweeper\Minesweeper.csproj
    }
}
