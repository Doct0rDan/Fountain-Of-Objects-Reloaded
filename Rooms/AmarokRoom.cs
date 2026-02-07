public partial class AmarokRoom : EventRoom
{
    public AmarokRoom(WorldGrid parentGrid, int row, int column, RoomContents roomContents = RoomContents.Amarok) : base(parentGrid,row, column, roomContents)
    {
    }

    public override void OnEnter(Player player)
    {
        base.OnEnter(player);
        Random rd = new();

        int n = rd.Next(0,10);

        string deathNote = n switch
        {
            0 => "THE AMAROK EATS YOUR FUCKING FACE, DUDE! AN ANNOYING VOICE PROCLAIMS AND ASKS CRITICALLY: 'WHAT IS HAPPENING TO YOUR FACE AREA?'",
            1 => "MEEP MEEP",
            2 => "THE AMAROK IS DELIGHTED BY YOUR DEATH",
            3 => "THE AMAROK SELLS YOUR ORGANS ON THE BLACK MARKET",
            4 => "THE AMAROK OPENS UP A BURGER MANUFAKTUR IN THE GENTRIFIED DOWNTOWN AREA",
            5 => "THE AMAROK DOESN'T CONCERN ITSELF WITH FOUNTAIN SEEKING",
            6 => "WE ARE THE AMAROK",
            7 => "A SECOND AMAROK HAS ENTERED THE ROOM",
            8 => "THE AMAROK STARTS A LIVELEAK STREAM!",
            9 => "THE AMAROK KILLS ITSELF IN FRONT OF YOU, CHANGING THE TRAJECTORY OF YOUR LIFE FOREVER!!!",
            10 => "9/10 AMAROKS SUPPORT THIS MESSAGE",
            _ => "HOW DO YOU EVEN READ THIS?????",
        };

        Helper.PlayerDeath(deathNote, ParentGrid.GameEntry);
    }
}