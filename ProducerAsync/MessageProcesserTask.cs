﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerAsync
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
            ramCounter = new PerformanceCounter("Memory", "Available MBytes",true);
        }
        public Task Runner()
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
                MessageObject message;
                if (DataPool.Messages.TryPeek(out message))
                {
                    message.QueedDate = DateTime.Now;
                    //mesajı kuyruktan kaldırmayı dene ve işle
                    if (DataPool.Messages.TryDequeue(out message))
                    {
                        TestAsync(message);

                    }



                }

            }
        }

        async Task TestAsync(MessageObject message)
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