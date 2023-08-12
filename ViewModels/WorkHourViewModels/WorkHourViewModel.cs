using Budmar_app.Enums;
using Budmar_app.ViewModels.EmployeeViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Budmar_app.ViewModels.WorkHourViewModels
{
    public class WorkHourViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeViewModel? Employee { get; set; }

        [DisplayName("Początek")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [DisplayName("Koniec")]
        public DateTime EndTime { get; set; }
         
        public int? ContractId { get; set; }

        public string ContractTitle { get; set; }


        [DisplayName("Dodatek")]
        public SalarySupplement SalarySupplement { get; set; }

        public decimal DailySalary { get; set; }

        public decimal BaseHourlyWage { get; set; }
    }
}
