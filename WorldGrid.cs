using System.Numerics;
// HALLO?


//AHHHH!!!!! ICH CHECKE!!
public class WorldGrid
{
    Random rand = new();


    public Room[,] GridAsArray;
    public int Rows;
    public int Columns;

    public FountainRoom? FountainRoom {get; private set;}
    public Room? OccupiedRoom { get; private set; }
    private List<Room> VisibleEventRooms { get; } = new();
    int round = 0;

    public DateTime GameEntry { get; protected set; }






    

    public WorldGrid(Player player)
    {
        Console.WriteLine("Round: " + round);

        int dim = AskGameSize();
        Rows = dim;
        Columns = dim; 
        GridAsArray = new Room[dim,dim];


        FillGrid();
        Helper.DrawLine(Rows);
        
        UpdateAndPrintGrid(player);
        HandleRoomEvents(player);
        WorldSounds(player);
    }

        public void GameUpdate(Player player)
        { 
            GameEntry = DateTime.Now;
            while(!IsGameWon(player))
            {
                Helper.DrawLine(Rows);
                
                player.AskAndDoPlayer(this); //

                Helper.DrawLine(Rows);

                Console.WriteLine("Round: " + round);

                Helper.DrawLine(Rows);

                UpdateAndPrintGrid(player); //

                HandleRoomEvents(player);

                Helper.DrawLine(Rows);

                WorldSounds(player);

                round++;
            }


            Console.WriteLine("++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++YOU WON! YOU SAVED THE FOUNTAIN!+++");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++");

            Helper.DisplayGameTime(GameEntry);
        }

    public void UpdateAndPrintGrid(Player player)
    {
        VisibleEventRooms.Clear();

        //Grid Logic
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                Room currentlyUpdatedRoom = GridAsArray[row,column]; //the room that is currently managed by the updateandprintgrid method, if it equlas the pp, other logic happens duh

                if (player.Position.Equals(currentlyUpdatedRoom.Position))
                {
                    //Player in room
                    OccupiedRoom = currentlyUpdatedRoom;
                    // Console.WriteLine("Spieler in Raum " + OccupiedRoom.Position );
                    Console.Write(
                    "[" + 
                    player.Label
                    .PadRight(0, ' ').PadLeft(0, ' ') + 
                    "]"
                    );

                }
                else //player not in room
                {
                    if(currentlyUpdatedRoom.Visited == true)
                    {
                        Console.Write(
                        "[" + 
                        GridAsArray[row,column]
                        .RoomContents
                        .ToString()
                        .PadRight(10, ' ').PadLeft(12, ' ') + 
                        "]"
                        );
                    }
                    else
                    {
                        Console.Write(
                        "[" + 
                        "???"
                        .PadRight(10, ' ').PadLeft(12, ' ') + 
                        "]"
                        );
                    }

                    if (currentlyUpdatedRoom is EventRoom eventRoom)
                    {
                        if (eventRoom.RoomVisibleS(player))
                        {
                            VisibleEventRooms.Add(eventRoom);
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }



    public bool IsGameWon(Player player)
    {
        return player.Position == new Vector2(0,0) && FountainRoom.IsActivated;
    }



    public void FillGrid()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                GridAsArray[row,column] = new Room(row,column);
            }
        }

        int fountainRow = rand.Next(1,Rows);
        int fountainCol = rand.Next(1,Rows);

        GridAsArray[0,0].SetRoomContents(RoomContents.Entrance);
        GridAsArray[fountainRow,fountainCol] = new FountainRoom(this, fountainRow,fountainCol);
        FountainRoom = (FountainRoom)GridAsArray[fountainRow,fountainCol];

        GenerateAmarokRooms(Rows, 1);
        GeneratePitRooms(Rows);
        GenerateMaelstromRooms(Rows, 1);

        //GenerateSpecialRooms(Rows,(g,r,c) => new AmarokRoom(this, r,c), 0.25f);
        //GenerateSpecialRooms(Rows,(g,r,c) => new PitRoom(this,r,c));
        //GenerateSpecialRooms(Rows,(g,r,c) => new MaelstromRoom(this, r,c), 0.5f);

    }

