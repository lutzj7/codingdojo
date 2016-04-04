using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueCodingDojo
{
    public class PriorityQueue<T> 
    {
        SortedDictionary<int, Queue<T>> _queue = new SortedDictionary<int, Queue<T>>();

        public void Enqueue(T element, int priority)
        {
            if (!_queue.ContainsKey(priority))
            {
                _queue.Add(priority, new Queue<T>());
            }

            _queue[priority].Enqueue(element);
        }

        public T Dequeue()
        {
            return Dequeue(_queue.Last().Key);
        }

        public T Dequeue(int priority)
        {
            var res = _queue[priority].Dequeue();

            if (_queue[priority].Count == 0)
                _queue.Remove(priority);

            return res;
        }

        public void Clear()
        {
            _queue.Clear();
        }

        public int Count()
        {
            return _queue.Values.Sum(v => v.Count);
        } 
    } 
}
