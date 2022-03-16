namespace BlazorCompuTronica
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddScoped<IClienteService, ClienteService>();


            //Conecction DB
            var SqlConnectionConfiguration = new SqlConnectionConfiguration(Configuration.GetConnectionString("SqlDBContext"));
            //Patrón Singleton
            services.AddSingleton(SqlConnectionConfiguration);
        }
    }
}
