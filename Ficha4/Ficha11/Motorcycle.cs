using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha11
{
    public class Motorcycle : Vehicle  
    {
        private string topSpeed;

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
           base.ToString() + ", TopSpeed: " + this.topSpeed;
        }

    }
}
