namespace People_MVC_assignment_Lexicon.Models.Repos
{
    public class InMemoryPeopleRepo : IPersonRepo
    {
        static int idCounter = 0;
        public static List<Person> personList = new List<Person>();
        public Person Create(Person person)
        {
            person.id = ++idCounter;
            personList.Add(person);
            return person;
        }

        public void Delete(Person person)
        {
            if (person != null) { personList.Remove(person); }
        }

        public List<Person> GetAll()
        {
            return personList;
        }

        public Person GetById(int id)
        {
            Person person = null;
            foreach (Person aPerson in personList)
            {
                if (aPerson.id == id)
                {
                    person = aPerson;
                    break;
                }
            }
            return person;
        }

        public void Update(Person person)
        {
            Person originalPerson = GetById(person.id);
            if (originalPerson != null)
            {
                originalPerson.firstName = person.firstName;
                originalPerson.lastName = person.lastName;
            }
        }
    }
}
