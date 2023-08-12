using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Budmar_app.ViewModels.EmployeeViewModels
{
    public class EmployeeViewModel
    {
        [Required] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz imię pracownika")]
        [DisplayName("Imię pracownika")]
        [Display(Prompt = "Imię")]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Wpisz nazwisko pracownika")]
        [DisplayName("Nazwisko pracownika")]
        [Display(Prompt = "Nazwisko")]
        [MaxLength(100)]
        public string? LastName { get; set; }

        [DisplayName("Stawka godzinowa")]
        public decimal? HourlyWage { get; set; }

        [Required(ErrorMessage = "Podaj stawkę godzinową")]
        [DisplayName("Stawka godzinowa")]
        [Display(Prompt = "0,00")]
        public string? HourlyWageString { get; set; }
    }
}
