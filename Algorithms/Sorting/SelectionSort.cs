namespace Algorithms.Sorting
{
    public class SelectionSort<T> : ISort<T> where T : IComparable
    {
        // Finds and moves a minimum value {} to the left
        //(30,20,10,5)-({5},20,10,30)-(5,{10},20,30)-(5,10,{20},30)
        public List<T> Sort(List<T> list)
        {
            List<T> result = new(list);
            for (int i = 0; i < result.Count - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[j].CompareTo(result[min]) < 0)
                    {
                        min = j;
                    }
                }
                if (i != min)
                {
                    (result[i], result[min]) = (result[min], result[i]);
                }
            }
            return result;
        }
    }
}