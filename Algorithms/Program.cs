using Algorithms.Searching;
using Algorithms.Sorting;
using System.Runtime.CompilerServices;

Sort();

static void Sort()
{
    List<int> list = new List<int>() { 50, 1, 50, -506, 48947 };
    ISort<int> sort = new BubbleSort<int>();
    List<int> res = sort.Sort(list);

    Console.WriteLine(String.Join(",", list));
    Console.WriteLine(String.Join(",", res));
}

static void Search()
{
    ISearch<int> search = new BinarySearch<int>();
    var val = search.FindValue(new List<int>() { 10, 11, 20 }, 14);

    Console.WriteLine(val);
}