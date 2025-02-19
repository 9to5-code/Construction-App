using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add Ocelot to the service collection
        services.AddOcelot();
        services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            // Use developer exception page in development mode
            app.UseDeveloperExceptionPage();
        }

        // Middleware for routing requests
        app.UseRouting();
          app.UseCors("AllowAllOrigins");

        // Configure endpoints for the API gateway
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();  // Maps the controllers, if you have any
        });

        // Use Ocelot middleware to handle API gateway functionality
        app.UseOcelot().Wait();
    }
}
