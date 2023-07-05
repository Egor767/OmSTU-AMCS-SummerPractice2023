using System;
namespace Space;

public class Ship 
{
    private double eps = 1e-5;
    private double x;
    private double y;
    private double speed_x; 
    private double speed_y; 
    private bool move_possible = true;

    private double fuel_reserve;
    private double waste_fuel;
    private double angle; 
    private double angle_speed;
    private bool turn_possible  = true;

    public void SetCords(double _x, double _y)
    {
        x = _x;
        y = _y;
    }

    public void SetSpeed(double vx, double vy)
    {
        speed_x = vx;
        speed_y = vy;
    }

    public void SetMovePossible(bool possible)
    {
        move_possible = possible;
    }

    public double GetFuelReserve()
    {
        return fuel_reserve;
    }
    public void SetFuelReserve(double FuelReserve)
    {
        fuel_reserve = FuelReserve;
    }

    public void SetWasteFuel(double WasteFuel)
    {
        waste_fuel = WasteFuel;
    }

    public void SetAngle(double _Angle)
    {
        angle = _Angle;
    }
    public void SetAngleSpeed(double AngleSpeed)
    {
        angle_speed = AngleSpeed;
    }

    public void SetTurnPossible(bool TurnPossible)
    {
        turn_possible = TurnPossible;
    }

    public double[] Move()
    {
        if (x == double.NaN || y == double.NaN)
        {
            throw new System.Exception();
        }

        else if (speed_x == double.NaN || speed_y == double.NaN)
        {
            throw new System.Exception();
        }
        
        else if (move_possible == false)
        {
            throw new System.Exception();
        }

        else if (Math.Abs(fuel_reserve - waste_fuel)<eps)
        {
            throw new System.Exception();
        }

        fuel_reserve -= waste_fuel;

        x = x + speed_x;
        y = y + speed_y;

        double[] new_cords = new double[2]{x, y};

        return new_cords;

        throw new NotImplementedException();
    }

    public double Turn() 
    {
        if (angle == double.NaN || angle_speed == double.NaN)
        {
            throw new System.Exception();
        }
        
        else if (turn_possible == false)
        {
            throw new System.Exception();
        }

        angle += angle_speed;

        return angle;

        throw new NotImplementedException();
    }

}
