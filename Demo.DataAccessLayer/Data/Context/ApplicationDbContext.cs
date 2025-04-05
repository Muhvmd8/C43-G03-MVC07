namespace Demo.DataAccessLayer.Data.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     // optionsBuilder.UseSqlServer("server=LAPTOP-I0R4OA4K\\MYSQLSERVER;Database=DemoMVCG03;Trusted_Connection=true;TrustServerCertificate=true;");
        // }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
