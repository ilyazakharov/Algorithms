namespace Algorithms.Graphs
{
    public class BreadthFirstSearch
    {
        // BFS checks whether a nearest neighbour is the one you need. If not it takes nearest neighbours of your neighboars and goes on until the end.
        // BFS usually uses Queue
        // 1 - wall, 0 - way, 2 - entrance, 3 - exit, 8 - your way.
        // Example:       Result:
        // 1 1 1 1 1 1 1  1 1 1 1 1 1 1
        // 2 0 0 1 1 1 1  8 8 8 1 1 1 1
        // 1 1 0 0 1 1 0  1 1 8 8 1 1 0 
        // 1 0 0 1 1 1 0  1 8 8 1 1 1 0
        // 1 0 1 1 3 1 0  1 8 1 1 8 1 0
        // 0 0 0 0 0 0 0  8 8 8 8 8 0 0
        public List<List<int>> BFSGetExitFromLabirinth(List<List<int>> labirinth)
        {
            List<List<int>> result = new(labirinth);

            Dictionary<string, List<string>> links = CreateLinks(labirinth, out string entrance, out string exit);

            // BFS starts here.
            Queue<List<string>> queue = new();
            List<string> searched = new();

            if (links.TryGetValue(entrance, out List<string>? neighbours))
            {
                queue.Enqueue(neighbours);
            }

            while (queue.Count > 0)
            {
                List<string> nodes = queue.Dequeue();
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (searched.Contains(nodes[i]))
                    {
                        continue;
                    }

                    GetIndexes(nodes[i], out int j, out int k);
                    result[j][k] = 8;

                    if (nodes[i] == exit)
                    {
                        Console.WriteLine($"Exit was found on {nodes[i]}.");
                        return result;
                    }

                    searched.Add(nodes[i]);
                    if (links.TryGetValue(nodes[i], out List<string>? newNodes))
                    {
                        queue.Enqueue(newNodes);
                    }
                }
            }

            return result;
        }

        private void GetIndexes(string value, out int i, out int j)
        {
            string[] indexes = value.Split("-");
            i = int.Parse(indexes[0]);
            j = int.Parse(indexes[1]);
        }

        // Creates a dictionary the has links between all the possible point where you can go from.
        // And returns the entry and exit points.
        // Nodes are stored in "i-j" format.
        private Dictionary<string, List<string>> CreateLinks(List<List<int>> labirinth, out string entrance, out string exit)
        {
            Dictionary<string, List<string>> links = new();
            entrance = "-1";
            exit = "-1";

            for (int i = 0; i < labirinth.Count; i++)
            {
                for (int j = 0; j < labirinth[i].Count; j++)
                {
                    if (labirinth[i][j] == 0 || labirinth[i][j] > 1)
                    {
                        string key = i.ToString() + "-" + j.ToString();

                        if (labirinth[i][j] == 2)
                        {
                            if (entrance != "-1")
                            {
                                throw new Exception("There can be only one entrance.");
                            }

                            entrance = key;
                        }

                        if (labirinth[i][j] == 3)
                        {
                            if (exit != "-1")
                            {
                                throw new Exception("There can be only one exit.");
                            }

                            exit = key;
                        }

                        links[key] = new();
                        // neighbour above
                        if (i != 0 && (labirinth[i - 1][j] == 0 || labirinth[i - 1][j] > 1))
                        {
                            links[key].Add((i - 1).ToString() + "-" + j.ToString());
                        }

                        // neighbour from the left
                        if (j != 0 && (labirinth[i][j - 1] == 0 || labirinth[i][j - 1] > 1))
                        {
                            links[key].Add(i.ToString() + "-" + (j - 1).ToString());
                        }

                        // neighbour from the right
                        if (j != labirinth[i].Count - 1 && (labirinth[i][j + 1] == 0 || labirinth[i][j + 1] > 1))
                        {
                            links[key].Add(i.ToString() + "-" + (j + 1).ToString());
                        }

                        // neighbour beneath
                        if (i != labirinth.Count - 1 && (labirinth[i + 1][j] == 0 || labirinth[i + 1][j] > 1))
                        {
                            links[key].Add((i + 1).ToString() + "-" + j.ToString());
                        }
                    }
                }
            }

            if (entrance == "-1")
            {
                throw new Exception("There is no entrance.");
            }

            if (exit == "-1")
            {
                throw new Exception("There is no exit.");
            }

            return links;
        }
    }
}