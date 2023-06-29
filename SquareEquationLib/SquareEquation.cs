namespace SquareEquationLib;



public class SquareEquation
{
    public double[] Solve(double a, double b, double c)
    {
        var eps = 1e-5;
 
        if (Math.Abs(a) < eps)
        {
            throw new System.ArgumentException();
        }

        if (double.IsNaN(a) || double.IsNegativeInfinity(a) || double.IsPositiveInfinity(a))
        {
            throw new System.ArgumentException();
        }

        if (double.IsNaN(b) || double.IsNegativeInfinity(b) || double.IsPositiveInfinity(b))
        {
            throw new System.ArgumentException();
        }

        if (double.IsNaN(c) || double.IsNegativeInfinity(c) || double.IsPositiveInfinity(c))
        {
            throw new System.ArgumentException();
        }

        var d = Math.Pow(b,2) - 4*a*c;

        if (d>=eps)
        {
            if (Math.Abs(b)<eps)
            {
                double[] result = new double[2];

                var x1 = (-b - Math.Sqrt(d))/(2*a);
                var x2 = (-b + Math.Sqrt(d))/(2*a);
                result[1] = x1;
                result[0] = x2;
                return result;
            }
            else
            {
                double[] result = new double[2];

                var x1 = -(b + Math.Sign(b) * Math.Sqrt(d))/2;
                var x2 = c/x1;
                result[0] = x1;
                result[1] = x2;
                return result; 
            } 
        }

        else if (Math.Abs(d)<eps)
        {
            if (Math.Abs(b)<eps)
            {
                double[] result = new double[1];

                var x1 = (-b)/(2*a);
                result[0] = x1;
            }
            else
            {
                double[] result = new double[1];

                var x1 = -(b + Math.Sign(b) * Math.Sqrt(d))/2;
                result[0] = x1;
                return result;
            }
        }

        else
        {
            double[] result = new double[0];
            return result;
        }
        

        throw new NotImplementedException();
    }
}
