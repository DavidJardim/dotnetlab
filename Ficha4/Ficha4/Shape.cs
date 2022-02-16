using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha4
{
    public abstract class Shape
    {
        internal Point position;
        
        public Shape()
        {
            position = new Point();
        }

        public Shape(Point position)
        {
            this.position = position;
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        // Métodos abstratos só providenciam a assinatura do método
        public abstract double Area();
        public abstract double Perimeter();

    }
}
