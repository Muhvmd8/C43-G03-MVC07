namespace Demo.BusinessLayer.Services
{
    public class DepartmentService(IDepartmentRepository repository) : IDepartmentService
    // Injection
    {
        private readonly IDepartmentRepository _repository = repository;

        public IEnumerable<DepartmentResponse> GetAll()
        {
            var departments = _repository.GetAll();
            return departments.Select(department => department.ToResponse());
        }

        public DepartmentDetailsResponse? GetById(int id)
        {
            var department = _repository.GetById(id);
            return department is null ? null : department.ToDetailsResponse();
        }

        public int Add(DepartmentCreateRequest request)
        {
            var department = request.ToEntity();
            return _repository.Add(department);
        }

        public int Update(DepartmentCreateRequest request)
        {
            var department = request.ToEntity();
            return _repository.Update(department);
        }

        public bool Delete(int id)
        {
            var department = _repository.GetById(id);
            if (department is null) return false;

            return _repository.Delete(department) > 0 ? true : false;
        }


    }
}
