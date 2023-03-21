using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerSync
{
    internal class DataPool
    {
        public static ConcurrentQueue<MessageObject> Messages { get; private set; }

        static DataPool()
        {
            Messages = new ConcurrentQueue<MessageObject>();
        }

        public static void CreateMessages()
        {
            new Thread(() =>
            {
                while (true)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        var message = new MessageObject();
                        message.Id = Guid.NewGuid();
                        message.CreateDate = DateTime.Now;
                        Messages.Enqueue(message);
                        Thread.Sleep(1);
                    }
                    Thread.Sleep(5000);
                }

            }).Start();
        }
    }
}
