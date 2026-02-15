using Vektorel.Northwind.Data.Extensions;
namespace Vektorel.Nortwind.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddNorthwind();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("all", policy =>
            {
                policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
            });
        });
        //1000 satýr

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //Middleware : Ýstek sürecinde sýrasýyla iþlenen adýmlar
        app.UseCors("all");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();


        app.Run();
    }
}
