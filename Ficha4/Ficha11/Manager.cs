namespace Ficha11
{
    internal class Manager : IEmployee
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int ManagerId { get; set; }

        public string FullName()
        {
            return ManagerId + ": " + FirstName + " " + LastName;
        }
    }
}