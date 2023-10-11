namespace SpaceBattle;

public class Vector
{
    double x {get; set;}
    double y {get; set;}

    public Vector(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public static Vector operator +(Vector u1, Vector u2)
    {
        try 
        {
            return new Vector(u1.x + u2.x, u1.y + u2.y);
        }
        catch
        {
            throw new ArgumentException("Wrong angle or angle velocity!");
        }
    }

    public bool IsNan()
    {
        if (x == double.NaN || y == double.NaN)
            return true;
        else 
            return false;
    }

}