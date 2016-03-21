using System;

namespace RingBuffer
{
    public class RingBuffer<T>
    {
        public int Size { get; private set; }
        public int Count { get; private set; }

        private int _writeIndex = 0;
        private int _readIndex = 0;

        private readonly T[] _buffer;

        public RingBuffer(int size)
        {
            this.Size = size;
            this.Count = 0;
            this._buffer = new T[size];
            this._writeIndex = 0;
        }

        public void Add(T value)
        {
            if(Count<Size)
            {
                this.Count++;
            }
            this._buffer[_writeIndex] = value;

            if (_writeIndex == _readIndex && Count==Size)
            {
                _readIndex = (_readIndex +1) % Size;
            }
            this._writeIndex = (_writeIndex + 1) % Size;
        }

        public T Take()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            this.Count--;
          
            T result = this._buffer[_readIndex];
            _readIndex = (_readIndex + 1) % Size;
           
            return result;

        }
    }
}