using Budmar_app.ViewModels.WorkHourViewModels;

namespace Budmar_app.ViewModels.ContractViewModels
{
    public class ContractDetalisViewModel : ContractViewModel
    {
        public ICollection<WorkHourViewModel>? WorkHours { get; set; }
    }
}
