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
            list.AddHead(123, "AAA");
            list.AddHead(124, "BBB");
            list.AddHead(125, "CCC");

            Console.WriteLine("first node item :{0}\n first node key: {1} \n next node item: {2} \n next node key: {3}",
            list.m_Head.Item, list.m_Head.Key,
            list.m_Head.NextNode.Item, list.m_Head.NextNode.Key);

        }
    }

    public class Node<K, T>
    {
        public K Key; // 
        public T Item; // значення
        public Node<K, T> NextNode; // наступна нода
        public Node() // конструктор без параметрів
        {
            Key = default(K);
            Item = default(T);
            NextNode = null;
        }
        public Node(K key, T item, Node<K, T> nextNode) // конструктор з параметрами
        {
            Key = key;
            Item = item;
            NextNode = nextNode;
        }
    }

    public class LinkedList<K, T>
    {
        public Node<K, T> m_Head;
        public LinkedList()
        {
            m_Head = new Node<K, T>();
        }
        public void AddHead(K key, T item) // додавання нод в список
        {
            Node<K, T> newNode = new Node<K, T>(key, item, m_Head.NextNode);
            m_Head.NextNode = newNode;
        }

    }
}
