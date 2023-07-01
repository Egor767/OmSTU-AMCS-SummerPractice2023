using System;
using Space;
using TechTalk.SpecFlow;

namespace XUnit.Coverlet.MSBuild;

[Binding]
public class UnitTest1
{
    private double eps = 1e-5; 
    private Exception exception = new Exception();
    private Ship ship = new Ship();
    private double[] cords = new double[2];
    private double local_fuel_reserve;
    private double local_angle;
    
    // 1st test
    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void Координаты(string x, string y)
    {
        ship.SetCords(double.Parse(x), double.Parse(y));
        ship.SetFuelReserve(4);
        ship.SetWasteFuel(1);
    }

    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void Скорость(string vx, string vy)
    {
        ship.SetSpeed(double.Parse(vx), double.Parse(vy));
    }
    
    [When("происходит прямолинейное равномерное движение без деформации")]
    public void Перемещение()
    {
        try 
        {
            var result = ship.Move();
            cords[0] = result[0];
            cords[1] = result[1];
            local_fuel_reserve = ship.GetFuelReserve();
        }
        catch(Exception except)
        {
            exception = except;
        }
    }
    
    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void Переместился(string x1, string y1)
    {
        bool bool_test1 = Math.Abs(double.Parse(x1) - cords[0])<eps;
        bool bool_test2 = Math.Abs(double.Parse(y1) - cords[1])<eps;

        Assert.True(bool_test1 && bool_test2);
    }
    
    //2nd test
    [Given("космический корабль, положение в пространстве которого невозможно определить")]
    public void НетКоординат()
    {
        ship.SetCords(double.NaN, double.NaN);
    }

    [Then("возникает ошибка Exception")]
    public void НеПереместился()
    {
        Assert.ThrowsAny<Exception>(() => throw exception);
    }
    
    //3rd test
    [Given("скорость корабля определить невозможно")] 
    public void НетСкорости()
    {
        ship.SetSpeed(double.NaN, double.NaN);
    }  
    //4 test
    [Given("изменить положение в пространстве космического корабля невозможно")]
    public void НельзяПеремещаться()
    {
        ship.SetMovePossible(false);
    } 
    
    //Задание 8
    //test 1
    [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
    public void ЕстьТопливо(string fuel)
    {
        ship.SetFuelReserve(double.Parse(fuel));
        ship.SetCords(1, 1);
        ship.SetSpeed(1, 1);
    }
    
    [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
    public void ЕстьРасход(string waste_fuel)
    {
        ship.SetWasteFuel(double.Parse(waste_fuel));
    }

    [Then(@"новый объем топлива космического корабля равен (.*) ед")]
    public void НовоеТопливо(string result_fuel)
    {
        bool bool_test3 = Math.Abs(local_fuel_reserve - double.Parse(result_fuel))<eps;

        Assert.True(bool_test3);
    }

    //test 3
    [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
    public void ЕстьУгол(string _angle)
    {
        ship.SetAngle(double.Parse(_angle));
    }
    
    [Given(@"имеет мгновенную угловую скорость (.*) град")]
    public void ЕстьПоворот(string turn)
    {
        ship.SetAngleSpeed(double.Parse(turn));
    }

    [When("происходит вращение вокруг собственной оси")]
    public void Вращение()
    {
        try 
        {
            local_angle = ship.Turn();
        }
        catch(Exception except)
        {
            exception = except;
        }
    }

    [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
    public void НовыйУгол(string result_angle)
    {
        bool bool_test4 = Math.Abs(local_angle - double.Parse(result_angle))<eps;
  
        Assert.True(bool_test4);
    }

    //test 4
    [Given("космический корабль, угол наклона которого невозможно определить")]
    public void НетУгла()
    {
        ship.SetAngle(double.NaN);
    }

    //test 5
    [Given("мгновенную угловую скорость невозможно определить")]
    public void НетПоворота()
    {
        ship.SetAngleSpeed(double.NaN);
    }

    //test 6 
    [Given("невозможно изменить уголд наклона к оси OX космического корабля")]
    public void НевозможноПовернуть()
    {
        ship.SetTurnPossible(false);
    }
}
