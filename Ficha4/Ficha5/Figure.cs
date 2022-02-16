using Ficha4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha5
{
    public class Figure
    {
        private List<Shape> shapes;

        public Figure()
        {
            this.shapes = new List<Shape>();
        }


        public void Add(Shape shape)
        {
            this.shapes.Add(shape);
        }

        public List<Shape> Shapes
        {
            get { return this.shapes; }
        }

    }
}
