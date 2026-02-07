

public partial class PitRoom : EventRoom
{
    public int RoundCounter { get; protected set; }
    public PitRoom(WorldGrid grid, int row, int column) : base(grid, row,column, RoomContents.Pit)
    {
        //Console.WriteLine("PitRoom created at:" + Position);
        RoundCounter = 0;
    }

    public override void OnEnter(Player player)
    {
        base.OnEnter();

        RoundCounter += 1;
        if(RoundCounter == 1)
        {
            Console.WriteLine("Uhhhhm... guys? There is a GIANT PIT right in front of me and if i don't move away here quickly (like right heckin now) I will kind of die!");
            RoomContents = RoomContents.Pitfall;
        }
        if(RoundCounter == 2 && RoomContents != RoomContents.Deactivated)
        {
            Helper.PlayerDeath("THE GROUND CAVES IN!!!", ParentGrid.GameEntry);
        }
    }

    public override void OnInteract()
    {
        RoomContents = RoomContents.Deactivated;

        Console.WriteLine("Pit Room deactivated! It is safe to traverse now");
    }





}