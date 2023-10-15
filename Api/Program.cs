
using Api.Data.Chat;
using Api.Data.Repositories;
using Api.Data.Repositories.Interface;
using huutokauppa.Data.context;
using huutokauppa.Data.Models;
using huutokauppa.Data.Repositories;
using huutokauppa.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<IMessage, MessageRepository>();

builder.Services.AddDbContext<Datacontext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddCors();
builder.Services.AddSignalR(opt =>
{
    opt.EnableDetailedErrors = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapHub<ChatHub>("/chatHub");

// });
app.MapHub<ChatHub>("/chatHub");
app.MapControllers();

app.Run();