    public static int AskGameSize()
    {
        Console.WriteLine("HOW LARGE SHOULD THE GAMEFIELD BE?");
        Console.WriteLine("(1) --- Small (4x4)");
        Console.WriteLine("(2) --- Medium (6x6)");
        Console.WriteLine("(3) --- Large (8x8)");
        Console.Write("Enter 1, 2, 3: ");

        string? size = Console.ReadLine();
        int dim = size switch
        {
            "1" => 4,
            "2" => 6,
            "3" => 8,
            _ => 6
        };

        return dim;
    }


    public void GeneratePitRooms(int gameSize)
    {
        for(int numberPitRooms = 0; numberPitRooms < gameSize; numberPitRooms++)
        {
            int pitRow = rand.Next(0,GridAsArray.GetLength(0));
            int pitCol = rand.Next(0,GridAsArray.GetLength(1));

            if (GridAsArray[pitRow,pitCol].RoomContents == RoomContents.Empty)
            {
                GridAsArray[pitRow,pitCol] = new PitRoom(this, pitRow,pitCol);
                Console.WriteLine("PitRoom created at: " + GridAsArray[pitRow,pitCol].Position + ", Generator");
            }
        }
        
    }

    public void GenerateMaelstromRooms(int gameSize, float scale = 0.5f)
    {
        for(int numberNewRooms = 0; numberNewRooms < gameSize * scale; numberNewRooms++)
        {
            int newRow = rand.Next(0,GridAsArray.GetLength(0));
            int newCol = rand.Next(0,GridAsArray.GetLength(1));

            if (GridAsArray[newRow,newCol].RoomContents == RoomContents.Empty)
            {
                GridAsArray[newRow,newCol] = new MaelstromRoom(this, newRow,newCol);
                Console.WriteLine("MaelstromRoom created at: " + GridAsArray[newRow,newCol].Position + ", Generator");
            }
        }
    }

    public void GenerateAmarokRooms(int gameSize, float scale = 0.5f)
    {
        for(int numberNewRooms = 0; numberNewRooms < gameSize * scale; numberNewRooms++)
        {
            int newRow = rand.Next(0,GridAsArray.GetLength(0));
            int newCol = rand.Next(0,GridAsArray.GetLength(1));

            if (GridAsArray[newRow,newCol].RoomContents == RoomContents.Empty)
            {
                GridAsArray[newRow,newCol] = new AmarokRoom(this, newRow,newCol);
                Console.WriteLine("MaelstromRoom created at: " + GridAsArray[newRow,newCol].Position + ", Generator");
            }
        }
    }

    public void GenerateSpecialRooms<T>(int gamesize, Func<WorldGrid, int, int, T> roomFactory, float scale = 1) where T : EventRoom
    {

        int createdRooms = 0;
        int numberSpecialRooms = (int)(gamesize * scale);
        for (int numberNewRooms = 0; numberNewRooms < gamesize; numberNewRooms++)
        {
            int newRow = rand.Next(0,GridAsArray.GetLength(0));
            int newCol = rand.Next(0,GridAsArray.GetLength(1));

            if (GridAsArray[newRow,newCol].RoomContents == RoomContents.Empty)
            {
                GridAsArray[newRow,newCol] = roomFactory(this, newCol, newRow);
                createdRooms++;
                Console.WriteLine(GridAsArray[newRow,newCol] + " created at: " + GridAsArray[newRow,newCol].Position + ", Generator");
            }
        }
    }

    


    private void HandleRoomEvents(Player player)
    {
        Helper.DrawLine(Rows);
        OccupiedRoom.OnEnter(player);
    }

    private void VisibleEventSounds(Player player)
    {
        foreach(EventRoom eventRoom in VisibleEventRooms)
        {
            if (eventRoom != FountainRoom)
            {
                eventRoom.RoomSound(player);
            }
        }
    }

    private void WorldSounds(Player player)
    {
        VisibleEventSounds(player);
        FountainRoom?.FountainSound(player);
    }
}