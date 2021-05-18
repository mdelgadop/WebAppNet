namespace Infrastructure.Helpers
{
    public class DistanciaHelper
    {
        public double Distancia(int x1, int y1, int x2, int y2)
        {
            double dx1 = x1/100000;
            double dx2 = x2/100000;
            double dy1 = y1/100000;
            double dy2 = y2/100000;

            return System.Math.Sqrt(System.Math.Pow((dx1 - dx2), 2) + System.Math.Pow((dy1 - dy2), 2));
        }
    }
}