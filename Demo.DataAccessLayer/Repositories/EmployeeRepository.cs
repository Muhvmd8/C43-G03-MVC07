using Demo.DataAccessLayer.Data.Context;
namespace Demo.DataAccessLayer.Repositories;
public class EmployeeRepository(ApplicationDbContext context)
    : GenericRepository<Employee>(context),
    IEmployeeRepository
{
    private readonly ApplicationDbContext _context = context;

    public IEnumerable<Employee> GetAll(string name)
        => _context.Employees.AsNoTracking().Where(e => !e.IsDeleted && e.Name == name);
}
