using System.Numerics;

public partial class Room
{
    public int Row { get; private set; } 
    public int Column { get; private set; }
    public Vector2 Position => new(Row,Column);

    public bool Visited { get; private set; }

    public RoomContents RoomContents { get; protected set; }

    public Room(int row, int column, RoomContents roomContents = RoomContents.Empty)
    {
        SetPosition(row,column);
        RoomContents = roomContents;
        Visited = false;
    }
    public void SetPosition(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public void SetRoomContents(RoomContents roomContents)
    {
        RoomContents = roomContents;
    }

    public virtual void OnEnter()
    {

        if(Visited == false)
        {
            Console.WriteLine("ROOM EVENT: ");
            Visited = true;
        }


        if(RoomContents == RoomContents.Empty)
        {
            Console.WriteLine("Nothing is here");
            Visited = true;
        }
    }

    public virtual void OnEnter(Player player)
    {
        if(Visited == false)
        {
            Console.WriteLine("ROOM Entered at: " + Position);
            Visited = true;
        }

        
        if(Visited == false && RoomContents == RoomContents.Empty)
        {
            Console.WriteLine("Nothing is here");
            Visited = true;
        }

        


    }


    public virtual void OnInteract()
    {
        Console.WriteLine("There is nothing to do here...");
    }
}