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
        //public static ConcurrentQueue<MessageObject> Messages { get; private set; }
        public static MyQueue<MessageObject> Messages { get; private set; }
        static DataPool()
        {
            Messages = new();
        }
        public static void CreateMessages(int messageCount)
        {
            new Thread(() =>
            {
                for (int i = 0; i < messageCount; i++)
                {
                    MessageObject message = new()
                    {
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.Now,
                        MessageGroup = messageCount
                    };
                    Messages.Enqueue(message);
                }
            }).Start();
        }
    }
}
