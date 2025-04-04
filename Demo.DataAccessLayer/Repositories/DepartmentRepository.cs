using Demo.DataAccessLayer.Data.Context;namespace Demo.DataAccessLayer.Repositories;

public class DepartmentRepository(ApplicationDbContext context) // Injection
    : IDepartmentRepository
{
    private readonly ApplicationDbContext _context = context;

    // Get
    public Department? GetById(int id) => _context.Departments.Find(id);
    // Get All 
    public IEnumerable<Department> GetAll(bool withTracking = false)
        => withTracking ? _context.Departments.Where(d => !d.IsDeleted).ToList() :
        _context.Departments.AsNoTracking().Where(d => !d.IsDeleted).ToList();

    // Add
    public int Add(Department department)
    {
        _context.Departments.Add(department);
        return _context.SaveChanges();
    }

    // Update
    public int Update(Department department)
    {
        _context.Departments.Update(department);
        return _context.SaveChanges();
    }

    // Delete
    public int Delete(Department department)
    {
        _context.Departments.Remove(department);
        return _context.SaveChanges();
    }


}
