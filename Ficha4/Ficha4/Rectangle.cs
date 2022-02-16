using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha4
{
    public class Rectangle: Shape
    {
        /// atributos
        private Point topLeftPoint;
        private double height;
        private double width;


        ///propriedades
        public Point TopLeftPoint { 
            get { return topLeftPoint; } 
            set { topLeftPoint = value; } 
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        /// construtores
        public Rectangle()
        {
            this.topLeftPoint = new Point();
            this.height = 0;
            this.width = 0;
        }

        public Rectangle(Point topLeftPoint, double height, double width)
        {
            this.topLeftPoint = topLeftPoint;
            this.height = height;
            this.width = width;
        }
        


        public bool Contains(Point point)
        {
            Point topRightPoint = new Point(topLeftPoint.X + width, topLeftPoint.Y);
            Point bottomLeftPoint = new Point(topLeftPoint.X, topLeftPoint.Y - height);
            Point bottomRightPoint = new Point(topRightPoint.X, bottomLeftPoint.Y);


            if(point.X > topLeftPoint.X && point.X < topRightPoint.X &&
                point.Y > bottomLeftPoint.Y && point.Y < TopLeftPoint.Y)
            {
                return true;
            }
            else
            {
                return false;
            }           
        }

    

        public override double Area()
        {
            return height * width;
        }

        public override double Perimeter()
        {
            return (height * 2) + (width * 2);
        }
    }
}