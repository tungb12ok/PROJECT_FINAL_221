using DataAccess.Models;
using Exe;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WEB.Services
{
    public class CheckingPaymentService : IHostedService, IDisposable
    {
        private readonly ILogger<TimerService> _logger;
        private Timer _timer;

        public CheckingPaymentService(ILogger<TimerService> logger)
        {
            _logger = logger;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(100));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        private void DoWork(object state)
        {
            _logger.LogInformation("Checking..."); // Thêm thông tin log theo nhu cầu
            CheckingPayment.SystemCheckingBanking();
        }
    }
}
