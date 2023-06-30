namespace Space;

public class Ship 
{
    public double x { get; set; }
    public double y { get; set; }
    public double speed_x { get; set; }
    public double speed_y { get; set; }
    public bool move_possible { get; set; } = true;
}
public class Spacebattle
{
    private Ship ship = new Ship();
    public Ship Move(Ship ship)
    {
        if (ship.x == double.NaN || ship.y == double.NaN)
        {
            throw new System.Exception();
        }

        if (ship.speed_x == double.NaN || ship.speed_y == double.NaN)
        {
            throw new System.Exception();
        }

        if (ship.move_possible == false)
        {
            throw new System.Exception();
        }

        ship.x = ship.x + ship.speed_x;
        ship.y = ship.y + ship.speed_y;

        return ship;

        throw new NotImplementedException();
    }
}