using System;
using System.Security.AccessControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RingBuffer
{
    [TestClass]
    public class RingBufferTests    
    {
        [TestMethod]
        public void SizePropertyIsSetAsGivenByConstructor()
        {
            int initialSize = 3;

            var ringbuffer = new RingBuffer<int>(initialSize);
            Assert.AreEqual(initialSize, ringbuffer.Size);
        }

        [TestMethod]
        public void CountPropertyIsZeroAfterConstructing()
        {
            var ringbuffer = new RingBuffer<int>(3);
            Assert.AreEqual(0, ringbuffer.Count);
        }

        [TestMethod]
        public void AddOneToRingBuffer()
        {
            int initialSize = 3;
            var ringbuffer = new RingBuffer<int>(initialSize);
            ringbuffer.Add(5);
            Assert.AreEqual(initialSize, ringbuffer.Size);
            Assert.AreEqual(1, ringbuffer.Count);
        }

        [TestMethod]
        public void AddTwoToRingBuffer()
        {
            int initialSize = 3;
            var ringbuffer = new RingBuffer<int>(initialSize);
            ringbuffer.Add(1);
            ringbuffer.Add(2);
            Assert.AreEqual(initialSize, ringbuffer.Size);
            Assert.AreEqual(2, ringbuffer.Count);
        }

        [TestMethod]
        public void AddTwoTakeFirstObject()
        {
            int initialSize = 3;
            var ringbuffer = new RingBuffer<int>(initialSize);
            ringbuffer.Add(1);
            ringbuffer.Add(2);
            Assert.AreEqual(2, ringbuffer.Count);
            int first = ringbuffer.Take();
            Assert.AreEqual(1, first);
            Assert.AreEqual(1, ringbuffer.Count);

        }

        [TestMethod]
        public void AddMoreObjectsThanSize()
        {
            int initialSize = 2;
            var ringbuffer = new RingBuffer<int>(initialSize);
            ringbuffer.Add(1); // 1, 0
            ringbuffer.Add(2); // 2, 0
            ringbuffer.Add(2); // 0, 1
            Assert.AreEqual(2, ringbuffer.Count);

        }
        [TestMethod]
        public void TakeFirstObjectOnBufferOverflow()
        {
            int initialSize = 3;
            var ringbuffer = new RingBuffer<int>(initialSize);
            ringbuffer.Add(1);
            ringbuffer.Add(2);
            ringbuffer.Add(3);
            ringbuffer.Add(4);
            Assert.AreEqual(3, ringbuffer.Count);
            int first = ringbuffer.Take();
            Assert.AreEqual(2, ringbuffer.Count);
            Assert.AreEqual(2, first);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TakeOnEmptyBuffer()
        {
            int initialSize = 3;
            var ringbuffer = new RingBuffer<int>(initialSize);
            int first = ringbuffer.Take();
        }


        [TestMethod]
       
        public void TakeMoreThanOneBuffer()
        {
            int initialSize = 3;
            var ringbuffer = new RingBuffer<int>(initialSize);
            ringbuffer.Add(1);
            ringbuffer.Add(2);
            ringbuffer.Add(3);
            ringbuffer.Add(4);

            Assert.AreEqual(3, ringbuffer.Count);

            int first = ringbuffer.Take();
            Assert.AreEqual(2, ringbuffer.Count);
            Assert.AreEqual(2, first);

            int second = ringbuffer.Take();
            Assert.AreEqual(1, ringbuffer.Count);
            Assert.AreEqual(3, second);

            int third = ringbuffer.Take();
            Assert.AreEqual(0, ringbuffer.Count);
            Assert.AreEqual(4, third);
        }

        [TestMethod]
        public void AddAndTakeInTwoRounds()
        {
            int initialSize = 2;
            var ringbuffer = new RingBuffer<int>(initialSize);
            ringbuffer.Add(1);
            ringbuffer.Add(2);
            ringbuffer.Add(3);
            ringbuffer.Add(4);

            Assert.AreEqual(2, ringbuffer.Count);

            int first = ringbuffer.Take();
            Assert.AreEqual(1, ringbuffer.Count);
            Assert.AreEqual(3, first);

            ringbuffer.Add(5);
            int second = ringbuffer.Take();
            Assert.AreEqual(1, ringbuffer.Count);
            Assert.AreEqual(4, second);

            int third = ringbuffer.Take();
            Assert.AreEqual(0, ringbuffer.Count);
            Assert.AreEqual(5, third);

        }


    }

}
