namespace Infrastructure
{
    public interface IRunable<T>
    {
        T[] Run(T[] input);
    }
}
