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
        public int Index { get; set; }


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
            var objAsFood = obj as Person;
            if (objAsFood == null)
            {
                return -1;
            }
            return this.Index.CompareTo(objAsFood.Index);
        }
    }

}
