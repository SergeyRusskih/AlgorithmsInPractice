using Xunit;

namespace DataStructures.Stack
{
    public class StackTests
    {
        private readonly Stack<int> _stack;

        public StackTests()
        {
            _stack = new Stack<int>();
        }

        [Fact]
        public void Should_Return_Pushed_Items_In_LIFO_Order()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            Assert.Equal(3, _stack.Pop());
            Assert.Equal(2, _stack.Pop());
            Assert.Equal(1, _stack.Pop());
        }

        [Fact]
        public void Should_Be_Empty_When_Pop_To_End()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            Assert.False(_stack.IsEmpty);
            Assert.Equal(3, _stack.Count);

            _stack.Pop();
            _stack.Pop();
            _stack.Pop();

            Assert.True(_stack.IsEmpty);
            Assert.Equal(0, _stack.Count);
        }

        [Fact]
        public void Should_Peek_Without_Removing()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            Assert.Equal(3, _stack.Peek());
            Assert.Equal(3, _stack.Peek());

            Assert.False(_stack.IsEmpty);
            Assert.Equal(3, _stack.Count);
        }
    }
}