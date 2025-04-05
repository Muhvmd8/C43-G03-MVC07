namespace Demo.BusinessLayer.DataTransferObjects;
public static class DepartmentFactory
{
    public static Department ToEntity(this DepartmentCreateRequest request) => new()
    {

        Code = request.Code,
        CreateOn = request.CreateOn,
        Description = request.Description,
        Name = request.Name,

    };
    public static Department ToEntity(this DepartmentUpdateRequest request) => new()
    {
        Id = request.Id,
        Code = request.Code,
        CreateOn = request.CreateOn,
        Description = request.Description,
        Name = request.Name,

    };
    public static DepartmentResponse ToResponse(this Department department) => new()
    {
        Code = department.Code,
        CreateOn = DateOnly.FromDateTime(department.CreateOn),
        Description = department.Description,
        Id = department.Id,
        Name = department.Name,
    };
    public static DepartmentDetailsResponse ToDetailsResponse(this Department department) => new()
    {
        Code = department.Code,
        CreateOn = department.CreateOn,
        CreateBy = department.CreateBy,
        Description = department.Description,
        Id = department.Id,
        Name = department.Name,
        LastModifiedBy = department.LastModifiedBy,
        IsDeleted = department.IsDeleted,
        LastModifiedOn = department.LastModifiedOn

    };

    public static DepartmentUpdateRequest ToRequest(this DepartmentDetailsResponse department) => new()
    {
        Id = department.Id,
        Name = department.Name,
        Code = department.Code,
        CreateOn = department.CreateOn,
        Description = department.Description
    };
}
