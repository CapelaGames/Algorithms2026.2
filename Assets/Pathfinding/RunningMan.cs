using MyPathFinding;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RunningMan : MonoBehaviour
{
    public Dijkstra pathfinder1;
    public Dijkstra pathfinder2;

    [ContextMenu("Test")]
    void Start()
    {
        pathfinder1.GetAllNodes();
        Node[] nodes = pathfinder2.GetAllNodes();

        int startNode = Random.Range(0, nodes.Length - 1);
        int goalNode = Random.Range(0, nodes.Length - 1);

        Stopwatch timer = new Stopwatch();
        timer.Start();
        List<Node> path = pathfinder1.FindShortestPath(nodes[startNode],nodes[goalNode]);
        timer.Stop();
        pathfinder1.DebugPath(path);
        UnityEngine.Debug.Log("pathfinder 1 = " + timer.ElapsedMilliseconds);

        timer = new Stopwatch();
        timer.Start();
        List<Node> path2 = pathfinder2.FindShortestPath(nodes[startNode], nodes[goalNode]);
        timer.Stop();
        pathfinder1.DebugPath(path2);
        UnityEngine.Debug.Log("pathfinder 2 = " + timer.ElapsedMilliseconds);
    }


}
