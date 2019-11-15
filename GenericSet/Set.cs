using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace GenericSet
{
    /// <summary>
    /// Генерик множество
    /// </summary>
    /// <typeparam name="T">тип значений</typeparam>
    public class MySet<T> : ISet<T>
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

            /// <summary>
            /// Родитель
            /// </summary>
            public Node Parent { get; set; }
        }

        /// <summary>
        /// Корень древовидного множества
        /// </summary>
        private Node root = null;

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
            if (current.Data.Equals(data))
            {
                return true;
            }
            else
            {
                if (data.GetHashCode() < current.Data.GetHashCode())
                {
                    return ContainsWithNode(data, current.Left);
                }
                else
                {
                    return ContainsWithNode(data, current.Right);
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
        /// добавлене в множество
        /// </summary>
        /// <param name="data">значение</param>
        public bool Add(T data)
        {
            if (Count == 0)
            {
                root = new Node
                {
                    Data = data
                };
                Count++;
                return true;
            }
            if (Contains(data))
            {
                return false;
            }
            var newNode = new Node
            {
                Data = data
            };
            var current = root;
            while (current.Left != null || current.Right != null)
            {
                if (data.GetHashCode() > current.Data.GetHashCode())
                {
                    if (current.Right == null)
                    {
                        current.Right = newNode;
                        current.Right.Parent = current;
                        break;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left == null)
                    {
                        current.Left = newNode;
                        current.Left.Parent = current;
                        break;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
            }
            if (data.GetHashCode() > current.Data.GetHashCode())
            {
                current.Right = newNode;
                current.Right.Parent = current;
            }
            else
            {
                current.Left = newNode;
                current.Left.Parent = current;
            }
            Count++;
            return true;            
        }

        /// <summary>
        /// Похоже, добавление элемента для обратной совместимости
        /// </summary>
        /// <param name="data"></param>
        void ICollection<T>.Add(T data) => Add(data);

        /// <summary>
        /// Добавляет недостающие элементы из сторонней коллекции в множество
        /// </summary>
        /// <param name="other">сторонняя коллекция</param>
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

        private Node Get(T data)
        {
            if (!Contains(data))
            {
                throw new System.ArgumentException();
            }
            Node current = root;
            while (!current.Data.Equals(data))
            {
                if (data.GetHashCode() > current.Data.GetHashCode())
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }
            return current;
        }

        /// <summary>
        /// Удаление из множества
        /// </summary>
        /// <param name="data">удаляемое значение</param>
        /// <returns>true, удаление прошло успешно</returns>
        public bool Remove(T data)
        {
            if (!Contains(data))
            {
                return false;
            }
            if (Count == 1)
            {
                root = null;
                Count--;
                return true;
            }
            var current = Get(data);

            //1 случай: нет потомков
            if (current.Left == null && current.Right == null)
            {
                if (current.Parent.Left != null && current.Parent.Left.Data.Equals(current.Data))
                {
                    current.Parent.Left = current.Left;
                }
                else
                {
                    current.Parent.Right = current.Right;
                }
                Count--;
                return true;
            }

            //2 случай: только 1 потомок
            if (current.Left == null && current.Right != null || current.Right == null && current.Left != null)
            {
                //только правый потомок
                if (current.Left == null)
                {
                    if (current.Parent.Left != null && current.Parent.Left.Data.Equals(current.Data))
                    {
                        current.Parent.Left = current.Right;
                    }
                    else
                    {
                        current.Parent.Right = current.Right;
                    }
                }

                //только левый потомок
                else
                {
                    if (current.Parent.Left != null && current.Parent.Left.Data.Equals(current.Data))
                    {
                        current.Parent.Left = current.Left;
                    }
                    else
                    {
                        current.Parent.Right = current.Left;
                    }
                }
                Count--;
                return true;
            }

            //3 случай: есть 2 потомка
            if(current.Left != null && current.Right != null)
            {
                var alternative = current.Right;
                while (alternative.Left != null)
                {
                    alternative = alternative.Left;
                }
                alternative.Parent.Left = alternative.Right;
                current.Data = alternative.Data;
                Count--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Является ли other подмножетвом данного множества
        /// </summary>
        /// <param name="other">анализируемая коллекция</param>
        /// <returns>true, если является</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException();
            }
            foreach (T element in other)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Является ли данное множество подмножетвом other
        /// </summary>
        /// <param name="other">анализируемая коллекция</param>
        /// <returns>true, если является</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException();
            }
            foreach (var current in this)
            {
                if (!other.Contains(current))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Содержат ли множества одни и те же элементы
        /// </summary>
        /// <param name="other">сравниваемая коллекция</param>
        /// <returns>true, если множества содержат одни и те же элементы</returns>
        public bool SetEquals(IEnumerable<T> other) => IsSubsetOf(other) && IsSupersetOf(other);
        
        
        /// <summary>
        /// Пересекаются ли коллекции
        /// </summary>
        /// <param name="other">сравниваемая коллекция</param>
        /// <returns>true, если пересекаются</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException();
            }
            foreach (T element in other)
            {
                if (Contains(element))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Удаляет элементы коллекции из данного множества
        /// </summary>
        /// <param name="">задаваемая коллекция</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException();
            }
            foreach (T element in other)
            {
                if (Contains(element))
                {
                    Remove(element);
                }
            }
        }

        /// <summary>
        /// list for set Enumerator
        /// </summary>
        List<T> iteratorList = new List<T>();

        /// <summary>
        /// DFS algorithm for set Enumerator with list
        /// </summary>
        /// <param name="current">current node</param>
        private void DFS(Node current)
        {
            if (current.Left == null && current.Right == null)
            {
                iteratorList.Add(current.Data);
            }
            else
            {
                if (current.Left != null)
                {
                    DFS(current.Left);
                }
                if (current.Right != null)
                {
                    DFS(current.Right);
                }
                iteratorList.Add(current.Data);
            }

        }
        
        /// <summary>
        /// Enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            iteratorList.Clear();
            DFS(root);
            for (int i = 0; i < iteratorList.Count; i++)
            {
                yield return iteratorList[i];
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        /// <summary>
        /// Копирует элементы множества в массив, начиная с указанного индекса массива
        /// </summary>
        /// <param name="array">массив, в который копируется список</param>
        /// <param name="index">начальная позиция в массиве для копирования</param>
        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new System.ArgumentNullException();
            }

            if (index + Count > array.Length)
            {
                throw new System.ArgumentException();
            }

            int position = 0;
            foreach (var current in this)
            {
                array[index + position] = current;
                position++;
            }            
        }

        /// <summary>
        /// Является ли данное множество строгим подмножеством other
        /// </summary>
        /// <param name="other">анализируемая коллекция</param>
        /// <returns>true, если является</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other) => IsSubsetOf(other) && !IsSupersetOf(other);

        /// <summary>
        /// Является ли данное множество строгим надмножеством other
        /// </summary>
        /// <param name="other">анализируемая коллекция</param>
        /// <returns>true, если является</returns>
        public bool IsProperSupersetOf(IEnumerable<T> other) => !IsSubsetOf(other) && IsSupersetOf(other);

        /// <summary>
        /// Объединение данного множества с другим множеством без их пересечения
        /// </summary>
        /// <param name="other">другое множество</param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException();
            }

            var transit = new SortedSet<T>();
            transit.UnionWith(other);
            transit.IntersectWith(this);
            UnionWith(other);
            ExceptWith(transit);
        }

        /// <summary>
        /// Оставляет в данном множестве только общие с другим множеством элементы
        /// </summary>
        /// <param name="other">другое множество</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException();
            }
            foreach (var element in this)
            {
                if (!other.Contains(element))
                {
                    Remove(element);
                }
            }
        }
    }
}
