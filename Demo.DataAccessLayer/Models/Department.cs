﻿namespace Demo.DataAccessLayer.Models;
public class Department : BaseType
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;

}
