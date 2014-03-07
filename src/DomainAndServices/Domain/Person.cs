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
        public int SortOrder { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return -1;
            }
            var objAsPerson = obj as Person;
            if (objAsPerson == null)
            {
                return -1;
            }
            return this.SortOrder.CompareTo(objAsPerson.SortOrder);
        }
    }
}
