using Algorithms.Searching;

ISearch<int> search = new BinarySearch<int>();

var val = search.FindValue(new List<int>() { 10, 11, 20 }, 14);
Console.WriteLine(val);
