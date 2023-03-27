using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerSync
{
    internal class MessageProcesserTask
    {

        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        public MessageProcesserTask()
        {
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
        public void Runner(int threadCount)
        {
            for (int i = 0; i < threadCount; i++)
            {
                new Thread(() =>
                {
                    ConsomeMessage();

                }).Start();
            }

        }

        private void ConsomeMessage()
        {
            while (true)
            {
                MessageObject message;
                //kuyruktan bir mesajı almayı dene
                if (DataPool.Messages.TryPeek(out message))
                {
                    message.QueedDate = DateTime.Now;
                    //mesajı kuyruktan kaldırmayı dene ve işle
                    if (DataPool.Messages.TryDequeue(out message))
                    {
                        Test(message);
                    }
                }

            }
        }
        private void Test(MessageObject message)
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
