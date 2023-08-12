using Budmar_app.Models;
using Budmar_app.ViewModels.EmployeeViewModels;
using Budmar_app.ViewModels.WorkHourViewModels;

namespace Budmar_app.Services.Contracts
{
    public interface IWorkHourService
    {
        public Task<WorkHour> CreateWorkHour(WorkHourViewModel workHourViewModel);
        public Task<WorkHour> UpdateWorkHour(WorkHourViewModel workHourViewModel);
        public Task DeleteWorkHour(WorkHourViewModel workHourViewModel);
        public Task<WorkHourViewModel> GetWorkHourById(int id);
        public Task<IEnumerable<WorkHourViewModel>> GetAllWorkHours();
    }
}
