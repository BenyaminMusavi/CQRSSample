using MediatR;
using Microsoft.EntityFrameworkCore;
using Samole.BLL.Products.Commands;
using Samole.DAL.DbContexts;
using Samole.DAL.Framework;

namespace Samole.Api.Framework;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddDbContext<SampleDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("cnn"))
        .AddInterceptors(new AddAuditFeildInterceptor()));

        // Inject Dependencies handler
        builder.Services.AddMediatR(typeof(CreateProductHandler).Assembly);

        // Add jwt
        //builder.Services.AddAuthentication("Bearer")
        //    .AddJwtBearer("Bearer", options =>
        //    {
        //        options.Authority = "https://localhost:7003";
        //        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        //        {
        //            ValidateAudience = false,
        //        };
        //    });

        builder.Services.AddControllers();

        //Add Policy
        //builder.Services.AddAuthorization(c =>
        //{
        //    c.AddPolicy("MyApi", policy =>
        //    {
        //        policy.RequireAuthenticatedUser();
        //        policy.RequireClaim("scope" , "api1");
        //    });
        //});


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        //app.UseAuthentication();
        //app.UseAuthorization();

        app.MapControllers();//.RequireAuthorization("MyApi");

        return app;
    }
}
