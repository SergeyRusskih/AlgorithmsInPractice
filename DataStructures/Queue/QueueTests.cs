using Xunit;

namespace DataStructures.Queue
{
    public class QueueTests
    {
        private readonly Queue<int> _queue;

        public QueueTests()
        {
            _queue = new Queue<int>();
        }

        [Fact]
        public void Should_Return_Added_Items_In_FIFO_Order()
        {
            _queue.Add(1);
            _queue.Add(2);
            _queue.Add(3);

            Assert.Equal(1, _queue.Remove());
            Assert.Equal(2, _queue.Remove());
            Assert.Equal(3, _queue.Remove());
        }

        [Fact]
        public void Should_Be_Empty_When_Pop_To_End()
        {
            _queue.Add(1);
            _queue.Add(2);
            _queue.Add(3);

            Assert.False(_queue.IsEmpty);
            Assert.Equal(3, _queue.Count);

            _queue.Remove();
            _queue.Remove();
            _queue.Remove();

            Assert.True(_queue.IsEmpty);
            Assert.Equal(0, _queue.Count);
        }

        [Fact]
        public void Should_Peek_Without_Removing()
        {
            _queue.Add(1);
            _queue.Add(2);
            _queue.Add(3);

            Assert.Equal(1, _queue.Peek());
            Assert.Equal(1, _queue.Peek());

            Assert.False(_queue.IsEmpty);
            Assert.Equal(3, _queue.Count);
        }
    }
}