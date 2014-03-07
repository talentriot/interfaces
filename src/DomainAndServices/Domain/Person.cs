using DomainAndServices.Interfaces;

namespace DomainAndServices.Domain
{
    public class Person : IDBDisplayable
    {
        public int Id { get; set; }

        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
