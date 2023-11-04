using Microsoft.EntityFrameworkCore;
using CMBackend.DAL.ContextModels;
using CMBackend.DAL.Contexts;
using CMBackend.DAL.Repository;
using CMBackend.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
RegisterServices(builder.Services);


/*builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();*/

var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureServices(app);


/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("https://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();*/

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddCors();
    // Add services to the container.
    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
    // Configure the HTTP request pipeline.
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
