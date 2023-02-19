using Shered.Models;
using Appointment.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.DAL.IRepository
{
    public interface IApointmentRepository
    {
        Task<List<AppointmentModel>> GetAll();
        Task<List<AppointmentModel>> GetAppointmentByTime(DateTime date);
        Task<AppointmentModel> InsertAppointment(AppointmentModel appointment);
    }
}
