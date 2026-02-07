public class MaelstromRoom : EventRoom
{


    public MaelstromRoom(WorldGrid parentGrid, int row, int column) : base(parentGrid, row, column, RoomContents.Maelstrom)
    {
        ParentGrid = parentGrid;
        //Console.WriteLine("Maelstrom Room Created at:" + Position);
    }

    public override void OnEnter(Player player)
    {
        base.OnEnter();

        Random ran = new();

        int newRow = ran.Next(0, ParentGrid.Rows);
        int newCol = ran.Next(0,ParentGrid.Columns);

        player.SetPosition(newRow, newCol);
        Console.WriteLine("The Wind swept you away!!! You're now at: " + player.Position);
        ParentGrid.UpdateAndPrintGrid(player);
        ParentGrid.GridAsArray[newRow, newCol].OnEnter(player);

    }

        public void MaelSound(Player player)
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
            Console.WriteLine($"CAUTION: You hear a storm brewing from {direction}. There is a Maelstrom nearby!");
            }
    }
}