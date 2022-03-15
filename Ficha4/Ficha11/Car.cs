using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha11
{
    public class Car : Vehicle
    {

        private int numberOfDoors;
        private int numberOfSeats;

        public Car(int numberOfDoors, int numberOfSeats, string brand, Engine engine, 
            Travel travel): base(brand, engine, travel)
        {
            this.numberOfDoors = numberOfDoors;
            this.numberOfSeats = numberOfSeats;
        }


        /* public override string ToString()
         {
             return base.ToString() + ", Doors: " + numberOfDoors + ", Seats: " + numberOfSeats;
         }*/

        public override string ToString()
        {
            return "Brand: " + brand + ", Engine: " +
                engine.ToString() + ", " + "Travel: " + travel;
        }

        public override void Start()
        {
            //return "START CAR";
        }

        

    }
}
