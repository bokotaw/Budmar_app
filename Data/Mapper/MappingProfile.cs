using AutoMapper;
using Budmar_app.Models;
using Budmar_app.ViewModels.ContractViewModels;
using Budmar_app.ViewModels.EmployeeViewModels;
using Budmar_app.ViewModels.WorkHourViewModels;

namespace Budmar_app.Data.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>();

            CreateMap<Employee, EmployeeViewModel>().ReverseMap();

            CreateMap<ContractViewModel, Contract>();
            CreateMap<Contract, ContractViewModel>().ReverseMap();

            CreateMap<WorkHourViewModel, WorkHour>();
            CreateMap<WorkHour, WorkHourViewModel>();
        }
    }
}
