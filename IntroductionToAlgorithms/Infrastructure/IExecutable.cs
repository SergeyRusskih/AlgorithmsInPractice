using System.Collections.Generic;

namespace Infrastructure
{
    public interface IExecutable<T>
    {
        IEnumerable<T> Execute(IEnumerable<T> input);
    }
}
