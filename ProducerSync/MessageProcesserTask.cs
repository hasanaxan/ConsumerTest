using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerSync
{
    internal class MessageProcesserTask
    {
        public void Runner()
        {
            new Thread(() =>
            {
                ConsomeMessage();

            }).Start();
        }

        private void ConsomeMessage()
        {
            while (true)
            {
                MessageObject message;
                if(DataPool.Messages.TryPeek(out message))
                {
                    message.QueedDate= DateTime.Now;
                    Thread.Sleep(200);
                    DataPool.Messages.TryDequeue(out message);
                    message.ProcessedDate = DateTime.Now;
                    Console.WriteLine("Consumed message {0}, QueedDate:{1}, ProcessedDate:{1}", message.Id,message.QueedDate,message.ProcessedDate);
                    Console.WriteLine("Quee message count {0}",DataPool.Messages.Count);
                   

                }

            }
        }
    }
}
