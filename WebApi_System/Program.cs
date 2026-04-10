using Microsoft.EntityFrameworkCore;
using WebApi_System.Data;
using WebApi_System.EnrollmentRepository;
using WebApi_System.EnrollmentService;
using WebApi_System.ParticipantRepository;
using WebApi_System.ParticipantService;
using WebApi_System.Repositoryt;
using WebApi_System.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddTransient<IEventsRepository, EventsRepository>();
builder.Services.AddTransient<IEventsService, EventsService>();

builder.Services.AddTransient<IEnrollmentsRepository, EnrollmentsRepository>();
builder.Services.AddTransient<IEnrollmentService, EnrollmentService>();

builder.Services.AddTransient<IParticipantRepository, ParticipantRepository>();
builder.Services.AddTransient<IParticipantService, ParticipantService>();


// No Program.cs da sua WEB API
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll"); // Ativa a permissão para o Blazor acessar

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
