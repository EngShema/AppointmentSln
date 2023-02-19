using Shered.DTO;
using Shered.Models;
using MediatR;
using Appointment.BLL.Command;
using Appointment.DAL.IRepository;

namespace Appointment.BLL.Handelers
{
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, AppointmentModel>
    {
        private readonly IApointmentRepository _appointmentRepository;

        public CreateAppointmentHandler(IApointmentRepository appointmentRepository)
        {
            _appointmentRepository= appointmentRepository;
        }
        public async Task<AppointmentModel> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken)
        {

            var appointmentObj = new AppointmentModel()
            {
                Date = command._date,
                Name= command._name,
                Note= command._note,
                Phone= command._phone,
            
            };

            return await _appointmentRepository.InsertAppointment(appointmentObj);
        }
    }
}
