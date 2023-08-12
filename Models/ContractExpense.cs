using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budmar_app.Models
{
    public class ContractExpense
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [ForeignKey(nameof(Contract))]
        public int ContractId { get; set; }
        public Contract Contract { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        [StringLength(255)]
        public string? Description { get; set; }


    }
}
