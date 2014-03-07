using System;
using DomainAndServices.Interfaces;

namespace DomainAndServices.Domain
{
    public class Person : IDBDisplayable, ISortable, IComparable
    {
        public int Id { get; set; }

        public int SortNum { get; set; }

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
            return this.SortNum.CompareTo(objAsPerson.SortNum);
        }
    }
}
