
namespace JabilMoviesAPI.Services.Interfaces
{
    public interface IService<TEntity, TEntityInsert, TEntityUpdate> where TEntity: class 
                                                                      where TEntityInsert:class 
                                                                      where TEntityUpdate : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Create(TEntityInsert TEntityInsert);
        Task<bool> Update(int id, TEntityUpdate TEntityUpdate);
        Task<bool> Delete(int id);
    }
}
