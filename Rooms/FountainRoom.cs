public partial class FountainRoom : EventRoom
{

    public bool IsActivated { get; private set; }
    public FountainRoom(WorldGrid grid, int row, int column) : base(grid, row,column, RoomContents.Fountain)
    {
        //Console.WriteLine("FountainRoom created at:" + Position);
    }

    public override void OnEnter(Player player)
    {
        base.OnEnter();
    }

    public override void OnInteract()
    {
        IsActivated = true;
        Console.WriteLine();
        Console.WriteLine("+++++++++++++++++++++++");
        Console.WriteLine("++Fountain activated!++");
        Console.WriteLine("+++++++++++++++++++++++");
        Console.WriteLine("Press any key to conitinue the journey, back to the entrance!");
        Console.ReadKey();

    }

    public void FountainSound(Player player)
    {
        if (player.Position == Position)
        {
            Console.WriteLine("There it is! The magnigicient Fountain");
        }
        if(!IsActivated && player.Position != Position)
        {
            string dir = "";

            if(player.Position.X > Row)
            {
                dir += "N";
            }
            else if (player.Position.X < Row)
            {
                dir += "S";
            }


            if(player.Position.Y > Column)
            {
                dir += "W";
            }
            else if (player.Position.Y < Column)
            {
                dir += "E";
            }

            Console.WriteLine("YOU HEAR A DRIPPING COMING FROM " + dir + " !!"
            + "THAT MUST BE THE FOUNTAIN!! ");
        }
        
    }
}