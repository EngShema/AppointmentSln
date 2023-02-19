using Shered.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.BLL.Queries
{
    public class GetAppointmentsByDate : IRequest<List<AppointmentModel>>
    {
        public DateTime date { get; set; }
    }
}
