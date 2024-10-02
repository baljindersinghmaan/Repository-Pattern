namespace Repo_Pattern.RepoPattern;
    public interface IRepository<T> where T : IAggregateRoots{
        public T FindById(object Id);
        public IList<T> GetAll();
        public T Create();

        public T Create(params object[] args);
        public void Update(object Id, T model);

        public void Delete(object Id);

    }
