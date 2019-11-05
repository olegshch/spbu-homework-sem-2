using System;
using System.Collections.Generic;
using System.Collections;

namespace GenericList
{
    /// <summary>
    /// Односвязный список
    /// </summary>
    public class MyList<T> : IList<T>
    {
        /// <summary>
        /// Узел с данными и ссылкой на следующий
        /// </summary>
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node start;

        private Node finish;

        public int Count { get; private set; }

        /// <summary>
        /// Проверка на пустоту
        /// </summary>
        public bool IsEmpty() => start == null;

        /// <summary>
        /// true, если список IsReadOnly
        /// </summary>
        public bool IsReadOnly { get; set; } = false;

        public T this[int position]
        {
            get => GetData(position);
            set => Insert(position, value);
        }

        /// <summary>
        /// Проверка корректности удаления по позиции
        /// </summary>
        /// <param name="position">рассматриваемая позиция</param>
        /// <returns>true, если можно удалить</returns>
        private bool Correct(int position) => position >= 0 && position < Count;

        /// <summary>
        /// Взятие узла по позиции
        /// </summary>
        /// <param name="position">рассматриваемая позиция</param>
        /// <returns>найденный узел</returns>
        private Node Get(int position)
        {
            Node current = start;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }
            return current;
        }

        /// <summary>
        /// Копирует элементы списка в массив, начиная с указанного индекса массива
        /// </summary>
        /// <param name="array">массив, в который копируется список</param>
        /// <param name="index">начальная позиция в массиве для копирования</param>
        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (index + Count > array.Length)
            {
                throw new ArgumentException();
            }
            Node current = start;
            for (int i = 0; i < Count; i++)
            {
                array[index + i] = current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="position">позиция добавления</param>
        /// <param name="data">добавляемый элемент</param>
        public void Add(T data)
        {
            var newNode = new Node(data, null);
            if (Count == 0)
            {
                newNode.Next = start;
                start = newNode;
                finish = start;
            }
            else
            {               
                finish.Next = newNode;
                finish = newNode;
            }
            Count++;
        }

        /// <summary>
        /// Взятие элемента по позиции
        /// </summary>
        /// <param name="position">искомая позиция</param>
        /// <returns>элемент на заданной позиции</returns>
        public T GetData(int position)
        {
            if (!Correct(position))
            {
                throw new System.ArgumentOutOfRangeException();
            }
            Node current = Get(position);
            return current.Data;
        }

        /// <summary>
        /// Удаление элемента по позиции
        /// </summary>
        /// <param name="position">рассматриваемая позиция</param>
        /// <returns>true, если элемент успешно удален</returns>
        public void RemoveAt(int position)
        {
            if (!Correct(position))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (position == 0)
            {
                start = start.Next;
            }
            else
            {
                Node current = Get(position - 1);
                if (current.Next == finish)
                {
                    finish = current;
                }
                current.Next = current.Next.Next;
            }
            Count--;
        }

        /// <summary>
        /// Установка элемента в существующую позицию
        /// </summary>
        /// <param name="position">заданная позиция</param>
        /// <param name="data">устанавливаемое значение</param>
        public void Insert(int position, T data)
        {
            if (!Correct(position))
            {
                throw new System.InvalidOperationException();
            }
            Node current = Get(position);
            current.Data = data;
        }

        /// <summary>
        /// Поиск элемента по значению
        /// </summary>
        /// <param name="data">искомое значение</param>
        /// <returns>true, если элемент найден</returns>
        public bool Contains(T data)
        {
            Node current = start;
            for (int i = 0; i < Count; i++)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Удаляет первое вхождение указанного объекта из коллекции
        /// </summary>
        /// <param name="data">искомый объект</param>
        /// <returns>true, если удаление было успешным</returns>
        public bool Remove(T data)
        {
            Node current = start;
            for (int i = 0; i < Count; i++)
            {
                if (current.Data.Equals(data))
                {
                    RemoveAt(i);
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Осуществляет поиск указанного объекта и возвращает отсчитываемый от нуля индекс первого вхождения, найденного в пределах всего списка
        /// </summary>
        /// <param name="data">искомый элемент</param>
        /// <returns>индекс первого вхождения элемента</returns>
        public int IndexOf(T data)
        {
            Node current = start;
            for (int i = 0; i < Count; i++)
            {
                if (current.Data.Equals(data))
                {
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }

        /// <summary>
        /// Удаление элементов по значению
        /// </summary>
        /// <param name="data">удаляемый элемент</param>
        /// <returns>true, если удаление было успешным</returns>
        public void Clear()
        {
            Count = 0;
            start = null;
        }

        /// <summary>
        /// Энумератор списка
        /// </summary>
        /// <returns>каждый элемент списка</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var current = start;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
