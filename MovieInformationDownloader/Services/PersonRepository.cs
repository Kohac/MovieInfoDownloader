using MovieInformationDownloader.Context;

namespace MovieInformationDownloader.Services;

internal class PersonRepository : AbstractPerson
{
    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    private readonly MovieInfoContext _context = new();
    public override long GetPersonId()
    {
        try
        {
            var result = _context.People.Max(x => x.PersonId) + 1;
            return result;
        }
        catch (Exception ex)
        {
            log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
            return 1;
        }
    }

    public override void InsertPerson(Person person)
    {
        try
        {
            _context.People.Add(person);
            Save();
            Console.WriteLine($"Person with id: {person.PersonId} was inserted to DB!");
        }
        catch (Exception ex)
        {
            log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
        }
    }
    public override void UpdatePerson(Person person)
    {
        try
        {
            _context.People.Update(person);
            Save();
        }
        catch (Exception ex)
        {
            log.Error($"Error: {ex.Message} \n\t {ex.StackTrace} \n\t {ex.Source}");
        }
    }

    public override bool Save()
    {
        return _context.SaveChanges() == 1 ? true : false;
    }
}
