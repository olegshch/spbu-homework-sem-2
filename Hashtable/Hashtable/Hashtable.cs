using System;

namespace Hashtable
{
    public class Hashtable
    {
        /// <summary>
        /// Односвязный список из задачи 2.1
        /// </summary>
        private class List
        {
            /// <summary>
            /// Узел с данными и ссылкой на следующий элемент
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
            public int Size { get; set; }
           
            /// <summary>
            /// Проверка на пустоту
            /// </summary>
            public bool IsEmpty() => start == null;
           
            /// <summary>
            /// Проверка на корректность добавления
            /// </summary>
            /// <param name="position">проверяемая позиция</param>
            private bool CorrectAdd(int position) => position >= 0 && position < Size + 1;
            
            /// <summary>
            /// Проверка на корректность удаления
            /// </summary>
            /// <param name="position">проверяемая позиция</param>
            private bool Correct(int position) => position >= 0 && position < Size;

            /// <summary>
            /// Взятие элемента по позиции
            /// </summary>
            /// <param name="position">рассматриваемая позиция</param>
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
            /// Добавление элемента на позицию
            /// </summary>
            /// <param name="position">заданная позиция</param>
            /// <param name="data">заданное значение</param>
            public bool AddElement(int position, int data)
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
            /// Просмотр значения элемента по позиции
            /// </summary>
            /// <param name="position">рассматриваемая позиция</param>
            public int DataGet(int position)
            {
                if (!Correct(position)) return 0;
                Node current = Get(position);
                return current.Data;
            }

            /// <summary>
            /// Удаление элемента по позиции
            /// </summary>
            /// <param name="position">рассматриваемая позиция</param>
            public bool Delete(int position)
            {
                if (!Correct(position)) return false;
                if (position == 0) start = start.Next;
                else
                {
                    Node current = Get(position - 1);
                    current.Next = current.Next.Next;
                }
                Size--;
                return true;
            }

            /// <summary>
            /// Установка значения элемента на заданную позицию
            /// </summary>
            /// <param name="position">заданная позиция</param>
            /// <param name="data">устанавливаемое значение</param>
            /// <returns></returns>
            public bool Dataset(int position, int data)
            {
                if (!Correct(position)) return false;
                Node current = Get(position);
                current.Data = data;
                return true;
            }

            /// <summary>
            /// Проверка принадлежности элемента по значению списку 
            /// </summary>
            /// <param name="data">рассматриваемое значение</param>
            /// <returns></returns>
            public bool Exists(int data)
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
        }

        /// <summary>
        /// "высота таблицы"
        /// </summary>
        private int size;

        private List[] globalist;

        private IHashInterface hashing;

        /// <summary>
        /// Создание хеш-таблицы
        /// </summary>
        public Hashtable(IHashInterface hashing, int size)
        {
            globalist = new List[size];
            this.size = size;
            this.hashing = hashing;
            for (int i = 0; i < size; i++)
            {
                globalist[i] = new List();
            }
        }

        /// <summary>
        /// Вычисление хеша значения
        /// </summary>
        /// <param name="data">обрабатываемое значение</param>
        private int Hash(int data) => Math.Abs(hashing.Transform(data)) % size;
        

        /// <summary>
        /// Проверка на существование элемента в списке своего хеша
        /// </summary>
        /// <param name="data">обрабатываемое значение</param>
        public bool ExistsInHash(int data) => globalist[Hash(data)].Exists(data);

        /// <summary>
        /// Поверка на существование элемента в указанном списке
        /// </summary>
        /// <param name="data">искомый элемент</param>
        /// <param name="index">заданный список</param>
        /// <returns>true, если элемент содержится в указанном списке</returns>
        //public bool CustomCount(int data, int index) => globalist[index].Exists(data);

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="data">добавляемое значение</param>
        public bool Add(int data)
        {
            int hash = Hash(data);
            if (!globalist[hash].Exists(data))
            {
                globalist[hash].AddElement(globalist[hash].Size, data);
                Resize();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Удаление значения
        /// </summary>
        /// <param name="data">удаляемое значение</param>
        public bool Delete(int data)
        {
            int hash = Hash(data);
            if (globalist[hash].Exists(data))
            {
                
                for (int pos = 0; pos < globalist[hash].Size; pos++)
                {
                    if (globalist[hash].DataGet(pos) == data)
                    {
                        globalist[hash].Delete(pos);
                        return true;
                    }
                    
                }
            }
            return false;
        }

        /// <summary>
        /// Проверка на принадлежность элемента таблице
        /// </summary>
        /// <param name="data">проверяемое значение</param>
        public bool Exists(int data)
        {
            for (int i = 0; i < globalist.Length; i++)
            {
                if (globalist[i].Exists(data))
                {
                    return true;
                }
            }
            return false;
        }

        //public int Globalsize { get; set; }

        /// <summary>
        /// Общий размер таблицы как сумма размеров списков
        /// </summary>
        /// <returns>число элементов</returns>
        public int Size()
        {
            int amount = 0;
            for (int i = 0; i < size; i++)
            {
                amount += globalist[i].Size;
            }
            return amount;
        }

        public int Height() => size;

        private void Resize()
        {
            if (Size() > size * 10)
            {
                var newGlobalist = new List[size * 2];
                for (int i = 0; i < size * 2; i++)
                {
                    newGlobalist[i] = new List();
                }
                                
                for (int i = 0; i < size; i++)
                {                    
                    for (int j = 0; j < globalist[i].Size; j++)
                    {
                        int hash = Hash(globalist[i].DataGet(j));
                        newGlobalist[hash].AddElement(newGlobalist[hash].Size, globalist[i].DataGet(j));                            
                        
                    }
                }
                size *= 2;
                globalist = newGlobalist;                                
            }
        }
    }
}
