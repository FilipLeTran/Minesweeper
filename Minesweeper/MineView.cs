namespace Minesweeper;

class MineView
{

    public Minefield field;

    public MineView(Minefield field) 
    {
        this.field = field;
        printField();
    }

    public void printField()
    {
        Console.Write(" ");
        int[] fieldSize = field.getSize();
        for(int i = 0; i < fieldSize[0]; i++) {
            Console.Write(i);
        }

    }
}