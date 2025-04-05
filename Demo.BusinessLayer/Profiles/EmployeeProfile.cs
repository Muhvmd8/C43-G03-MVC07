using AutoMapper;
using Demo.BusinessLayer.DataTransferObjects.Employees;
using Demo.DataAccessLayer.Models;
namespace Demo.BusinessLayer.Profiles;

internal class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        // Source => Distination
        CreateMap<Employee, EmployeeDetailsResponse>();
        CreateMap<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>();

        CreateMap<EmployeeCreateRequest, Employee>();
        CreateMap<EmployeeUpdateRequest, Employee>();
    }
}

