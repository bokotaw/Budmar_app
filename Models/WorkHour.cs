using Budmar_app.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budmar_app.Models
{
    public class WorkHour
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }  
        
        public SalarySupplement SalarySupplement { get; set; }

        [Required]
        [ForeignKey(nameof(Contract))]
        public int ContractId { get; set; }
        public Contract? Contract { get; set; }

        [Required]
        public decimal BaseHourlyWage { get; set; }

        [Required]
        public decimal DailySalary { get; set; }
        

    }
}
