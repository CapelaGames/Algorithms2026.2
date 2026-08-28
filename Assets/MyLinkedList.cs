using Mono.Cecil;
using UnityEngine;

namespace AAI.LinkedList
{
    public class Node
    {
        // Data we are storing in the node
        public string name = "Data";
        public int id;
        public int age;

        // links
        public Node next;

        public Node(string name, int age, int id) 
        {
            this.name = name;
            this.age = age;
            this.id = id;

            next = null;
        }

/*        ~Node()
        {

        }*/
    }


    public class MyLinkedList : MonoBehaviour
    {
        [ContextMenu("Test Linked list")]
        private void Start()
        {
            Node example = new Node("Hello", 67, 42);
            LinkedList linkedList = new LinkedList(example);

            linkedList.InsertNext(new Node("Andrew", 43, 32222222));
            linkedList.InsertNext(new Node("Fred", 243, 32222222));
            linkedList.InsertNext(new Node("Kim", 3432, 32222));
            linkedList.InsertNext(new Node("John", 2342, 3));
            linkedList.InsertNext(new Node("Kay", 23423, 322));

            linkedList.PrintAll();
        }
    }

    public class LinkedList
    {
        private Node current;
        private Node header;

        public LinkedList(Node node)
        {
            current = node;
            header = node;
        }

        public void InsertNext(Node newNode)
        {
            if (current == null)
            {
                current = newNode;
                header = newNode;
                newNode.next = null;
            }
            else if (current.next == null)
            {
                current.next = newNode;
                newNode.next = null;
            }
            else
            {
                newNode.next = current.next;
                current.next = newNode;
            }
            current = newNode;
        }

        public void Print(Node node) => Debug.Log(node.id + " | " + node.name + " aged " + node.age);
        public void PrintCurrent() => Print(current);

        public void PrintAll()
        {
            if (header == null) return;
            Node CurrentPrint = header;

            do
            {
                Print(CurrentPrint);
                CurrentPrint = CurrentPrint.next;
            }while(CurrentPrint != null);
        }
    }
}