namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureAppConfiguration((ctx, config) =>
            {
                config.AddJsonFile("Ocelot.json");
                config.AddJsonFile("FlightDeck.json");
                config.AddJsonFile("LaunchPad.json");
            });
    }
}