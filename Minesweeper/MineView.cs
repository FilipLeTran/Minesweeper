namespace Minesweeper;
using System.Text;

class MineView
{

    public Minefield field;

    public MineView(Minefield field) 
    {
        this.field = field;
        printInitialField();
    }

    public void printInitialField()
    {
        Console.WriteLine(printXField(this.field));
        Console.WriteLine(printYField(this.field));
    }

    private StringBuilder printXField(Minefield field) 
    {
        StringBuilder sb = new StringBuilder(" ", 50);
        for(int i = 0; i < field.getSize()[0]; i++) 
        {
            sb.Append(i);
        }
        return sb;
    }

    private StringBuilder printYField(Minefield field) 
    {
        StringBuilder sb = new StringBuilder("", 50);
        for(int i = field.getSize()[1]-1; i >= 0; i--)
        {
            sb.Append(i);
            for(int k = 0; k < field.getSize()[0]; k++)
            {
                sb.Append("*");
            }
            sb.Append("\n");
        }
        return sb;
    }
}