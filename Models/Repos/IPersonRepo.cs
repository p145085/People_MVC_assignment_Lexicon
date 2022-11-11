namespace People_MVC_assignment_Lexicon.Models.Repos
{
    public interface IPersonRepo
    {
        Person Create(Person person);
        List<Person> GetAll();
        Person GetById(int id);

        void Update(Person person);

        void Delete(Person person);
    }
}
