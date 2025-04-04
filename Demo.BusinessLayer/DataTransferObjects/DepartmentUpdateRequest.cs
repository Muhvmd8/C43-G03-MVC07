﻿namespace Demo.BusinessLayer.DataTransferObjects
{
    public class DepartmentUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; }
    }
}
