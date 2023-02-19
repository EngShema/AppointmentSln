using Shered.DTO;
using Shered.Models;
using MediatR;
using Appointment.BLL.Queries;
using Appointment.BLL.Command;
using Appointment.DAL.IRepository;

namespace Appointment.BLL.Handelers
{
    public class GetByDateHandler : IRequestHandler<GetAppointmentsByDate, List<AppointmentModel>>
    {
        private readonly IApointmentRepository _appointmentRepository;

        public GetByDateHandler(IApointmentRepository appointmentRepository)
        {
            _appointmentRepository= appointmentRepository;
        }

        public Task<List<AppointmentModel>> Handle(GetAppointmentsByDate request, CancellationToken cancellationToken)
        {
            var list = _appointmentRepository.GetAppointmentByTime(request.date);
            return list;
        }
    }
}
