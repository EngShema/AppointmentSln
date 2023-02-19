using Shered.Models;
using Microsoft.EntityFrameworkCore;
using Appointment.DAL.Data;
using Appointment.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.DAL.Repository
{
    public class AppointmentRepository : IApointmentRepository  {

        private readonly PostgreDBContext _context;

        public AppointmentRepository()
        {
        }

        public AppointmentRepository(PostgreDBContext context)
        {
            _context= context;
        }
        public async Task<List<AppointmentModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task< List<AppointmentModel>> GetAppointmentByTime(DateTime date)
        {
            var list =await _context.Appointments.Where(x => x.Date == date).ToListAsync();
            return list;
        }

        public async Task<AppointmentModel> InsertAppointment(AppointmentModel appointment)
        {
            var result=await _context.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
