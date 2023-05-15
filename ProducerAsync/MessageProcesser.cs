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

            MessageObject message;
            while (DataPool.Messages.TryPeek(out message))
            {
                message.QueedDate = DateTime.Now;
                if (DataPool.Messages.TryDequeue(out message))
                {
                    ProcessMessageAsync(message,false,true);
                }
            }

        }
        public void ParallelRunnerAsync()
        {
            Parallel.ForEach(DataPool.Messages, new ParallelOptions { MaxDegreeOfParallelism = DataPool.Messages.Count },
            message =>
            {

                if (DataPool.Messages.TryDequeue(out message))
                {
                    message.QueedDate = DateTime.Now;
                    ProcessMessageAsync(message, true, true);
                }
            });
        }


        async Task ProcessMessageAsync(MessageObject message, bool isParallel, bool isAsync)
        {
           setCpuAndRamUsageForProcess(message);
            message.IsParallel = isParallel;
            message.IsAsync = isAsync;
            await Task.Delay(10);
            message.ProcessedDate = DateTime.Now;
            await DataAccess.InsertDataAsync(message);
        }

        private void setCpuAndRamUsageForProcess(MessageObject message)
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
            message.Ram = ram;
            message.Cpu = cpuUsageTotal * 100;
            //return Tuple.Create(cpuUsageTotal * 100, ram);
        }
    }
}
