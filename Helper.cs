public class Helper
{
    public static void DrawLine(int dim) //This is where i draw the line
    {
        for (int i = 0 ; i < dim; i++)
        {
            Console.Write("--------------");
        }

        Console.WriteLine();
    }


    public static void Intro()
    {
        Help();

        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine();
        Console.WriteLine("GOOD LUCK TRAVELER");
        Console.WriteLine("YOU WILL NEED IT...");
        Console.WriteLine();
        Console.Write("Press any key to begin...");
        Console.ReadKey();

        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.DarkGreen;

    }

    public static void Help()
    {
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine("+++++Welcome to The Fountain of Objects!+++++");
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine();
        Console.WriteLine("Traverse the dangerous Depths of the Fountain");
        Console.WriteLine("below. But beware! There are Pits and Mael - ");
        Console.WriteLine("stroms on the Way. You will be alerted by the");
        Console.WriteLine("Dreadful Sound they make. But only in adja - ");
        Console.WriteLine("cient Rooms. Maelstroms will sweep you some -");
        Console.WriteLine("where else in the Catacombs. Pitrooms have a ");
        Console.WriteLine("weak floor, so that you will perish in the   ");
        Console.WriteLine("darkness of their Pits, if you begin a 2nd    ");
        Console.WriteLine("round in one of them. Type 'interact' in the ");
        Console.WriteLine("Fountain Room to activate the Fountain. If   ");
        Console.WriteLine("you're able to make it back to the Entrance  ");
        Console.WriteLine("after you've activated the fountain, you win!");
        Console.WriteLine();
        Console.WriteLine("PS.: i dont know if this has any importance. ");
        Console.WriteLine("for your undergoing, but there are vicious.  ");
        Console.WriteLine("Amaroks roaming the caverns below... You will");
        Console.WriteLine("hear them as well, but you will not survive  ");
        Console.WriteLine("am encounter with them... lest ye been warned");
        Console.WriteLine();
    }


    public static void DisplayGameTime(DateTime gameEntry)
    {
        DateTime gameExit = DateTime.Now;
        TimeSpan gameTime = gameExit - gameEntry;
        Console.WriteLine($"And all it took you was {gameTime.Days} Days, {gameTime.Hours} Hours, {gameTime.Minutes} Minutes, {gameTime.Seconds} Seconds, {gameTime.Milliseconds} Milliseconds! PRETTY FAST IF YOU ASK ME. BUT NOBODY ASKS ME! NOBODY EVER ASKS THE OLD PETE. OH DAMNED BE YE! I CURSE YE IN THE NAME OF THE SEVEN DREADFUL SEAS, HARK I SCREAM! HARK!!! IF YE COULD ONLY EVER COMPREHEND WHAT FOUL HEX YE HAVE BROUGHT UPON THY FAMILY WITH THY FOOLISHNESS! DAMNED BE YE WINSLOW!!");
    }


    public static void PlayerDeath(string deathNote, DateTime gameEntry)
    {
        Console.WriteLine(deathNote);
        Console.WriteLine();
        Console.WriteLine("+++++++++++++++++++++++");
        Console.WriteLine("+++++++++++++++++++++++");
        Console.WriteLine("+++++++YOU DIED!+++++++");
        Console.WriteLine("+++++++++++++++++++++++");

        DisplayGameTime(gameEntry);

        Environment.Exit(0);
    }


    
}