namespace People_MVC_assignment_Lexicon.Models.Repos
{
    public class InMemoryPersonRepo : IPersonRepo
    {
        static int idCounter = 0;
        public static List<Person> personList = new List<Person>();
        public Person Create(Person person)
        {
            person.Id = ++idCounter;
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
                if (aPerson.Id == id)
                {
                    person = aPerson;
                    break;
                }
            }
            return person;
        }
        public Person GetByName(string name)
        {
            Person person = null;
            foreach (Person aPerson in personList)
            {
                if (aPerson.FirstName == name || aPerson.LastName == name)
                {
                    person = aPerson;
                    break;
                }
            }
            return person;
        }
        public Person GetByCity(string city)
        {
            Person person = null;
            foreach (Person aPerson in personList)
            {
                if (aPerson.City == city)
                {
                    person = aPerson;
                    break;
                }
            }
            return person;
        }

        public void Update(Person person)
        {
            Person originalPerson = GetById(person.Id);
            if (originalPerson != null)
            {
                originalPerson.FirstName = person.FirstName;
                originalPerson.LastName = person.LastName;
                originalPerson.Age = person.Age;
                originalPerson.City = person.City;
                originalPerson.Phone = person.Phone;
            }
        }
    }
}
