using Demo.BusinessLayer.DataTransferObjects.Employees;
using Demo.DataAccessLayer.Models;
using Demo.DataAccessLayer.Repositories;
using System.Collections.Generic;
using Azure.Core;
using AutoMapper;

namespace Demo.BusinessLayer.Services
{
    public class EmployeeService(IGenericRepository<Employee> repository
        , IMapper mapper) : IEmployeeService
    // Injection
    {
        private readonly IGenericRepository<Employee> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public IEnumerable<EmployeeResponse> GetAll()
        {
            var employees = _repository.GetAll();
            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>(employees);
        }

        public EmployeeDetailsResponse? GetById(int id)
        {
            var employee = _repository.GetById(id);
            return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsResponse>(employee);
        }

        public int Add(EmployeeCreateRequest request)
        {
            var employee = _mapper.Map<EmployeeCreateRequest, Employee>(request);
            return _repository.Add(employee);
        }

        public int Update(EmployeeUpdateRequest request)
        {
            var employee = _mapper.Map<EmployeeUpdateRequest, Employee>(request);
            return _repository.Update(employee);
        }

        public bool Delete(int id)
        {
            var employee = _repository.GetById(id);
            if (employee is null) return false;

            employee.IsDeleted = true;
            return _repository.Update(employee) > 0 ? true : false;
        }

    }

}
