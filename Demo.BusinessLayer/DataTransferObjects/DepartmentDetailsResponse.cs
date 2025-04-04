namespace Demo.BusinessLayer.DataTransferObjects
{
    public class DepartmentDetailsResponse
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; }
        public int CreateBy { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }

    }
}
