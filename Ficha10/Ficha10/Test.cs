namespace Ficha10
{
    public class Test
    {
        int width;
        int height;
        int weight;

        public override string ToString()
        {

            string str = "";

            str += "WIDTH: " + width + ", ";
            str += "HEIGHT: " + height + ", ";
            str += "WEIGHT: " + weight;

            return str;
        }

        private Travel travel;

        enum Travel
        {
            LAND,
            WATER,
            AIR
        }

        enum JobState
        {
            SUCCESS,
            FAILED,
            BLOCKED
        }

        enum MENU
        {
            START,
            OPTIONS,
            CREDITS,
            QUIT
        }


    }
}
