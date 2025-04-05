using Demo.DataAccessLayer.Data.Context;
namespace Demo.DataAccessLayer.Repositories;
public class GenericRepository<TEntity>(ApplicationDbContext context) 
    : IGenericRepository<TEntity>
    where TEntity : BaseType
{
    private readonly ApplicationDbContext _context = context;

    public IEnumerable<TEntity> GetAll(bool withTracking = false) =>
    withTracking ? _context.Set<TEntity>().Where(e => !e.IsDeleted) :
    _context.Set<TEntity>().AsNoTracking().Where(e => !e.IsDeleted);
    public TEntity? GetById(int id) => _context.Set<TEntity>().Find(id);
    public int Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        return _context.SaveChanges();
    }
    public int Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        return _context.SaveChanges();
    }
    public int Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        return _context.SaveChanges();
    }

}
