using System.Runtime.InteropServices;

namespace Algorithms.Graphs
{
    public class DijkstrasAlgorithm
    {
        private readonly List<string> processed = new();

        // Dijkstra's algorithm finds the shortest way between nodes in a graph with weights.
        // It moves forward just like BFS, but stores the cost of reaching the node. It updates the cost and a parent if the new cost if lower than the previous.
        public KeyValuePair<string, string> ShortestWayBetweenCities(Dictionary<string, Dictionary<string, int>> cities, string start, string end)
        {
            Dictionary<string, int> visited = new();
            Dictionary<string, string> parents = new();
            Queue<string> queue = new();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                string curPoint = queue.Dequeue();
                int curDist = visited.ContainsKey(curPoint) ? visited[curPoint] : 0;
                KeyValuePair<string, int> curCity = FindLowestCostNode(cities[curPoint]);

                while (curCity.Key != null)
                {
                    if (visited.ContainsKey(curCity.Key))
                    {
                        if (visited[curCity.Key] > (curCity.Value + curDist))
                        {
                            visited[curCity.Key] = curCity.Value + curDist;
                            parents[curCity.Key] = curPoint;
                        }
                    }
                    else
                    {
                        visited.Add(curCity.Key, curCity.Value + curDist);
                        parents.Add(curCity.Key, curPoint);
                        queue.Enqueue(curCity.Key);
                    }

                    this.processed.Add(curCity.Key);
                    curCity = FindLowestCostNode(cities[curPoint]);
                }

                this.processed.Clear();
            }

            string shortesDist = visited.ContainsKey(end) ? visited[end].ToString() : "Inaccesible";

            string path = string.Empty;
            string last = end;
            while (parents.TryGetValue(last, out string? elem))
            {
                string ending = path == string.Empty ? last : path;
                path = elem + "->" + ending;
                last = elem;
            }

            KeyValuePair<string, string> res = new(path, shortesDist);
            return res;
        }

        private KeyValuePair<string, int> FindLowestCostNode(Dictionary<string, int> cities)
        {
            KeyValuePair<string, int> shortest = new();
            int dist = -1;
            foreach (KeyValuePair<string, int> city in cities)
            {
                if (this.processed.Contains(city.Key))
                {
                    continue;
                }

                if (city.Value < dist || dist < 0)
                {
                    shortest = city;
                    dist = city.Value;
                }
            }

            return shortest;
        }
    }
}