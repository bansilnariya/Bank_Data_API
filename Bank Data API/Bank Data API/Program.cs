using Bank_Data_API.Service;
using Bank_Data_API.Setting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BankDBSettings>(builder.Configuration.GetSection("BankDataBase"));

builder.Services.AddSingleton<IBankService,BankDataService>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
