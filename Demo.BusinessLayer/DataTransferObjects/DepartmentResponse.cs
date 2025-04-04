﻿namespace Demo.BusinessLayer.DataTransferObjects
{
    public class DepartmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateOnly CreateOn { get; set; }

    }
}
