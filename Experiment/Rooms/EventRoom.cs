public partial class EventRoom : Room
{

    public  WorldGrid ParentGrid { protected get; set; }

    //public EventRoom(int row, int column, RoomContents roomContents = RoomContents.Empty) : base(row, column, roomContents)
    //{
    //}
    public EventRoom(WorldGrid parentGrid, int row, int column, RoomContents roomContents = RoomContents.Empty) : base(row, column, roomContents)
    {
        ParentGrid = parentGrid;
    }


    public bool RoomVisibleS(Player player)
    {

        if((player.Position.X - 1 == Row 
        ||  player.Position.X + 1 == Row
        ||  player.Position.X == Row)
        && (player.Position.Y - 1 == Column 
        ||  player.Position.Y + 1 == Column))
        {
                return true;
        }
        else if((player.Position.Y - 1 == Column 
        ||  player.Position.Y + 1 == Column
        ||  player.Position.Y == Column)
        && (player.Position.X - 1 == Row 
        ||  player.Position.X + 1 == Row))
        {
                return true;
        }
        return false;   
    }

        public void RoomSound(Player player)
    {
            string direction = "";

            if(player.Position.X -1 == Row)
            {
                direction += 'N';
            }
            else if (player.Position.X + 1 == Row)
            {
                direction += 'S';
            }

            if(player.Position.Y - 1 == Column)
            {
                direction += 'W';
            }
            else if (player.Position.Y + 1 == Column)
            {
                direction += 'E';
            }
            

            if(direction != "")
            {
            Console.WriteLine($"CAUTION: You hear a strong draft blowing from {direction}. There is a {this} nearby!");
            }
        
    }
}