using Algorithms.Recursion;
using Algorithms.Searching;
using Algorithms.Sorting;
using System.Runtime.CompilerServices;

TestRecursive();

static void Sort(List<int> list)
{
    ISort<int> sort = new QuickSort<int>();
    List<int> res = sort.Sort(list);

    Console.Write($"[{String.Join(",", list)}]");
    Console.Write($" - [{String.Join(",", res)}]");
}

static void Search()
{
    ISearch<int> search = new BinarySearch<int>();
    var val = search.FindValue(new List<int>() { 10, 11, 20 }, 14);

    Console.WriteLine(val);
}

static void TestSort()
{
    List<List<int>> lists = new()
    {
        new(),
        new(){0},
        new(){0,1},
        new(){1,0},
        new(){1,5,9},
        new(){9,5,1},
        new(){9,1,5},
        new(){5,1,9},
        new(){1,1,1},
        new(){1,1,2},
        new(){1,2,1},
        new(){2,1,1},
        new(){50, 1, 50, -506, 48947 },
    };

    lists.ForEach(l =>
    {
        Sort(l);
        Console.WriteLine();
    });
}

static void TestRecursive()
{
    List<int> list = new() { 9, 2, 7, 4, 10, 6, 3, 8, 1, 5 };
    int sum = RecursiveFunctions.Sum(list);
    int count = RecursiveFunctions.Count(list);
    int? max = RecursiveFunctions.Max(list);

    int val = 2;
    list.Sort();
    int found = RecursiveFunctions.BinarySearch(list, val);
    string foundStr = found == -1 ? "missing" : found.ToString();

    Console.WriteLine($"{String.Join("+", list)}={sum}");
    Console.WriteLine($"Count of [{String.Join(",", list)}] equals {count}");
    Console.WriteLine($"Maximum value in [{String.Join(",", list)}] is {max}");
    Console.WriteLine($"Number of element with value {val} in [{String.Join(",", list)}] is {foundStr}");
}