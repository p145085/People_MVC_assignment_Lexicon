using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace People_MVC_assignment_Lexicon.DEPRECATED
{
    //    public class InMemoryPersonRepo : IPeopleRepo
    //    {
    //    //    static int idCounter = 0;
    //    //    public static List<Person> personList = new List<Person>();
    //    //    readonly PeopleDbContext _peopleDbContext;
    //    //    public InMemoryPersonRepo(PeopleDbContext peopleDbContext)
    //    //    {
    //    //        _peopleDbContext = peopleDbContext;
    //    //    }
    //    //    public Person Create(Person person)
    //    //    {
    //    //        person.CityIdFromPerson = ++idCounter;
    //    //        personList.Add(person);
    //    //        return person;
    //    //    }

    //    //    public void Delete(Person person)
    //    //    {
    //    //        if (person != null) { personList.Remove(person); }
    //    //    }

    //    //    public List<Person> GetAll()
    //    //    {
    //    //        return personList;
    //    //    }

    //    //    public Person GetById(int id)
    //    //    {
    //    //        Person person = null;
    //    //        foreach (Person aPerson in personList)
    //    //        {
    //    //            if (aPerson.CityIdFromPerson == id)
    //    //            {
    //    //                person = aPerson;
    //    //                break;
    //    //            }
    //    //        }
    //    //        return person;
    //    //    }
    //    //    public Person GetByName(string name)
    //    //    {
    //    //        Person person = null;
    //    //        foreach (Person aPerson in personList)
    //    //        {
    //    //            if (aPerson.FirstName.Contains(name) || aPerson.LastName.Contains(name))
    //    //            {
    //    //                person = aPerson;
    //    //                break;
    //    //            }
    //    //        }
    //    //        return person;
    //    //    }
    //    //    public Person GetByCityName(string city)
    //    //    {
    //    //        Person person = null;
    //    //        foreach (Person aPerson in personList)
    //    //        {
    //    //            if (aPerson.CityNameFromViewModel == city)
    //    //            {
    //    //                person = aPerson;
    //    //                break;
    //    //            }
    //    //        }
    //    //        return person;
    //    //    }

    //    //    public void Update(Person person)
    //    //    {
    //    //        Person originalPerson = GetById(person.CityIdFromPerson);
    //    //        if (originalPerson != null)
    //    //        {
    //    //            originalPerson.FirstName = person.FirstName;
    //    //            originalPerson.LastName = person.LastName;
    //    //            originalPerson.Age = person.Age;
    //    //            originalPerson.CityNameFromViewModel = person.CityNameFromViewModel;
    //    //            originalPerson.Phone = person.Phone;
    //    //        }
    //    //    }
    //    //}
}
