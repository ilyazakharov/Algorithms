namespace Algorithms.Sorting
{
    public interface ISort<T> where T:IComparable
    {
        List<T> Sort(List<T> list);
    }
}
