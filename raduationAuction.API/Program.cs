
using GraduationAuction.API.Persistance;
using GraduationAuction.API.Repositories;
using GraduationAuction.API.Services;
using Microsoft.EntityFrameworkCore;
using raduationAuction.API.DataSeeds;
using raduationAuction.API.Repositories;

namespace raduationAuction.API
{
    public class Program
    {
        public  static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers()
                   .AddJsonOptions(options =>
            {
            
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

            builder.Services.AddDbContext<webDbContext>(options=>
                {
                    var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                    options.UseSqlServer(ConnectionString);
            });

            builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IAuctionServices, AddAuctionServices>();

            //builder.Services.AddScoped<IDbInializer, DbInializer>();
            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            //var dbInializer = scope.ServiceProvider.GetRequiredService<IDbInializer>();
            //await dbInializer.InializerAsync();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapControllers();
            app.UseHttpsRedirection();

            app.UseAuthorization();

           

            app.Run();
        }
    }
}
