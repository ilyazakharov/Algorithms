namespace Algorithms.Sorting
{
    public class QuickSort<T> : ISort<T> where T : IComparable
    {
        public List<T> Sort(List<T> list)
        {
            if (list == null)
            {
                return new List<T>();
            }

            //List<T> result = new(list);
            //return QuickSorting(result, 0, result.Count - 1);
            return QsWithNewLists(list);
        }

        //{}-wall
        //(30,10,50,15)-({30},10,50,15)-(10,{30},50,15)-(10,15,{50},30)-(10,15,30,50)
        private List<T> QuickSorting(List<T> list, int start, int end)
        {
            if (start >= end)
            {
                return list;
            }

            int wall = start;
            for (int i = start; i < end; i++)
            {
                if (list[i].CompareTo(list[end]) < 0)
                {
                    if (wall != i)
                    {
                        (list[wall], list[i]) = (list[i], list[wall]);
                    }
                    wall++;
                }
            }

            if (wall != end)
            {
                (list[wall], list[end]) = (list[end], list[wall]);
            }

            list = QuickSorting(list, start, wall - 1);
            list = QuickSorting(list, wall + 1, end);

            return list;
        }

        private List<T> QsWithNewLists(List<T> input)
        {
            if (input.Count < 2)
                return input;

            T pivot = input[0];
            List<T> less = new();
            List<T> greater = new();
            for(int i = 1; i < input.Count; i++)
            {
                if (input[i].CompareTo(pivot) > 0)
                    greater.Add(input[i]);
                else
                    less.Add(input[i]);
            }

            List<T> res = new List<T>(input.Count);
            res.AddRange(QsWithNewLists(less));
            res.Add(pivot);
            res.AddRange(QsWithNewLists(greater));

            return res;
        }
    }
}
