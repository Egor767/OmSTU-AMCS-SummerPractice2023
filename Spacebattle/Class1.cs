namespace UtilityLibraries;

public class Ship 
{
    public double x { get; set; }
    public double y { get; set; }
    public double speed_x { get; set; }
    public double speed_y { get; set; }
    public bool move_possible { get; set; }
}
public class Spacebattle
{
    private Ship ship = new Ship();
    public Ship Move(Ship ship)
    {
        if (ship.x == double.NaN || ship.y == double.NaN)
        {
            throw new System.ArgumentException();
        }

        if (ship.speed_x == double.NaN || ship.speed_y == double.NaN)
        {
            throw new System.ArgumentException();
        }

        if (ship.move_possible == false)
        {
            throw new System.ArgumentException();
        }

        ship.x -= ship.speed_x;
        ship.y -= ship.speed_y;

        return ship;

        throw new NotImplementedException();
    }
}