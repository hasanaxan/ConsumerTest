using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
namespace ConsumerAsync
{
    internal class MessageProcesser
    {
        private readonly PerformanceCounter cpuCounter;
        private readonly PerformanceCounter ramCounter;
        public MessageProcesser()
        {
            cpuCounter = new PerformanceCounter
            {
                CategoryName = "Processor",
                CounterName = "% Processor Time",
                InstanceName = "_Total"
            };
            ramCounter = new PerformanceCounter("Memory", "Available MBytes",true);
        }
        public Task RunnerAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                ConsomeMessage();
            });
        }
        private void ConsomeMessage()
        {
            while (true)
            {
                if (DataPool.Messages.TryPeek(out MessageObject message))
                {
                    message.QueedDate = DateTime.Now;
                    //mesajı kuyruktan kaldırmayı dene ve işle
                    if (DataPool.Messages.TryDequeue(out message))
                    {
                        ProcessMessageAsync(message);
                    }
                }
            }
        }
        async Task ProcessMessageAsync(MessageObject message)
        {
            float cpu = cpuCounter.NextValue();
            while (cpu == 0)
            {
                cpu = cpuCounter.NextValue();
            }
            var totalRam = 8 * 1024;
            var ram = ((totalRam - ramCounter.NextValue()) / totalRam)*100;
            await Task.Delay(10);
            message.ProcessedDate = DateTime.Now;
            DataAccess.InsertDataAsync(message, cpu, ram);
            //Console.WriteLine("Consumed message {0},{3},{4} , QueedDate:{1}, ProcessedDate:{2}", message.Id, message.QueedDate, message.ProcessedDate, cpu, ram);
        }
    }
}
