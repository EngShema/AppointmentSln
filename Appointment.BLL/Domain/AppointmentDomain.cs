using AutoMapper;
using MediatR;
using Appointment.BLL.Queries;
using Appointment.BLL.Command;
using Appointment.BLL.Handelers;
using Appointment.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shered.result;
using Shered.DTO;
using Shered.Models;

namespace Appointment.BLL.Domain
{
    public class AppointmentDomain
    {
        protected readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IApointmentRepository _apointmentRepository;

        public AppointmentDomain(IApointmentRepository apointmentRepository,IMapper mapper, IMediator mediator) 
        { 
            _mapper = mapper;
            _mediator = mediator;
            _apointmentRepository= apointmentRepository;
        }
        public virtual async Task<Result<AppointmentDTO>> Create(AppointmentDTO dto)
        {
            Result<AppointmentDTO> result = new Result<AppointmentDTO>();

            try
            {
                var entity = _mapper.Map<AppointmentModel>(dto);
                if (entity != null)
                {
                    var appointsAtTime=await _mediator.Send(new GetAppointmentsByDate() { date = entity.Date });

                    var count =appointsAtTime.Count();
                    if (count == 2)
                    {
                        result.Success = false;
                        result.Message = "Excedd Number of Appointments";
                    }
                    else
                    {
                       
                        var appointObj = await _mediator.Send(new CreateAppointmentCommand(
                                         entity.Name, entity.Note,
                                         entity.Phone, entity.Date));

                          result.Success = true;
                        result.Message = "Created Successfully";
                        result.Obj = _mapper.Map<AppointmentDTO>(appointObj);
                    }
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message=ex.Message;
            }

            return result;
        }

    }
}
