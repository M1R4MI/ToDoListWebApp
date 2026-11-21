namespace ToDoList.WebApi
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            var app = builder.Build();

            if (app.Environment.EnvironmentName == "Local")
            {
                // TODOD: Add a swagger for manual testing of the backend
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // app.UseAuthentication();
            // app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}