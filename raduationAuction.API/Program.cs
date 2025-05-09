
using GraduationAuction.API.Persistance;
using GraduationAuction.API.Repositories;
using GraduationAuction.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using raduationAuction.API.AuthServices;
using raduationAuction.API.DataSeeds;
using raduationAuction.API.Model;
using raduationAuction.API.Repositories;
using System.Reflection;
using System.Text;

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

            //builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
            //builder.Services.AddScoped<IItemRepository, ItemRepository>();
            //builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            //builder.Services.AddScoped<IAuctionServices, AddAuctionServices>();

            //builder.Services.AddScoped<IDbInializer, DbInializer>();


            //builder.Services.AddFluentValidationAutoValidation()
            //.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

           builder.Services.AddSingleton<IJwtProvider, JwtProvider>();

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<webDbContext>();

           builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("J7MfAb4WcAIMkkigVtIepIILOVJEjAcB")),
                    ValidIssuer = "SurveyBasketApp",
                    ValidAudience = "SurveyBasketApp users"
                };
            });
            var app = builder.Build();

           // using var scope = app.Services.CreateScope();
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
