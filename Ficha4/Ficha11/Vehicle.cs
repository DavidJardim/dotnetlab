using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha11
{
    public enum Travel
    {
        LAND,
        WATER,
        AIR
    }

    

    public  abstract class Vehicle: IVehicle
    {
        private string brand;
        private Engine engine;
        private Travel travel;
        public Travel Travel { get { return travel; } }
        
        public Vehicle(string brand, Engine engine, Travel travel)
        {
            this.brand = brand;
            this.engine = engine;
            this.travel = travel;
        }

      



        public abstract void Start();
    }
}
