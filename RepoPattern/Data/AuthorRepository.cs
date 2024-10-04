namespace Repo_Pattern.RepoPattern;

public class MockAuthorRepository : IRepository<Author, string>
{
    private static IList<Author> _db = new List<Author>();
    

    public Author Create(Author model)
    {
        _db.Add(model);
        return model;
    }

    public void Delete(string Id)
    {
        Author? a = FindById(Id);
        _db.Remove(a);
    }

    public Author FindById(string Id)
    {
        Author? a = _db.Where(author => author.Email == Id.ToString()).SingleOrDefault();

        if(a is null) {
            throw new ArgumentException("Author email must exist");
        }
        return a;
    }

    public IList<Author> GetAll()
    {
        return _db;
    }

    public void Update(string Id, Author model)
    {
        Author author = this.FindById(Id);

        if(model.Email != Id.ToString()) {
            throw new ArgumentException("Model ID should be matched");
        }
        _db.Remove(author);
        _db.Add(model);
    }
}
