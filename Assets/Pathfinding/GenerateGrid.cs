using UnityEngine;

namespace MyPathFinding
{
    public class GenerateGrid : MonoBehaviour
    {
        public Node prefab;

        private int rows = 25, cols = 25;
        private float gap = 1f;


        [ContextMenu("GenerateGrid")]
        public void Generator()
        {

            Vector3 startPos = transform.position;

            Node prev = null;
            Node[] prevColumn = new Node[cols];

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    Vector3 newPosition = new Vector3(
                        startPos.x + gap * x,
                        startPos.y,
                        startPos.z + gap * y
                        );

                    Node node = Instantiate(prefab, newPosition, Quaternion.identity, transform);
                    node.name = node.name + " " + x + " " + y;

                    if (prev != null)
                    {
                        node.Neighbours.Add(prev);
                        prev.Neighbours.Add(node);
                    }

                    if (prevColumn[y] != null)
                    {
                        node.Neighbours.Add(prevColumn[y]);
                        prevColumn[y].Neighbours.Add(node);
                    }

                    prev = node;
                    prevColumn[y] = node;
                }

                prev = null;
            }
        }
    }

}
