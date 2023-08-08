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

    public void updateBoard(int[] squares, int[] coordinates)
    {
        Console.WriteLine(printXField(this.field));
        StringBuilder sb = new StringBuilder("", 50);
        int[] coords = coordinates;
        int index = 0;
        for(int i = field.getSize()[1]-1; i >= 0; i--)
        {
            sb.Append(i);
            for(int k = 0; k < field.getSize()[0]; k++)
            {
                if(coords[0] == i && coords[1] == k)
                {
                    if(squares[index] == -1) sb.Append("x");
                    sb.Append(squares[index].ToString());
                    index++;
                }
                else
                {
                    sb.Append("?");
                }
            }
            sb.Append("\n");
        }
        sb.Append("\n");
        Console.Write(sb);
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
                sb.Append("?");
            }
            sb.Append("\n");
        }
        return sb;
    }
}