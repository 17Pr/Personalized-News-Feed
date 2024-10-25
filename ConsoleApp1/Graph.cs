using System.Collections.Generic;

public class Graph
{
    private Dictionary<string, List<string>> topicGraph;

    public Graph()
    {
        topicGraph = new Dictionary<string, List<string>>();
    }

    public void AddEdge(string topic1, string topic2)
    {
        if (!topicGraph.ContainsKey(topic1))
        {
            topicGraph[topic1] = new List<string>();
        }
        if (!topicGraph.ContainsKey(topic2))
        {
            topicGraph[topic2] = new List<string>();
        }
        topicGraph[topic1].Add(topic2);
        topicGraph[topic2].Add(topic1); // If bi-directional
    }

    public bool IsRelated(string topic1, string topic2)
    {
        if (!topicGraph.ContainsKey(topic1) || !topicGraph.ContainsKey(topic2))
        {
            return false;
        }
        return BFS(topic1, topic2);
    }

    private bool BFS(string start, string target)
    {
        Queue<string> queue = new Queue<string>();
        HashSet<string> visited = new HashSet<string>();
        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            string current = queue.Dequeue();
            if (current == target) return true;

            foreach (var neighbor in topicGraph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
        }
        return false;
    }
}
