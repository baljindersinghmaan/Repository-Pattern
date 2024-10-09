using Microsoft.EntityFrameworkCore;

namespace Repo_Pattern.RepoPattern;

public class DbAuthorRepository : IRepository<Author, string>
{
    //private static IList<Author> _db = new List<Author>();
    private readonly BlogContext _db;

     

    public DbAuthorRepository(BlogContext db){
        _db = db;
    }

    public Author Create(Author model)
    {
        _db.Add(model);
        return model;
    }

    public void Delete(string Id)
    {
        Author? a = FindById(Id);

        _db.Blogs.Include(b => b.BlogPosts);
        _db.Remove(a);
    }

    public Author FindById(string Id)
    {
        Author? a = _db.Authors.Where(author => author.Email == Id.ToString()).SingleOrDefault();

        if(a is null) {
            throw new ArgumentException("Author email must exist");
        }
        return a;
    }

    public IList<Author> GetAll()
    {
        return _db.Authors?.ToList() ?? new List<Author>();
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
