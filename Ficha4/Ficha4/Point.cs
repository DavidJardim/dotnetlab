namespace Ficha4
{
    public class Point
    {
        private double x;
        private double y;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double DistanceTo(Point other)
        {
            double dx = Math.Pow(other.x - this.x, 2);
            double dy = Math.Pow(other.y - this.y, 2);
            return Math.Sqrt(dx + dy);
        }
    }
}
