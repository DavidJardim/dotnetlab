using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha11
{
    public class VehicleTest
    {
        private IVehicle vehicle;

        public IVehicle Vehicle{ get { return vehicle; } }

        public VehicleTest(IVehicle vehicle)
        {
            this.vehicle = vehicle;
        }
    }
}
