namespace Algorithms.Searching
{
    public class BinarySearch<T> : ISearch<T> where T:IComparable
    {
        public int FindValue(List<T> sortedList, T value)
        {
            if (sortedList == null || sortedList.Count == 0)
            {
                return -1;
            }
             
            int start = 0;
            int end = sortedList.Count - 1;

            while (end >= start)
            {
                int middle = (start + end) / 2;
                if (sortedList[middle].Equals(value))
                {
                    return middle;
                }

                if (sortedList[middle].CompareTo(value) > 0)
                {
                    end = middle - 1;
                }

                else
                {
                    start = middle + 1;
                }
            }

            return -1;
        }
    }
}
