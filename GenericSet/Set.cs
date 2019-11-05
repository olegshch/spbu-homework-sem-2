using System.Collections.Generic;

namespace GenericSet
{
    public class Set<T> : ISet<T>
    {
        private class Node
        { 
            public T Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            //public Node Parent { get; set; }
        }

        private Node root;

        public int Count { get; private set; }

        /// <summary>
        /// true, если множество IsReadOnly
        /// </summary>
        public bool IsReadOnly { get; set; } = false;

        /// <summary>
        /// проверка на наличие элемента в множестве со стартовым узлом
        /// </summary>
        /// <param name="data">искомое значение</param>
        /// <param name="current">стартовый узел поиска</param>
        /// <returns>true, если элемент присутствует</returns>
        private bool ContainsWithNode(T data, Node current)
        {
            if (current == null)
            {
                return false;
            }
            return (current.Data.Equals(data) || ContainsWithNode(data, current.Left) || ContainsWithNode(data, current.Right));
        }

        /// <summary>
        /// проверка на наличие элемента в множестве
        /// </summary>
        /// <param name="data">искомый элемент</param>
        /// <returns>true, если элемент присутствует</returns>
        public bool Contains(T data) => ContainsWithNode(data, root);

        /// <summary>
        /// очистка множества
        /// </summary>
        public void Clear()
        {
            root = null;
            Count = 0;
        }
        
        /// <summary>
        /// добавление по узлу
        /// </summary>
        /// <param name="data">значение узла</param>
        /// <param name="current">текущий узел</param>
        private void AddInNode(T data, Node current, Node parent)
        {
            if(current == null)
            {
                current = new Node();
                current.Data = data;
                Count++;
                //return true;
            }
            else
            {
                if (data.GetHashCode() >= current.Data.GetHashCode())
                {
                    AddInNode(data, current.Right, current);
                }
                else
                {
                    AddInNode(data, current.Left, current);
                }
                Count++;
                //return true;
            }
        }

        /// <summary>
        /// добавлене в множество
        /// </summary>
        /// <param name="data">значение</param>
        public void Add(T data) => AddInNode(data, root, null);

    }
}
