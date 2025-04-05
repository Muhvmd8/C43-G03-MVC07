using Demo.BusinessLayer.DataTransferObjects.Employees;

namespace Demo.BusinessLayer.Services
{
    public interface IEmployeeService
    {
        int Add(EmployeeCreateRequest request);
        bool Delete(int id);
        IEnumerable<EmployeeResponse> GetAll();
        EmployeeDetailsResponse? GetById(int id);
        int Update(EmployeeUpdateRequest request);
    }
}