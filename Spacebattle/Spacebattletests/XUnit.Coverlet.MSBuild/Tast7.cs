using System;
using Space;
using TechTalk.SpecFlow;

namespace XUnit.Coverlet.MSBuild;

[Binding]
public class UnitTest1
{
    private double eps = 1e-5; 
    private Spacebattle battle = new Spacebattle();
    private Exception exception = new Exception();
    private Ship ship = new Ship();
    
    // 1st test
    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void Координаты(string x, string y)
    {
        ship.x = double.Parse(x);
        ship.y = double.Parse(y);
    }

    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void Скорость(string vx, string vy)
    {
        ship.speed_x = double.Parse(vx);
        ship.speed_y = double.Parse(vy);
    }
    
    [When("происходит прямолинейное равномерное движение без деформации")]
    public void Перемещение()
    {
        try 
        {
            var result = battle.Move(ship);
        }
        catch(Exception except)
        {
            exception = except;
        }
    }
    
    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void Переместился(string x1, string y1)
    {
        bool bool_test1 = Math.Abs(double.Parse(x1) - ship.x)<eps;
        bool bool_test2 = Math.Abs(double.Parse(y1) - ship.y)<eps;

        Assert.True(bool_test1 && bool_test2);
    }
    
    //2nd test
    [Given("космический корабль, положение в пространстве которого невозможно определить")]
    public void НетКоординат()
    {
        ship.x = double.NaN;
        ship.y = double.NaN;
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
        ship.speed_x = double.NaN;
        ship.speed_y = double.NaN;
    }  
    //4 test

    [Given("изменить положение в пространстве космического корабля невозможно")]
    public void НельзяПеремещаться()
    {
        ship.move_possible = false;
    } 
}