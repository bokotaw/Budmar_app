using System.ComponentModel.DataAnnotations;

namespace Budmar_app.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public decimal HourlyWage { get; set; }

        public ICollection<WorkHour>? WorkHours { get; set; }
    }
}
