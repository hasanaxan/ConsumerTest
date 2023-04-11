using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
namespace ConsumerAsync
{
    internal class MessageProcesser
    {
     
        public void RunnerAsync()
        {
            
           DataPool.Messages.Changed += Messages_Changed;
           
        }

        private void Messages_Changed(object? sender, MessageObject message)
        {
            message.QueedDate = DateTime.Now;
            if (DataPool.Messages.TryDequeue(out message))
            {
                ProcessMessageAsync(message);
            }
        }

        async Task ProcessMessageAsync(MessageObject message)
        {
            var cpuRamUsage = GetCpuAndRamUsageForProcess();
            await Task.Delay(10);
            message.ProcessedDate = DateTime.Now;
            await DataAccess.InsertDataAsync(message, cpuRamUsage.Item1, cpuRamUsage.Item2);
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
