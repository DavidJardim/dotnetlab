using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha4
{
    public class Circle : Shape
    {

        private double radius;


        public Circle() : base()
        {                        
            this.radius = 0;
        }

        public Circle(Point position, double radius): base(position)
        {            
            this.radius = radius;
        }


        public override double Area()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public override double Perimeter()
        {
            return (2 * Math.PI) * radius;
        }

        public override string ToString()
        {
            return Position.ToString() + ", Radius: " + this.radius;
        }
    }
}
