using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Appointment.DAL.Data;
using Appointment.DAL.IRepository;
using Appointment.DAL.Repository;
using System.Reflection;
using MediatR;
using Appointment.API;
using Appointment.BLL.Handelers;
using Shered.Models;
using Appointment.BLL.Domain;

var builder = WebApplication.CreateBuilder(args);

#region DBConection

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<PostgreDBContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion



#region Services

//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IApointmentRepository,AppointmentRepository>();
builder.Services.AddScoped<AppointmentDomain>();

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("Appointment.BLL"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
