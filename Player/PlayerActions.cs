using System.Numerics;

public interface IPlayerAction
{
    void PlayerAction(Player player, WorldGrid worldGrid);
}

public class MoveNorth : IPlayerAction
{
    public void PlayerAction(Player player, WorldGrid worldGrid)
    {
        if(player.IsMoveValid(worldGrid, this))
        {
            player.DeltaPosition(-1,0);
        }
    }
}
public class MoveSouth : IPlayerAction
{
    public void PlayerAction(Player player, WorldGrid worldGrid)
    {
        if(player.IsMoveValid(worldGrid, this))
        {
            player.DeltaPosition(1,0);
        }
    }
}
public class MoveEast : IPlayerAction
{
    public void PlayerAction(Player player, WorldGrid worldGrid)
    {
        if(player.IsMoveValid(worldGrid, this))
        {
            player.DeltaPosition(0,1);
        }
    }
}
public class MoveWest : IPlayerAction
{
    public void PlayerAction(Player player, WorldGrid worldGrid)
    {
        if(player.IsMoveValid(worldGrid, this))
        {
            player.DeltaPosition(0,-1);
        }
    }
}
public class InteractWithRoom : IPlayerAction
{
    public void PlayerAction(Player player, WorldGrid worldGrid)
    {
        player.InteractWithRoom(worldGrid);
    }
}

public class Idle : IPlayerAction
{
    public void PlayerAction(Player player, WorldGrid worldGrid)
    {
        ;
    }
}

public class Help : IPlayerAction
{
    public void PlayerAction(Player player, WorldGrid worldGrid)
    {
        Helper.Help();
    }
}

public class ShootNorth : IPlayerAction
{
    public void PlayerAction(Player player, WorldGrid worldGrid)
    {
        Vector2 pPos = player.Position;
    }
}