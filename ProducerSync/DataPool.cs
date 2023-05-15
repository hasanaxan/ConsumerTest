using System.Collections.Concurrent;
namespace ConsumerSync
{
    internal class DataPool
    {
        public static ConcurrentQueue<MessageObject> Messages { get; private set; }
        static DataPool()
        {
            Messages = new();
        }
        public static void CreateMessages(int messageCount)
        {
            for (int i = 0; i < messageCount; i++)
            {
                MessageObject message = new()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    MessageGroup = messageCount,
                    MessageOrder = i + 1
                };
                Messages.Enqueue(message);
            }
        }
    }
}
