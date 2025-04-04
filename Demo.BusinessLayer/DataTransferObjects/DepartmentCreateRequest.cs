namespace Demo.BusinessLayer.DataTransferObjects;
public class DepartmentCreateRequest
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreateOn { get; set; }
}
