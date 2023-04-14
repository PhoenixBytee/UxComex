namespace UxComex.Source.Domain.Interfaces.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
    }

}
