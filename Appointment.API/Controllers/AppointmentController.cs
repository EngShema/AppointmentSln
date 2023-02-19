using Shered.DTO;
using Shered.result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Appointment.BLL.Domain;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentDomain _appointmentDomain;
        public AppointmentController(AppointmentDomain appointmentDomain)
        {
           _appointmentDomain= appointmentDomain;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<Result<AppointmentDTO>> AddAppointmentAsync(AppointmentDTO appoint)
        {
            var obj = new Result<AppointmentDTO>();
            if (appoint!=null)
            {
                obj = await _appointmentDomain.Create(appoint);

            }
            else
            {
                obj.Message = "empty object";
                obj.Success = false;
            }
            return obj;
        }

    }
}