//using FastRouting.Context;
//using FastRouting.Repositories;
//using FastRouting.Services;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
////my injections!

//builder.Services.AddServices();


//builder.Services.AddDbContext<IContext, DataContext>(options =>
//{
//    options.UseSqlServer("name=ConnectionStrings:FastRouting");
//    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

//}, ServiceLifetime.Scoped);
/////////////////////
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//                      policy =>
//                      {
//                          policy.AllowAnyOrigin()
//                          .AllowAnyHeader()
//                          .AllowAnyMethod();
//                      });
//});
/////////////////////////
//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//////////////////
// app.UseCors(MyAllowSpecificOrigins);
///////////////////////
/////

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using FastRouting.Context;
using FastRouting.Repositories;
using FastRouting.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//my injections!

builder.Services.AddServices();


builder.Services.AddDbContext<IContext, DataContext>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:FastRouting");
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

}, ServiceLifetime.Scoped);
///////////////////
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
///////////////////////







builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.Limits.MaxRequestBodySize = 9999999; // Set the maximum request body size in bytes
});

var app = builder.Build();
// Configure the server options


//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
//////////////////
// app.UseCors(MyAllowSpecificOrigins);
///////////////////////
/////

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello World!");
//});

app.Run();
