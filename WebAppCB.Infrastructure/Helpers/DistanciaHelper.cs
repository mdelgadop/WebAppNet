namespace Infrastructure.Helpers
{
    public class DistanciaHelper
    {
        public double Distancia(int x1, int y1, int x2, int y2)
        {
            double dx1 = (double)(((double)x1) / ((double)100000));
            double dx2 = (double)(((double)x2) / ((double)100000));
            double dy1 = (double)(((double)y1) / ((double)100000));
            double dy2 = (double)(((double)y2) / ((double)100000));

            double distancia = System.Math.Sqrt(System.Math.Pow((dx1 - dx2), 2) + System.Math.Pow((dy1 - dy2), 2));
            double distancia2 = System.Math.Sqrt(((dx1 - dx2) * (dx1 - dx2)) + ((dy1 - dy2) * (dy1 - dy2)));

            return distancia;
        }
    }
}