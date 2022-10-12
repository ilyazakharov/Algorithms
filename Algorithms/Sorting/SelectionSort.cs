namespace Algorithms.Sorting
{
    internal class SelectionSort<T> : ISort<T> where T : IComparable
    {
        public List<T> Sort(List<T> list)
        {
            List<T> result = list;

            int min = 0;
            for (int i = 0; i < result.Count; i++)
            {
                min = i;

                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[j].CompareTo(result[min]) < 0)
                    {
                        min = j;
                    }
                }
                if (i != min)
                {
                    T buf = result[i];
                    result[i] = result[min];
                    result[min] = buf;
                }
            }
            return result;
        }
    }
}
