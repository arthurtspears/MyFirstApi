using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbConnection.Settings;
using MyFirstApi.EFCore.Data;

namespace MyFirstApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

            builder.Services.AddScoped<MyFirstApi.EFCore.Services.ProductService>();

            builder.Services.AddScoped<MyFirstApi.EFCore.Services.CategoryService>();

            builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

            builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var mongoDbSettings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new MongoClient(mongoDbSettings.ConnectionString);
            });

            builder.Services.AddSingleton<IMongoDatabase>(sp =>
            {
                var mongoDbSettings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                var mongoClient = sp.GetRequiredService<IMongoClient>();
                return mongoClient.GetDatabase(mongoDbSettings.DatabaseName);
            });

            builder.Services.AddScoped<MongoDbConnection.Services.ProductServices>();

            builder.Services.AddScoped<MongoDbConnection.Services.ConnectionService>();

            builder.Services.AddHttpLogging(options =>
            {
                options.LoggingFields = HttpLoggingFields.RequestPath | 
                                        HttpLoggingFields.RequestMethod;
            });

            var app = builder.Build();

            app.UseHttpLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
