using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsumerAsync
{
    internal class DataPool
    {
        public static ConcurrentQueue<MessageObject> Messages { get; private set; }
        static DataPool()
        {
            Messages = new ConcurrentQueue<MessageObject>();
        }
        public static Task CreateMessagesAsync(int messageCount)
        {
            return Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < messageCount; i++)
                {
                    var message = new MessageObject
                    {
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.Now
                    };
                    Messages.Enqueue(message);
                }
            });
            
        }
    }
}
