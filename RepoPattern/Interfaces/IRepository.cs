namespace Repo_Pattern.RepoPattern;
    public interface IRepository<TType, Tkey> where TType : IAggregateRoots{
        public TType FindById(Tkey Id);
        public IList<TType> GetAll();
        

        public TType Create(TType model);
        public void Update(Tkey Id, TType model);

        public void Delete(Tkey Id);

    }
