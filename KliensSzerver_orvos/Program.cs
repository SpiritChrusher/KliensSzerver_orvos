var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPatientRepository, PatientRepository>();

builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddDbContext<PatientContext>(optons =>
    optons.UseSqlServer(builder.Configuration.GetConnectionString("ServerDb"))
);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();