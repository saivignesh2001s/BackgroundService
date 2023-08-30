namespace Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly jokepunches _jokepunches;

        public Worker(ILogger<Worker> logger,jokepunches jokepunches)=>(_logger,_jokepunches)=(logger,jokepunches);
       

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
          
               
                    using (FileStream fs = new FileStream(Path.Combine("log.txt"), FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(_jokepunches.getjoke());
                        }

                    }
                
               
                _logger.LogInformation(_jokepunches.getjoke()+" "+DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            using (FileStream fs = new FileStream(Path.Combine("log.txt"), FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Worker starting at:" + DateTimeOffset.Now);
                }

            }
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            using (FileStream fs = new FileStream(Path.Combine("log.txt"), FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Worker stoping at:" + DateTimeOffset.Now);
                }

            }
            _logger.LogInformation("Stopped");
            

            return base.StopAsync(cancellationToken);
        }
    }
}