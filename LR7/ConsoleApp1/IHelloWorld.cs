namespace Laba7
{
    internal interface IHelloWorld
    {
        public void SayHelloWorld();
    }
}




delegate double CalcZ(double x, double y)
CalcZ Z;

Z = (x, y) => Math.Sin(x * x) - 2 * Math.Cos(y);

double t;
t = Z(0.0, 0.0); 