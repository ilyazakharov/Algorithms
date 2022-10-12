namespace Algorithms.Sorting
{
    public class InsertionSort<T> : ISort<T> where T : IComparable
    {
        public List<T> Sort(List<T> list)
        {
            List<T> result = new(list);

            for (int i = 1; i < result.Count; i++)
            {
                T current = result[i];
                int j = i - 1;
                while(j >= 0 && result[j].CompareTo(current) > 0)
                {
                    result[j + 1] = result[j];
                    result[j] = current;
                    j--;
                }
            }
            return result;
        }
    }
}