using todoApi.AppDataContext;
using todoApi.Middleware;
using todoApi.Models;

namespace todoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.Configure<DbSetting>(builder.Configuration.GetSection("DbSetting"));
            builder.Services.AddSingleton<TodoDbContext>();


            //OBJECT TO OBJECT MAPPING (AUTOMAPPER)
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //GLOBAL EXCEPTION HANDLING MIDDLEWARE
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
            builder.Services.AddLogging();

            var app = builder.Build();

            {
                using var scope = app.Services.CreateScope();
                var context = scope.ServiceProvider;
            }
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
        }
    }
}
