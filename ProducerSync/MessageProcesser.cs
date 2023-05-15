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
        public void Runner()
        {
            MessageObject message;
            while (DataPool.Messages.TryPeek(out message))
            {
                message.QueedDate = DateTime.Now;
                if (DataPool.Messages.TryDequeue(out message))
                {
                    ProcessMessage(message,false, false);
                }
            }

        }
        public void ParallelRunner()
        {
            Parallel.ForEach(DataPool.Messages, new ParallelOptions { MaxDegreeOfParallelism = DataPool.Messages.Count },
            message =>
            {

                if (DataPool.Messages.TryDequeue(out message))
                {
                    message.QueedDate = DateTime.Now;
                    ProcessMessage(message,true,false);
                }
            });
        }

       
        private void ProcessMessage(MessageObject message,bool isParallel,bool isAsync)
        {
            setCpuAndRamUsageForProcess(message);
            message.IsParallel = isParallel;
            message.IsAsync = isAsync;
            Thread.Sleep(10);
            message.ProcessedDate = DateTime.Now;
            DataAccess.InsertData(message);
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
