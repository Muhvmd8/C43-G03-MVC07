using Demo.BusinessLayer.DataTransferObjects;

namespace Demo.BusinessLayer.Services
{
    public interface IDepartmentService
    {
        int Add(DepartmentCreateRequest request);
        bool Delete(int id);
        IEnumerable<DepartmentResponse> GetAll();
        DepartmentDetailsResponse? GetById(int id);
        int Update(DepartmentCreateRequest request);
    }
}