using FluentValidation;
using HelloWorld.Business.Dtos;
using HelloWorld.Business.MappingProfiles;
using HelloWorld.Business.Services.Abstract;
using HelloWorld.Business.Services.Concrete;
using HelloWorld.Business.Validators;
using HelloWorld.Cache;
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
builder.Services.AddScoped<IMemoryCacheProviderService, MemoryCacheProviderService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
