using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha11
{
    internal class Program
    {

       















        private Vehicle vehicle;
        public Vehicle MyVehicle { get { return vehicle; } }
        public Program(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }
        static void Main(string[] args)
        {
            
            Engine engine = new Engine(120, 1000, 80);

            Car cx = new Car(5, 5, "BMW", engine, Travel.LAND);

            VehicleTest vt = new VehicleTest(cx);

            vt.Car.Start();

            Console.WriteLine(cx.ToString());

            

            //Motorcycle mx = new Motorcycle(Type.SPORT, 299, "")


            /* Car car = new Car();
             Program p = new Program(car);
             Console.WriteLine(p.MyVehicle.Start());*/
        }
    }
}
