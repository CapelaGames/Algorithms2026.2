using System.Collections.Generic;
using UnityEngine;


namespace MyPathFinding
{
    public class Dijkstra : MonoBehaviour
    {
        protected Node[] nodesInScene;

        public Node testStartNode;
        public Node testEndNode;

        [ContextMenu("Test")]
        void Test()
        {
            GetAllNodes();
            List<Node> path = FindShortestPath(testStartNode, testEndNode);
            DebugPath(path);
        }

        public Node[] GetAllNodes()
        {
            nodesInScene = FindObjectsByType<Node>(FindObjectsSortMode.None);
            return nodesInScene;
        }

        public void DebugPath (List<Node> path)
        {
            for (int i = 0; i < path.Count -1; i++)
            {
                Debug.DrawLine(
                    path[i].transform.position + Vector3.up * 0.01f,
                    path[i + 1].transform.position + Vector3.up * 0.01f,
                    Color.red,
                    10f
                    );
            }
        }

        public List<Node> FindShortestPath(Node start, Node goal)
        {
            if (RunAlorithm(start,goal))
            {
                List<Node> path = new List<Node>();
                Node current = goal;

                do
                {
                    path.Insert(0, current);
                    current = current.PreviousNode;
                } while (current != null);

                return path;
            }

            return null;
        }

        protected virtual void SetUnexplored(List<Node> unexplored)
        {
            foreach (var node in nodesInScene)
            {
                node.Reset();
                unexplored.Add(node);
            }
        }

        protected virtual bool RunAlorithm(Node start, Node goal)
        {
            List<Node> unexplored = new List<Node>();
            Node sNode = start;
            Node eNode = goal;

            SetUnexplored(unexplored);
            sNode.PathWeight = 0;

            while (unexplored.Count > 0)
            {
                unexplored.Sort((a,b)=> a.PathWeight.CompareTo(b.PathWeight));
                Node current = unexplored[0];
                unexplored.RemoveAt(0);

                foreach(var neighbourNode in current.Neighbours)
                {
                    if (!unexplored.Contains(neighbourNode)) continue;

                    float segmentWeight = Vector3.Distance(
                        current.transform.position,
                        neighbourNode.transform.position
                        );

                    float neightbourPathWeight = current.PathWeight + segmentWeight;

                    if (neightbourPathWeight < neighbourNode.PathWeight)
                    {
                        neighbourNode.PathWeight = neightbourPathWeight;
                        neighbourNode.PreviousNode = current;
                    }
                }

                if (current == eNode) return true;
            }
            return false;
        }
    }
}
