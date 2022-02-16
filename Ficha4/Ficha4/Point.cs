 namespace Ficha4
{
    public class Point
    {
        // atributos
        private double x;
        private double y;

        // propriedade X
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        // propriedade Y
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        // Método
        public void SetXY(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        
        // Construtor por omissão 
        public Point()
        {
            x = 0;
            y = 0;
        }

        // Construtor por parâmetros
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Método
        public double DistanceTo(Point other)
        {
            double dx = Math.Pow(other.x - this.x, 2);
            double dy = Math.Pow(other.y - this.y, 2);
            return Math.Sqrt(dx + dy);
        }

        // Método
       public override string ToString()
        {
            return "X: " + this.x + ", Y: " + this.y;
        }
    }
}
