namespace Demo.DataAccessLayer.Models;
public class BaseType
{
    public int Id { get; set; } // PK
    public bool IsDeleted { get; set; }
    public int CreateBy { get; set; } // User Id
    public DateTime CreateOn { get; set; }
    public int LastModifiedBy { get; set; } // User Id
    public DateTime LastModifiedOn { get; set; }
}
