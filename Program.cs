namespace Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
              
                .ConfigureServices(services =>
                {
                    services.AddSingleton<jokepunches>();
                    services.AddHostedService<Worker>();
                })
                .Build();

            host.Run();
        }
    }
}