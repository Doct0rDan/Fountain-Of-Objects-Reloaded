using System.Globalization;
using System.Numerics;

public class Player
{
    public int Row { get; private set; }
    public int Column { get; private set; }
    public Vector2 Position => new Vector2(Row,Column);
    public IPlayerAction? PlayerAction { get; protected set; }
    public string Label { get; set; } = ">x<";

    public Player(int row, int column)
    {
        SetPosition(row, column);

        Console.WriteLine("Player created at:" + Position);
    }

    public void SetPosition(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public void DeltaPosition(int dRow, int dColumn)
    {
        Row += dRow;
        Column += dColumn;
    }


    public void MakePlayerDoPlayerAction(string action, WorldGrid worldGrid)
    {
        IPlayerAction pAction = action switch
            {
                "move north" => new MoveNorth(),
                "move south" => new MoveSouth(),
                "move east" => new MoveEast(),
                "move west" => new MoveWest(),
                "interact" => new InteractWithRoom(),
                "help" => new Help(),
                _ => new Idle()
            };

            pAction.PlayerAction(this, worldGrid);    
    }

    public void InteractWithRoom(WorldGrid worldGrid)
    {
        worldGrid?.OccupiedRoom?.OnInteract();
    }

    public void AskAndDoPlayer(WorldGrid worldGrid)
    {
        Console.WriteLine("What do you want to do? (move north, move east, move south, move west or interact)");
        string? action = Console.ReadLine()?.ToLower();
        MakePlayerDoPlayerAction(action, worldGrid);
    }

    public bool IsMoveValid(WorldGrid worldGrid, IPlayerAction move)
    {
        if(Row == worldGrid.Rows -1 && move is MoveSouth)
        {
            Console.WriteLine("INVALID MOVE");
            return false;
        }
        else if (Row == 0 && move is MoveNorth)
        {
            Console.WriteLine("INVALID MOVE");
            return false;
        }
        else if(Column == worldGrid.Columns -1 && move is MoveEast)
        {
            Console.WriteLine("INVALID MOVE");
            return false;
        }

        else if(Column == 0 && move is MoveWest)
        {
            Console.WriteLine("INVALID MOVE");
            return false;
        }
        else 
        {
            return true;
        }
    }
}