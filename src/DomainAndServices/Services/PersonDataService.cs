using System.Collections;
using DomainAndServices.Domain;

namespace DomainAndServices.Services
{
    public class PersonDataService
    {
        public ArrayList GetAllPeople()
        {
            var fernando = new Person
            {
                Id = 1,
                FirstName = "Fernando",
                LastName = "Cardenas"
            };

            var russ = new Person
            {
                Id = 2,
                FirstName = "Russ",
                LastName = "Harris"
            };

            var nick = new Person
            {
                Id = 3,
                FirstName = "Nick",
                LastName = "Turner"
            };

            var people = new ArrayList
            {
                fernando,
                russ,
                nick
            };
            return people;
        }
    }
}
