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
            DataPool.Messages.Changed += Messages_Changed;
        }

        private void Messages_Changed(object? sender, MessageObject message)
        {
            message.QueedDate = DateTime.Now;
            if (DataPool.Messages.TryDequeue(out message))
            {
                ProcessMessage(message);
            }
        }
        //private void ConsumeMessage()
        //{
        //    while (true)
        //    {
        //        if (DataPool.Messages.TryPeek(out MessageObject message))
        //        {
        //            message.QueedDate = DateTime.Now;
        //            if (DataPool.Messages.TryDequeue(out message))
        //            {
        //                ProcessMessage(message);
        //            }
        //        }
        //    }
        //}
        private void ProcessMessage(MessageObject message)
        {
            var cpuRamUsage = GetCpuAndRamUsageForProcess();
            Thread.Sleep(10);
            message.ProcessedDate = DateTime.Now;
            DataAccess.InsertData(message, cpuRamUsage.Item1, cpuRamUsage.Item2);
        }

        private Tuple<double, double> GetCpuAndRamUsageForProcess()
        {
            var startTime = DateTime.UtcNow;
            var proc = Process.GetCurrentProcess();
            var startCpuUsage = proc.TotalProcessorTime;
            var endTime = DateTime.UtcNow;
            var endCpuUsage = proc.TotalProcessorTime;
            var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
            var totalMsPassed = (endTime - startTime).TotalMilliseconds;
            var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);
            var ram = proc.WorkingSet64 / 1024.0 / 1024.0;
            return Tuple.Create(cpuUsageTotal * 100, ram);
        }
    }
}
