using Demo.DataAccessLayer.Repositories;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    public IEnumerable<Employee> GetAll(string name);
}