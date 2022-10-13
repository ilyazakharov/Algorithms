using Algorithms.Searching;
using Algorithms.Sorting;
using System.Runtime.CompilerServices;

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

static void Sort(List<int> list)
{
    ISort<int> sort = new QuickSort<int>();
    List<int> res = sort.Sort(list);

    Console.Write(String.Join(",", list));
    Console.Write($" --- {String.Join(",", res)}");
}

static void Search()
{
    ISearch<int> search = new BinarySearch<int>();
    var val = search.FindValue(new List<int>() { 10, 11, 20 }, 14);

    Console.WriteLine(val);
}