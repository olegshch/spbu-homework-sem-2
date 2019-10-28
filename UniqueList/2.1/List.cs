using System;

namespace _2._1
{
    /// <summary>
    /// Односвязный список
    /// </summary>
    public class List
    {
        /// <summary>
        /// Узел с данными и ссылкой на следующий
        /// </summary>
        private class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node start;
        public int Size { get; private set; }

        /// <summary>
        /// Проверка на пустоту
        /// </summary>
        public bool IsEmpty() => start == null;

        /// <summary>
        /// Проверка на корректное добавление по позиции
        /// </summary>
        /// <param name="position">рассматриваемая розиция</param>
        /// <returns>true, если можно добавить/returns>
        private bool CorrectAdd(int position) => position >= 0 && position < Size + 1;

        /// <summary>
        /// Проверка корректности удалениz по позиции
        /// </summary>
        /// <param name="position">рассматриваемая позиция</param>
        /// <returns>true, если можно удалить</returns>
        private bool Correct(int position) => position >= 0 && position < Size;

        /// <summary>
        /// Взятие элемента по позиции
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
        /// Добавление элемента
        /// </summary>
        /// <param name="position">позиция добавления</param>
        /// <param name="data">добавляемый элемент</param>
        public virtual bool Add(int position, int data)
        {
            if (!CorrectAdd(position))
            {
                return false;
            }
            var newNode = new Node(data, null);
            if (position == 0)
            {
                newNode.Next = start;
                start = newNode;
            }
            else
            {
                var current = Get(position - 1);
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            Size++;
            return true;
        }

        /// <summary>
        /// Взятие элемента по позиции
        /// </summary>
        /// <param name="position">искомая позиция</param>
        /// <returns>элемент на заданной позиции</returns>
        public int Dataget(int position)
        {
            if (!Correct(position))
            {
                return 0;
            }
            Node current = Get(position);
            return current.Data;
        }

        /// <summary>
        /// Удаление элемента по позиции
        /// </summary>
        /// <param name="position">рассматриваемая позиция</param>
        /// <returns>true, если элемент успешно удален</returns>
        public bool Delete(int position)
        {
            if (!Correct(position))
            {
                throw new IndexOutOfRangeException();
            }
            if (position == 0)
            {
                start = start.Next;
            }
            else
            {
                Node current = Get(position - 1);
                current.Next = current.Next.Next;
            }
            Size--;
            return true;
        }

        /// <summary>
        /// Установка элемента в существующую позицию
        /// </summary>
        /// <param name="position">заданная позиция</param>
        /// <param name="data">устанавливаемое значение</param>
        /// <returns>true, если установка была успешной</returns>
        public virtual bool Dataset(int position,int data)
        {
            if (!Correct(position))
            {
                return false;
            }
            Node current = Get(position);
            current.Data = data;
            return true;
        }

        /// <summary>
        /// Поиск элемента по значению
        /// </summary>
        /// <param name="data">искомое значение</param>
        /// <returns>true, если элемент найден</returns>
        public bool Count(int data)
        {
            Node current = start;
            for (int i = 0; i < Size; i++)
            {
                if (current.Data == data)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Удаление элементов по значению
        /// </summary>
        /// <param name="data">удаляемый элемент</param>
        /// <returns>true, если удаление было успешным</returns>
        public bool DeleteByData(int data)
        {
            if (!Count(data))
            {
                throw new UnexistingElementException(); 
            }
            Node current = start;
            for (int i = 0; i < Size; i++)
            {
                if (current.Data == data)
                {
                    Delete(i);
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }

    /// <summary>
    /// Исключение для несуществующих элементов
    /// </summary>
    public class UnexistingElementException : Exception
    {
    }
}
