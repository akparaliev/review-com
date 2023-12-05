using Microsoft.EntityFrameworkCore;
using ReviewCom.Services;
using ReviewComDAL;
using ReviewComDAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Configure dependence injections. 
builder.Services.AddSingleton<ILoggingService, LoggingService>();
builder.Services.AddDbContext<ApiContext>(options => options.UseInMemoryDatabase(databaseName: "ReviewComDb"));
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<CompanyRepository>();
builder.Services.AddScoped<ReviewRepository>();

// Add services to the container.
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

// Configure the routing
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>{_ = endpoints.MapControllers();});

app.Run();