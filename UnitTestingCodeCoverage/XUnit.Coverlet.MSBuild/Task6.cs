namespace XUnit.Coverlet.MSBuild;
using System;
using SquareEquationLib;
using TechTalk.SpecFlow;
[Binding]
public class UnitTest1
{
    private double eps = 1e-5;
    private double[] result = new double[0];
    private double[] values = new double[3];
    private Exception exception = new Exception();
    private SquareEquation squar = new SquareEquation();

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
    public void КвадратноеУравнение(string a, string b, string c)
    {
        string[] mas = new string[3]{a, b, c};
        for (int i = 0; i<3; i++)
        {
            if (mas[i] == "NaN") 
            {
                values[i] = double.NaN;
            }
            else if (mas[i] == "Double.PositiveInfinity")
            {
                values[i] = double.PositiveInfinity;
            }
            else if (mas[i] == "Double.NegativeInfinity")
            {
                values[i] = double.NegativeInfinity;
            }
            else 
            {
                values[i] = double.Parse(mas[i]);
            }
        }
    }

    [When(@"вычисляются корни квадратного уравнения")]
    public void ВычислениеКвадратногоУравнения()
    {
        try 
        {
            var answer = squar.Solve(values[0], values[1], values[2]);
            if (answer.Length == 1)
            {
                result = new double[1]{answer[0]};
            }
            if (answer.Length == 2)
            {
                result = new double[2]{answer[0], answer[1]};
            }
        }
        catch(Exception except)
        {
            exception = except;
        }
    }
      
    [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
    public void ДваКорня(string x1, string x2)
    {
        bool bool_test1 = Math.Abs(double.Parse(x1) - result[0])<eps;
        bool bool_test2 = Math.Abs(double.Parse(x2) - result[1])<eps;
        Assert.True(bool_test1 && bool_test2);
    }

    [Then(@"квадратное уравнение имеет один корень 1 кратности два")]
    public void ОдинКорень()
    {
        bool bool_test1 = Math.Abs(1 - result[0])<eps;
        Assert.True(bool_test1);
    }

    [Then(@"множество корней квадратного уравнения пустое")]
    public void НетКорней()
    {
        Assert.True(result.Length == 0);
    }

    [Then(@"выбрасывается исключение ArgumentException")]
    public void Исключение()
    {
        Assert.ThrowsAny<ArgumentException>(() => throw exception);
    }
}