using People_MVC_assignment_Lexicon.Models.Repos;

namespace People_MVC_assignment_Lexicon.Models
{
    public class Person
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public int age { get; set; }
        public string? city { get; set; }
        public long phone { get; set; }

        public Person NewPerson(string firstName, string lastName, string cityOfBirth, int age)
        {
            Person person = new Person();
            person.firstName = firstName;
            person.lastName = lastName;
            person.city = cityOfBirth;
            person.age = age;
            InMemoryPeopleRepo.personList.Add(person);
            return person;
        }
        public Person NewPerson(Person person)
        {
            InMemoryPeopleRepo.personList.Add(person);
            return person;
        }
    }
}
