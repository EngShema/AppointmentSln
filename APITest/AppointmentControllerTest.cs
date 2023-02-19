using AutoMapper;
using Shered.DTO;
using Shered.result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Appointment.BLL.Domain;
using Appointment.API.Controllers;
using Appointment.DAL.IRepository;
using Appointment.DAL.Repository;

namespace APITest
{
    public class AppointmentControllerTest
    {
        private readonly AppointmentController _appointmentController;
        private readonly AppointmentDomain _appointmentDomain;
        protected readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IApointmentRepository _apointmentRepository;
        public AppointmentControllerTest()
        {
            
            _apointmentRepository = new AppointmentRepository();
            _appointmentDomain =new AppointmentDomain(_apointmentRepository,_mapper,_mediator);
            _appointmentController= new AppointmentController(_appointmentDomain);
        }
        [Fact]
        public async void AddAppointmentAsyncTest()
        {
            var appointObj = new AppointmentDTO() { Date=new DateTime(),Name="string"
            ,Phone="string",Note="string"};
            
            var reultdata= await _appointmentController.AddAppointmentAsync(appointObj);

            var actionResult = Assert.IsType<Result<AppointmentDTO>>(reultdata);
            var createdAtActionResult = Assert.IsType<Result<AppointmentDTO>>(actionResult.Success);
            var returnValue = Assert.IsType<Result<AppointmentDTO>>(createdAtActionResult.Obj);
            Assert.Equal(appointObj, createdAtActionResult.Obj);
        }
    }
}