using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerSync
{
    internal class DataPool
    {
        public static ConcurrentQueue<MessageObject> Messages { get; private set; }

        static DataPool()
        {
            Messages = new ConcurrentQueue<MessageObject>();
        }

        public static void CreateMessages(int messageCount)
        {
            new Thread(() =>
            {
                for (int i = 0; i < messageCount; i++)
                {
                    var message = new MessageObject();
                    message.Id = Guid.NewGuid();
                    message.CreateDate = DateTime.Now;
                    Messages.Enqueue(message);
                }
            }).Start();
        }
    }
}
