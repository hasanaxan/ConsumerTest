using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerAsync
{
    internal class MyQueue<T>
    {
     
        private readonly ConcurrentQueue<T> queue = new ConcurrentQueue<T>();
        public event EventHandler<T>? Changed;

        protected void OnChanged(T item)
        {
            if (Changed is not null) Changed(this, item);
        }

        public void Enqueue(T item)
        {
            queue.Enqueue(item);
            OnChanged(item);
        }
        public virtual bool TryDequeue(out T result)
        {
           return queue.TryDequeue(out result);
            
        }

        public virtual bool TryPeek(out T result)
        {
            return queue.TryPeek(out result);
        }
    }
}
