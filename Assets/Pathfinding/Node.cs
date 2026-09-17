using System.Collections.Generic;
using UnityEngine;

namespace MyPathFinding
{
    [ExecuteInEditMode]
    public class Node : MonoBehaviour
    {
        public List<Node> Neighbours;

        private float pathWeight;
        public float PathWeight
        {
            get { return pathWeight; }
            set { pathWeight = value; }
        }

        private Node previousNode;
        public Node PreviousNode
        {
            get => previousNode;
            set => previousNode = value; 
        }

        public void Reset()
        {
            PathWeight = float.PositiveInfinity;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 0.2f);

            Gizmos.color = Color.gray;
            foreach (var node in Neighbours)
            {
                if (node == null) continue;
                Vector3 direction = node.transform.position - transform.position;
                Vector3 right = Vector3.Cross(direction, Vector3.up).normalized * 0.03f;

                Gizmos.DrawRay(transform.position + right, direction);
            }
        }

        private void OnValidate() => ValidateNeighbours();

        private void ValidateNeighbours()
        {
            foreach (var node in Neighbours)
            {
                if (node == null) continue;
                if (!node.Neighbours.Contains(this))
                {
                    node.Neighbours.Add(this);
                }
            }
        }

        private void OnDestroy() => RemoveFromNeighbours();

        private void RemoveFromNeighbours()
        {
            foreach (var node in Neighbours)
            {
                if (node == null) continue;
                node.Neighbours.Remove(this);
                node.Neighbours.Remove(null);
            }
        }

    }
}
