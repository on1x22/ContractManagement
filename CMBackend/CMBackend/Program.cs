using Microsoft.EntityFrameworkCore;
using CMBackend.DAL.Contexts;
using CMBackend.DAL.Repository;
using CMBackend.Domain;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

ConfigureServices(app);

app.Run();


void RegisterServices(IServiceCollection services)
{
    services.AddCors();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddDbContext<ContractsManagementDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("ContractsManagementDB"));
    });
    services.AddTransient<IContractsManagementRepository, ContractsManagementRepository>();
    services.AddTransient<IImportService, ImportService>();
    services.AddTransient<IContractsService, ContractsService>();
}

void ConfigureServices(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(builder => builder.WithOrigins("https://localhost:4200"));

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}
