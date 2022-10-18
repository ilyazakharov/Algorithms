using System.Text;

namespace Algorithms.Recursion
{
    public class RecursiveFunctions
    {
        public static string CountAndSay(int n)
        {
            if (n == 1)
            {
                return "1";
            }

            StringBuilder res = new();
            char prev = '\0';
            int count = 0;

            foreach (char c in CountAndSay(n - 1))
            {
                if (prev == c)
                {
                    count++;
                }
                else
                {
                    if (count != 0)
                    {
                        res.Append(count.ToString() + prev);
                    }
                    prev = c;
                    count = 1;
                }
            }

            res.Append(count.ToString() + prev);
            return res.ToString();
        }

        public static int Sum(List<int> vals)
        {            
            if (vals == null)
            {
                return 0;
            }

            return RecursiveSum(vals, 0, vals.Count - 1);
        }

        public static int Count(List<int> vals)
        {
            if (vals == null)
            {
                return 0;
            }

            return RecursiveCount(vals, 0, vals.Count - 1);
        }

        public static int? Max(List<int> vals)
        {
            if (vals == null || vals.Count == 0)
            {
                return null;
            }

            return RecursiveMax(vals, 0, vals.Count - 1);
        }

        public static int BinarySearch(List<int> vals, int value)
        {
            if (vals == null)
            {
                return -1;
            }

            return RecursiveBinarySearch(vals, 0, vals.Count - 1, value);


        }

        private static int RecursiveSum(List<int> vals, int start, int end)
        {
            if (start > end)
            {
                return 0;
            }
            
            if (start == end)
            {
                return vals[start];
            }

            return vals[start] + RecursiveSum(vals, start+1, end);
        }

        private static int RecursiveCount(List<int> vals, int start, int end)
        {
            if (start > end)
            {
                return 0;
            }

            if (start == end)
            {
                return 1;
            }

            return 1 + RecursiveCount(vals, start+1, end);
        }

        private static int RecursiveMax(List<int> vals, int start, int end)
        {
            if (start == end)
            {
                return vals[start];
            }

            int comparant = start+1 > end ? vals[start] : RecursiveMax(vals, start + 1, end);
            int max = vals[start] > comparant ? vals[start] : comparant;

            return max;
        }

        private static int RecursiveBinarySearch(List<int> vals, int start, int end, int value)
        {
            if (start > end)
            {
                return -1;
            }

            int result = (start + end) / 2;
            if (vals[result] == value)
            {
                return result;
            }

            if(vals[result] < value)
            {
                result = RecursiveBinarySearch(vals, result + 1, end, value);
            }
            else
            {
                result = RecursiveBinarySearch(vals, start, result - 1, value);
            }

            return result;
        }
    }
}
