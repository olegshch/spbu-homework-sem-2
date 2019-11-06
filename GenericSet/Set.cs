using System.Collections.Generic;
using System.Collections;

namespace GenericSet
{
    public class Set<T> : ISet<T>
    {
        /// <summary>
        /// Узел
        /// </summary>
        private class Node
        { 
            /// <summary>
            /// Значение
            /// </summary>
            public T Data { get; set; }

            /// <summary>
            /// Левый сын
            /// </summary>
            public Node Left { get; set; }

            /// <summary>
            /// Правый сын
            /// </summary>
            public Node Right { get; set; }
        }

        /// <summary>
        /// Корень древовидного множества
        /// </summary>
        private Node root;

        /// <summary>
        /// Количество элементов
        /// </summary>
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
            else
            {
                if (data.GetHashCode() < current.Data.GetHashCode())
                {
                    return (ContainsWithNode(data, current.Left));
                }
                else
                {
                    return (current.Data.Equals(data) || ContainsWithNode(data, current.Right));
                }
            }            
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
        private bool AddInNode(T data, Node current, Node parent)
        {
            if (Contains(data))
            {
                return false;
            }
            if (current == null)
            {
                current = new Node();
                current.Data = data;
                Count++;
                return true;
            }
            else
            {
                if (data.GetHashCode() > current.Data.GetHashCode())
                {
                    AddInNode(data, current.Right, current);
                }
                else
                {
                    AddInNode(data, current.Left, current);
                }
                Count++;
                return true;
            }
        }

        /// <summary>
        /// добавлене в множество
        /// </summary>
        /// <param name="data">значение</param>
        public bool Add(T data) => AddInNode(data, root, null);

        /// <summary>
        /// Похоже, добавление элемента для обратной совместимости
        /// </summary>
        /// <param name="data"></param>
        void ICollection<T>.Add(T data) => Add(data);

        /// <summary>
        /// Добавляет недостающие элементы из сторонней коллекции в множество
        /// </summary>
        /// <param name="other"></param>
        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException();
            }
            foreach (T data in other)
            {
                if (!Contains(data))
                {
                    Add(data);
                }
            }
        }
        
        /// <summary>
        /// Удаление узла 
        /// </summary>
        /// <param name="current">текущий узел</param>
        /// <returns>true, если удаление прошло успешным</returns>
        private bool DeleteWithNode(Node current)
        {
            if (current.Left == null && current.Right == null)
            {
                current = null;
                Count--;
                return true;
            }
            else
            {
                T transit = current.Data;
                if (current.Left != null)
                {
                    current.Data = current.Left.Data;
                    current.Left.Data = transit;
                    DeleteWithNode(current.Left);
                }
                else
                {
                    current.Data = current.Right.Data;
                    current.Right.Data = transit;
                    DeleteWithNode(current.Right);
                }
            }
            return false;
        }

        /// <summary>
        /// Удаление узла с заданным значением в поддереве
        /// </summary>
        /// <param name="data">удаляемое значение</param>
        /// <param name="current">корень поддерева</param>
        /// <returns>true, если удаление прошло успешно</returns>
        private bool DeleteWithData(T data, Node current)
        {
            if (!Contains(data)) 
            { 
                if (current.Data.Equals(data))
                {
                    DeleteWithNode(current);
                }
                else
                {
                    if (data.GetHashCode() < current.Data.GetHashCode())
                    {
                        DeleteWithData(data, current.Left);
                    }
                    else
                    {
                        DeleteWithData(data, current.Right);
                    }
                }
            }
            return false;
            
        }

        /// <summary>
        /// Удаление из множества
        /// </summary>
        /// <param name="data">удаляемое значение</param>
        /// <returns>true, удаление прошло успешно</returns>
        public bool Remove(T data) => DeleteWithData(data, root);
    }
}
