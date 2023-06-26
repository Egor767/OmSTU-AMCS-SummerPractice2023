using Xunit;
using SquareEquationLib;

namespace Square.UnitTests.Equation
{
    public class SquareEquation_Solve
    {
        public double eps = 1e-5;

        [Theory]
        //a
        [InlineData(0, 1, 1)]
        [InlineData(double.NaN, 1, 1)]
        [InlineData(double.NegativeInfinity, 1, 1)]
        [InlineData(double.PositiveInfinity, 1, 1)]
        //b
        [InlineData(1, double.NaN, 1)]
        [InlineData(1, double.NegativeInfinity, 1)]
        [InlineData(1, double.PositiveInfinity, 1)]
        //c
        [InlineData(1, 1, double.NaN)]
        [InlineData(1, 1, double.NegativeInfinity)]
        [InlineData(1, 1, double.PositiveInfinity)]
        
        public void Solve_ValuesException_ReturnFalse(double a, double b, double c)
        {
            var _squareEquation = new SquareEquation();

            Assert.ThrowsAny<System.ArgumentException>(() => _squareEquation.Solve(a, b, c));
        }

        //2 корня
        [Theory]
        [InlineData(1, 4, 3)]
        public void Solve_2Values_ReturnTrue(double a, double b, double c)
        {
            double[] expect = new double[2]{-3, -1};
            var _squareEquation = new SquareEquation();
            double[] result = _squareEquation.Solve(a, b, c);
            bool bool_test1 = Math.Abs(expect[0] - result[0])<eps;
            bool bool_test2 = Math.Abs(expect[1] - result[1])<eps;

            Assert.True((result.Length == 2) && (bool_test1 && bool_test2));
        }

        //1 корень
        [Theory]
        [InlineData(1, 4, 4)]
        public void Solve_1Value_ReturnFalse(double a, double b, double c)
        {
            double[] expect = new double[1]{-2};
            var _squareEquation = new SquareEquation();
            double[] result = _squareEquation.Solve(a, b, c);
            bool bool_test = Math.Abs(result[0] - expect[0])<eps;
            
            Assert.True(bool_test);
        }

        //нет корней
        [Theory]
        [InlineData(1, 1, 2)]
        public void Solve_NotValue_ReturnFalse(double a, double b, double c)
        {
            var _squareEquation = new SquareEquation();
            double[] result = _squareEquation.Solve(a, b, c);
            
            Assert.True(result.Length == 0);
        }
    }
}