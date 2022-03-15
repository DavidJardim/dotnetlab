namespace Ficha11
{
    public class Engine
    {
        private int torque;
        private int displacement;
        private int horsepower;


        public Engine(int torque, int displacement, int horsepower)
        {
            this.displacement = displacement;
            this.torque = torque;  
            this.horsepower = horsepower;
        }

        public override string ToString()
        {
            return "Torque: " + torque + ", Disp: " + displacement + ", HP: " + horsepower;
        }
    }
}