using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int, string> list = new LinkedList<int, string>();
            list.AddNextNode(123, "AAA");
            list.AddNextNode(124, "BBB");
            list.AddNextNode(125, "CCC");

            Console.WriteLine("first node item :{0}\n first node key: {1} \n next node item: {2} \n next node key: {3}",
            list._node.Item, list._node.Key,
            list._node.NextNode.Item, list._node.NextNode.Key);

        }
    }

    public class Node<K, I>
    {
        public K Key; // ключ
        public I Item; // значення
        public Node<K, I> NextNode; // наступна нода
        public Node() // конструктор без параметрів
        {
            Key = default(K);
            Item = default(I);
            NextNode = null;
        }
        public Node(K key, I item, Node<K, I> nextNode) // конструктор з параметрами
        {
            Key = key;
            Item = item;
            NextNode = nextNode;
        }
    }

    public class LinkedList<K, I>
    {
        public Node<K, I> _node;
        public LinkedList()// конструктор без параметрів
        {
            _node = new Node<K, I>();
        }
        public void AddNextNode(K key, I item) // додавання нод в список
        {
            Node<K, I> newNode = new Node<K, I>(key, item, _node.NextNode);
            _node.NextNode = newNode;
        }

    }
}
