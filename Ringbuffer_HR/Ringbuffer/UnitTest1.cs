using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ringbuffer
{
    [TestClass]
    public class ringbufferTests
    {
        [TestMethod]
        public void IsNotNull()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            Assert.IsNotNull(ringbuffer);
        }

        [TestMethod]
        public void SizePropertyIsSet()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            Assert.AreEqual(3, ringbuffer.Size);
        }

        [TestMethod]
        public void CountPropertyIsZero()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            Assert.AreEqual(0, ringbuffer.Count);
        }

        [TestMethod]
        public void AddOneElements()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            Assert.AreEqual(1, ringbuffer.Count);
        }

        [TestMethod]
        public void TakeOneElements()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            Assert.AreEqual(1, ringbuffer.Count);
            Assert.AreEqual(1, ringbuffer.Take());
            Assert.AreEqual(0, ringbuffer.Count);
        }

        [TestMethod]
        public void AddTwoElements()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            Assert.AreEqual(1, ringbuffer.Count);
            ringbuffer.Add(2);
            Assert.AreEqual(2, ringbuffer.Count);
        }

        [TestMethod]
        public void TakeTwoElements()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            Assert.AreEqual(1, ringbuffer.Count);
            ringbuffer.Add(2);
            Assert.AreEqual(2, ringbuffer.Count);

            Assert.AreEqual(1, ringbuffer.Take());
            Assert.AreEqual(1, ringbuffer.Count);

            Assert.AreEqual(2, ringbuffer.Take());
            Assert.AreEqual(0, ringbuffer.Count);
        }

        [TestMethod]
        public void AddThreeElements()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            Assert.AreEqual(1, ringbuffer.Count);
            ringbuffer.Add(2);
            Assert.AreEqual(2, ringbuffer.Count);
            ringbuffer.Add(3);
            Assert.AreEqual(3, ringbuffer.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TakeThreeElementsException()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            Assert.AreEqual(1, ringbuffer.Count);
            ringbuffer.Add(2);
            Assert.AreEqual(2, ringbuffer.Count);
            ringbuffer.Add(3);
            Assert.AreEqual(3, ringbuffer.Count);

            Assert.AreEqual(1, ringbuffer.Take());
            Assert.AreEqual(2, ringbuffer.Count);

            Assert.AreEqual(2, ringbuffer.Take());
            Assert.AreEqual(1, ringbuffer.Count);

            Assert.AreEqual(3, ringbuffer.Take());
            Assert.AreEqual(0, ringbuffer.Count);


            int third = ringbuffer.Take();
        }

        [TestMethod]
        public void AddFourElements()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            Assert.AreEqual(1, ringbuffer.Count);
            ringbuffer.Add(2);
            Assert.AreEqual(2, ringbuffer.Count);
            ringbuffer.Add(3);
            Assert.AreEqual(3, ringbuffer.Count);
            ringbuffer.Add(4);
            Assert.AreEqual(3, ringbuffer.Count);
        }

        [TestMethod]
        public void TakeFourElements()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            Assert.AreEqual(1, ringbuffer.Count);
            ringbuffer.Add(2);
            Assert.AreEqual(2, ringbuffer.Count);
            ringbuffer.Add(3);
            Assert.AreEqual(3, ringbuffer.Count);
            ringbuffer.Add(4);
            Assert.AreEqual(3, ringbuffer.Count);

            Assert.AreEqual(2, ringbuffer.Take());
            Assert.AreEqual(2, ringbuffer.Count);

            Assert.AreEqual(3, ringbuffer.Take());
            Assert.AreEqual(1, ringbuffer.Count);

            Assert.AreEqual(4, ringbuffer.Take());
            Assert.AreEqual(0, ringbuffer.Count);
        }

        [TestMethod]
        public void DojoTest()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            ringbuffer.Add(2);

            Assert.AreEqual(3, ringbuffer.Size);
            Assert.AreEqual(2, ringbuffer.Count);

            Assert.AreEqual(1, ringbuffer.Take());

            ringbuffer.Add(3);
            ringbuffer.Add(4);
            ringbuffer.Add(5);

            Assert.AreEqual(3, ringbuffer.Take());

            ringbuffer.Add(6);
            ringbuffer.Add(7);

            Assert.AreEqual(3, ringbuffer.Count);

            Assert.AreEqual(5, ringbuffer.Take());

            Assert.AreEqual(2, ringbuffer.Count);
        }

        // ------------------

        [TestMethod]
        public void SizePropertyIsSetAsGivenByConstructor()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            Assert.AreEqual(3, ringbuffer.Size);
        }

        [TestMethod]
        public void CountPropertyIsZeroAfterConstructing()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            Assert.AreEqual(0, ringbuffer.Count);
        }

        [TestMethod]
        public void AddOneToringbuffer()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(5);
            Assert.AreEqual(3, ringbuffer.Size);
            Assert.AreEqual(1, ringbuffer.Count);
        }

        [TestMethod]
        public void AddTwoToringbuffer()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            ringbuffer.Add(2);
            Assert.AreEqual(3, ringbuffer.Size);
            Assert.AreEqual(2, ringbuffer.Count);
        }

        [TestMethod]
        public void AddTwoTakeFirstObject()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            ringbuffer.Add(2);
            Assert.AreEqual(2, ringbuffer.Count);
            Assert.AreEqual(1, ringbuffer.Take());
            Assert.AreEqual(1, ringbuffer.Count);
        }

        [TestMethod]
        public void AddMoreObjectsThanSize()
        {
            var ringbuffer = new Ringbuffer<int>(2);
            ringbuffer.Add(1);
            ringbuffer.Add(2);
            ringbuffer.Add(2);
            Assert.AreEqual(2, ringbuffer.Count);

        }
        [TestMethod]
        public void TakeFirstObjectOnBufferOverflow()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            ringbuffer.Add(2);
            ringbuffer.Add(3);
            ringbuffer.Add(4);
            Assert.AreEqual(3, ringbuffer.Count);
            Assert.AreEqual(2, ringbuffer.Take());
            Assert.AreEqual(2, ringbuffer.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TakeOnEmptyBuffer()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            int first = ringbuffer.Take();
        }

        [TestMethod]
        public void TakeMoreThanOneBuffer()
        {
            var ringbuffer = new Ringbuffer<int>(3);
            ringbuffer.Add(1);
            ringbuffer.Add(2);
            ringbuffer.Add(3);
            ringbuffer.Add(4);

            Assert.AreEqual(3, ringbuffer.Count);

            Assert.AreEqual(2, ringbuffer.Take());
            Assert.AreEqual(2, ringbuffer.Count);

            Assert.AreEqual(3, ringbuffer.Take());
            Assert.AreEqual(1, ringbuffer.Count);

            Assert.AreEqual(4, ringbuffer.Take());
            Assert.AreEqual(0, ringbuffer.Count);
        }

        [TestMethod]
        public void AddAndTakeInTwoRounds()
        {
            var ringbuffer = new Ringbuffer<int>(2);
            ringbuffer.Add(1);
            ringbuffer.Add(2);
            ringbuffer.Add(3);
            ringbuffer.Add(4);

            Assert.AreEqual(2, ringbuffer.Count);

            Assert.AreEqual(3, ringbuffer.Take());
            Assert.AreEqual(1, ringbuffer.Count);

            ringbuffer.Add(5);
            Assert.AreEqual(2, ringbuffer.Count);

            Assert.AreEqual(4, ringbuffer.Take());
            Assert.AreEqual(1, ringbuffer.Count);

            Assert.AreEqual(5, ringbuffer.Take());
            Assert.AreEqual(0, ringbuffer.Count);
        }
    }

    public class Ringbuffer<T>
    {
        public int Size
        {
            get;
            set;
        }

        public int Count
        {
            get;
            set;
        }

        private T[] buffer;

        private int writeIndex = 0;
        private int readIndex = 0;

        public Ringbuffer(int size)
        {
            this.Size = size;
            this.buffer = new T[size];
        }

        public void Add(T value)
        {
            if (this.writeIndex > 0)
            {
                if (this.writeIndex == this.Size)
                {
                    this.writeIndex = 0;

                    if (this.Size == this.Count)
                    {
                        this.Count--;
                    }

                    if (this.readIndex == 0)
                    {
                        this.readIndex++;
                    }
                }
                else if (this.writeIndex < this.Size)
                {
                    if (this.Size == this.Count)
                    {
                        this.Count--;
                    }
                }

                if (this.readIndex > 0)
                {
                    if (this.writeIndex == this.readIndex)
                    {
                        this.readIndex++;
                    }

                    if (this.readIndex == this.Size)
                    {
                        this.readIndex = 0;
                    }
                }
            }

            this.buffer[writeIndex] = value;
            this.writeIndex++;
            this.Count++;
        }

        public T Take()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            if (this.readIndex > 0 && this.readIndex == this.Size)
            {
                this.readIndex = 0;
            }

            T result = this.buffer[readIndex];
            this.readIndex++;
            this.Count--;
            return result;
        }
    }

}
