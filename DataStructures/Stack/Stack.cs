using System;

namespace DataStructures.Stack
{
    public class Stack<T>
    {
        private StackItem _top;

        public T Pop()
        {
            if (_top == null) throw new InvalidOperationException();

            var top = _top;
            _top = top.Next;
            Count--;

            return top.Data;
        }

        public void Push(T item)
        {
            var next = new StackItem(item);
            if (_top == null)
            {
                _top = next;
            }
            else
            {
                next.Next = _top;
                _top = next;
            }

            Count++;
        }

        public T Peek()
        {
            if (_top == null) throw new InvalidOperationException();
            return _top.Data;
        }

        public bool IsEmpty => _top == null;
        public int Count { get; private set; }

        private class StackItem
        {
            public StackItem(T item)
            {
                Data = item;
            }

            public T Data { get; set; }
            public StackItem Next { get; set; }
        }
    }
}