namespace Algorithms.Searching
{
    public interface ISearch<T>
    {
        int FindValue(List<T> sortedList, T value);
    }
}
