using System;

namespace DataStructures.Queue
{
    public class Queue<T>
    {
        private QueueItem _first;
        private QueueItem _last;

        public void Add(T item)
        {
            var newItem = new QueueItem(item);

            if (_first == null)
            {
                _first = newItem;
                _last = newItem;
            }
            else
            {
                _last.Previous = newItem;
                _last = newItem;
            }

            Count++;
        }

        public T Remove()
        {
            if (_first == null)
                throw new InvalidOperationException();

            var first = _first;
            _first = first.Previous;
            Count--;

            return first.Data;
        }

        public T Peek()
        {
            if (_first == null)
                throw new InvalidOperationException();

            return _first.Data;
        }

        public bool IsEmpty => _first == null;

        public int Count { get; private set; }

        private class QueueItem
        {
            public QueueItem(T item)
            {
                Data = item;
            }

            public T Data { get; set; }
            public QueueItem Previous { get; set; }
        }
    }
}