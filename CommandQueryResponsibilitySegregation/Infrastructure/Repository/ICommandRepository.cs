namespace CommandQueryResponsibilitySegregation.Infrastructure.Repository
{
    public interface ICommandRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
