using Ardalis.Specification;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task Save();
        Task Insert(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task Delete(object id);
        Task Delete(TEntity entityToDelete);
        Task Update(TEntity ententityToUpdate);
        Task<TEntity?> GetItemBySpec(ISpecification<TEntity> specification);
        Task<IEnumerable<TEntity>> GetListBySpec(ISpecification<TEntity> specification);
        Task<TEntity?> GetByID(object id);
        Task<int> GetCountRows();
        Task<int> GetCountBySpec(ISpecification<TEntity> specification);
    }
}
