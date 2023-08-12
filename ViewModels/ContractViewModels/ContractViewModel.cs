using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Budmar_app.ViewModels.ContractViewModels
{
    public class ContractViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę kontraktu")]
        [DisplayName("Nazwa kontraktu")]
        public string Title { get; set; }

        [DisplayName("Opis")]
        public string? Description { get; set; }

        [DisplayName("Adres")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Podaj datę rozpoczęcia kontraktu")]
        [DisplayName("Początek")]
        [DataType(DataType.Date)]
        public DateTimeOffset StartDate { get; set; }

        [DisplayName("Koniec")]
        [DataType(DataType.Date)]
        public DateTimeOffset EndDate { get; set; }
    }
}
