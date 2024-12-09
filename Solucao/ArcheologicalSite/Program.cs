using ArcheologicalSite.Context;
using ArcheologicalSite.Repositories;
using ArcheologicalSite.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUnitOfWork, AppUnitOfWork>();

builder.Services.AddScoped<IArcheologistRepository, ArcheologistRepository>();
builder.Services.AddScoped<IArcheologistService, ArcheologistService>();

builder.Services.AddScoped<IArtefactRepository, ArtefactRepository>();
builder.Services.AddScoped<IArtefactService, ArtefactService>();

builder.Services.AddScoped<IFossilRepository, FossilRepository>();
builder.Services.AddScoped<IFossilService, FossilService>();

builder.Services.AddScoped<IPaleontologistRepository, PaleontologistRepository>();
builder.Services.AddScoped<IPaleontologistService, PaleontologistService>();

builder.Services.AddScoped<ICsvImportService, CsvImportService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString(nameof(AppDbContext))));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
