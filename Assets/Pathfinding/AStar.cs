using System.Collections.Generic;
using UnityEngine;

namespace MyPathFinding
{
    public class AStar : Dijkstra
    {

        protected void SetUnexplored(List<Node> unexplored, Vector3 goalPosition)
        {
            foreach (var node in nodesInScene)
            {
                node.Reset();
                node.SetHeuristic(goalPosition);
                unexplored.Add(node);
            }
        }


        protected override bool RunAlorithm(Node start, Node goal)
        {
            List<Node> unexplored = new List<Node>();
            Node sNode = start;
            Node eNode = goal;

            //this line
            SetUnexplored(unexplored, eNode.transform.position);
            sNode.PathWeight = 0;

            while (unexplored.Count > 0)
            {
                // unexplored.Sort((a, b) => a.PathWeight.CompareTo(b.PathWeight));
                unexplored.Sort((a, b) => a.HeuristicPathWeigth.CompareTo(b.HeuristicPathWeigth));

                Node current = unexplored[0];
                unexplored.RemoveAt(0);

                foreach (var neighbourNode in current.Neighbours)
                {
                    if (!unexplored.Contains(neighbourNode)) continue;

                    // New line will be here
                    //neighbourNode.SetHeuristic(eNode.transform.position);

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