namespace ToDoListWebApp.WebApi;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseHsts();
        }

        if (builder.Environment.IsDevelopment())
        {
            app.UseSwaggerUI(options =>
            {
               options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
               options.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        // app.UseAuthentication();
        // app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();


        app.Run();
    }
}