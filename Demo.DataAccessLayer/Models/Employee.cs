﻿namespace Demo.DataAccessLayer.Models;
public class Employee : BaseType
{
    public string Name { get; set; } = null!;
    public int? Age { get; set; }
    public string? Address { get; set; }
    public decimal Salary { get; set; }
    public bool IsActive { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly HiringDate { get; set; }
    public Gender Gender { get; set; }
    public EmployeeType EmployeeType { get; set; }

}
