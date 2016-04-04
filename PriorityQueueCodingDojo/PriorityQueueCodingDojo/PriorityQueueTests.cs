using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PriorityQueueCodingDojo
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void CountIsZeroAfterInit()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            Assert.AreEqual(0, pq.Count()); 
        }

        [TestMethod]
        public void CountAfterEnqueueIsOne()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Enqueue(1, 5);
            Assert.AreEqual(1, pq.Count());
        }

        [TestMethod]
        public void EnqueueSortsByPrio()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Enqueue(2, 3);
            pq.Enqueue(1, 5);

            Assert.AreEqual(2, pq.Count());

            int res = pq.Dequeue();

            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void DequeueAllElements()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Enqueue(2, 3);
            pq.Enqueue(1, 5);
            pq.Enqueue(1, 5);

            Assert.AreEqual(3, pq.Count());

            pq.Dequeue();
            pq.Dequeue();
            pq.Dequeue();

            Assert.AreEqual(0, pq.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueAllElementsAndOneMore()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Dequeue();
        }

        [TestMethod]
        public void NegativePriority()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Enqueue(1, -5);
            pq.Enqueue(2, -7);
            Assert.AreEqual(2, pq.Count());
            Assert.AreEqual(1, pq.Dequeue());
        }

        [TestMethod]
        public void ValuesAreRemovedInCorrectOrder()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Enqueue(2, 3);
            pq.Enqueue(1, 5);
            pq.Enqueue(1, 5);
            pq.Enqueue(3, 5);
            pq.Enqueue(3, 5);
            pq.Enqueue(2, 4);
            pq.Enqueue(7, 7);

            Assert.AreEqual(7, pq.Count());

            Assert.AreEqual(7, pq.Dequeue());
            Assert.AreEqual(1, pq.Dequeue());
            Assert.AreEqual(1, pq.Dequeue());
            Assert.AreEqual(3, pq.Dequeue());
            Assert.AreEqual(3, pq.Dequeue());
            Assert.AreEqual(2, pq.Dequeue());
            Assert.AreEqual(2, pq.Dequeue());
        }

        [TestMethod]
        public void GetSpecificPrio()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Enqueue(2, 3);
            pq.Enqueue(1, 5);

            Assert.AreEqual(2, pq.DequeueByPrio(3));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetInvalidPrio()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Enqueue(2, 3);
            pq.Enqueue(1, 5);

            pq.DequeueByPrio(4);
        }

        [TestMethod]
        public void DequeueByPrioAllElements()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Enqueue(2, 3);
            pq.Enqueue(1, 5);
            pq.Enqueue(1, 4);

            Assert.AreEqual(3, pq.Count());

            pq.DequeueByPrio(4);
            pq.Dequeue();
            pq.Dequeue();

            Assert.AreEqual(0, pq.Count());
        }

        [TestMethod]
        public void ClearRemovesAllElements()
        {
            var pq = new PriorityQueue<string>();
            pq.Enqueue("hallo", 1);
            pq.Enqueue("welt", 2);

            pq.Clear();

            Assert.AreEqual(0, pq.Count());
        }

    }
}
