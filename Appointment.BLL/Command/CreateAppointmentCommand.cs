using Shered.DTO;
using Shered.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.BLL.Command
{
    public class CreateAppointmentCommand : IRequest<AppointmentModel>
    {
        public string _name { get; set; }
        public string _note { get; set; }
        public DateTime _date { get; set; }
        public string _phone { get; set; }

        public CreateAppointmentCommand(string name, string note, string phone, DateTime date)
        {
            _date = date;
            _name = name;
            _note = note;
            _phone = phone;
        }
    }
}
