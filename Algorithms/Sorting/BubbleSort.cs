namespace Algorithms.Sorting
{
    public class BubbleSort<T> : ISort<T> where T : IComparable
    {
        // {} - bubble
        //(30,20,10,5)-({20,30},10,5)-(20,{10,30},5)-(20,10,{5,30})-({10,20},5,30)-(10,{5,20},30)-({5,10},20,30)
        public List<T> Sort(List<T> list)
        {
            List<T> result = new(list);

            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < result.Count - i - 1; j++)
                {
                    if (result[j].CompareTo(result[j + 1]) > 0)
                    {
                        (result[j], result[j + 1]) = (result[j + 1], result[j]);
                    }
                }
            }
            return result;
        }
    }
}