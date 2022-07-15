using Company.Core.Repositories;
using Company.Core.UnitOfWorks;
using Company.Repository.AppDbContexts;
using Company.Repository.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Company.Core;
using Microsoft.AspNetCore.Mvc;
using Company.Core.Services;
using Company.Service.Mappings;
using Company.Repository.Repositories;
using Company.Service.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
builder.Services.AddControllers().AddNewtonsoftJson();
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    
builder.Services.AddScoped<IGenericUnitOfWork,UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddAutoMapper(typeof(MapProfiles));

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<ITopDepartmentRepository, TopDepartmentRepository>();
builder.Services.AddScoped<ITopDepartmentService, TopDepartmentService>();

builder.Services.AddScoped<ISubdepartmentRepository, SubDepartmentRepository>();
builder.Services.AddScoped<ISubdepartmentService, SubdepartmentService>();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });

});



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
