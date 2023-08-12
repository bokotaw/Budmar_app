using System.ComponentModel.DataAnnotations;

namespace Budmar_app.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset EndDate { get; set; }

        public ICollection<ContractExpense>? ContractExpenses { get; set; }
        public ICollection<WorkHour>? WorkHours { get; set; }
    }
}
