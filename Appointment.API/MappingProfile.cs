using AutoMapper;
using Shered.DTO;
using Shered.Models;

namespace Appointment.API
{
    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AppointmentModel, AppointmentDTO>().ReverseMap();
            

        }

    }
}
