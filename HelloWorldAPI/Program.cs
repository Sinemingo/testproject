using FluentValidation;
using HelloWorld.Business.Dtos;
using HelloWorld.Business.MappingProfiles;
using HelloWorld.Business.Services.Abstract;
using HelloWorld.Business.Services.Concrete;
using HelloWorld.Business.Validators;
using HelloWorld.Data.Abstract;
using HelloWorld.Data.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(PersonProfile));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMemoryCache();

builder.Services.AddSingleton<IValidator<PersonDto>, PersonDtoValidator>();
builder.Services.AddSingleton<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
