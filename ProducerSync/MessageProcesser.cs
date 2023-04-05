using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsumerSync
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
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
        public void Runner()
        {
                new Thread(() =>
                {
                    ConsumeMessage();
                }).Start();
        }
        private void ConsumeMessage()
        {
            while (true)
            {
                if (DataPool.Messages.TryPeek(out MessageObject message))
                {
                    message.QueedDate = DateTime.Now;
                    if (DataPool.Messages.TryDequeue(out message))
                    {
                        ProcessMessage(message);
                    }
                }
            }
        }
        private void ProcessMessage(MessageObject message)
        {
            float cpu = cpuCounter.NextValue();
            while (cpu == 0)
            {
                cpu = cpuCounter.NextValue();
            }
            var totalRam = 8 * 1024;
            var ram = ((totalRam - ramCounter.NextValue()) / totalRam) * 100;
            Thread.Sleep(10);
            message.ProcessedDate = DateTime.Now;
            DataAccess.InsertData(message, cpu, ram);
        }
    }
}
