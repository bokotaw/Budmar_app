using Budmar_app.Models;
using Microsoft.EntityFrameworkCore;



namespace Budmar_app.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ContractExpense> ContractExpenses { get; set; }
        public DbSet<WorkHour> WorkHours { get; set; }

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(bulider => { bulider.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                      
            modelBuilder.Entity<Contract>()
                .HasMany(c => c.ContractExpenses)
                .WithOne(ce =>  ce.Contract)
                .HasForeignKey(ce => ce.ContractId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contract>()
                .HasMany(c => c.WorkHours)
                .WithOne(wh => wh.Contract)
                .HasForeignKey(wh => wh.ContractId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WorkHours)
                .WithOne(wh => wh.Employee)
                .HasForeignKey(wh => wh.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .Property(e => e.HourlyWage)
                .HasColumnType("decimal(19, 2)");

            modelBuilder.Entity<WorkHour>()
                .Property(wh => wh.DailySalary)
                .HasColumnType("decimal(19, 2)");

            modelBuilder.Entity<WorkHour>()
                .Property(wh => wh.BaseHourlyWage)
                .HasColumnType("decimal(19,2)");

            modelBuilder.Entity<ContractExpense>()
                .Property(ce => ce.Cost)
                .HasColumnType("decimal(19, 2)");         
            
        }

   
    }
}
