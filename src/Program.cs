#region Dependencies

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CpuService>();
builder.Services.AddSingleton<MemoryService>();
builder.Services.AddSingleton<ThreadService>();

var app = builder.Build();

app.UseHttpsRedirection();

#endregion Dependencies

app.MapGet("/cpu", (CpuService service) => ExecuteService(service));

app.MapGet("/memory", (MemoryService service) => ExecuteService(service));

app.MapGet("/threads", (ThreadService service) => ExecuteService(service));

static IResult ExecuteService<T>(T service) where T : IService
{
    service.Run();
    return Results.Ok();
}

app.Run();