using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RareVector
{
    public class Vector
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data, Node next)
            {
                Data = data;
                Next = next;
            }
        }
        private SortedSet<int> myset;
        private Node start;
        public int Size { get; set; }
        public bool IsEmpty() => myset.Count == 0;
        private bool CorrectAdd(int position, int data) => position > 0 && data != 0;
        private bool Correct(int position) => position > 0 && position <= Size;
        private Node Get(int position)
        {
            Node current = start;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }
            return current;
        }
        public bool Add(int position, int data)
        {
            if (CorrectAdd(position, data) == false) return false;
            Node newNode = new Node(data, null);
            if (position == 1)
            {
                newNode.Next = start;
                start = newNode;
                myset.Add(position);
            }
            else
            {
                var current = Get(position);
                newNode.Next = current.Next;
                current.Next = newNode;
                myset.Add(position);
            }
            Size = position;
            return true;
        }
        public bool Delete(int position)
        {
            if (!Correct(position))
            {
                return false;
            }

            if (position == 1)
            {
                start = start.Next;
                Size--;
            }
            else
            {
                Node current = Get(position - 1);
                current.Next = current.Next.Next;
            }
            if (position == Size) Size--;
            return true;
        }
        public int Dataget(int position)
        {
            if (Correct(position) == false) return 0;
            if (myset.Contains(position))
            {
                Node current = Get(position);
                return current.Data;
            }
            return 0;
        }
        public bool Dataset(int position, int data)
        {
            if (Correct(position) == false) return false;
            Node current = Get(position);
            current.Data = data;
            return true;
        }

        public bool Summ(Vector vector)
        {
            for (int i = 1; i <= Math.Max(Size, vector.Size); i++)
            {
                if (myset.Contains(i) && vector.myset.Contains(i)) Dataset(i, Dataget(i) + vector.Dataget(i));
                if (!myset.Contains(i) && vector.myset.Contains(i)) Add(i, vector.Dataget(i));
                if (Dataget(i) == 0) Delete(i);
            }
            return true;

        }
        public int Multiply(Vector vector)
        {
            int result = 0;
            for(int i = 0; i < Math.Max(Size, vector.Size); i++)
            {
                if(myset.Contains(i) && vector.myset.Contains(i))
                {
                    result += Dataget(i) * vector.Dataget(i);
                }
            }

            return result;
       
        }



        public Vector Clone()
        {
            Vector clonevector = new Vector();
            for (int i = 0; i < Size; i++)
            {
                if (myset.Contains(i)) clonevector.Add(i, Dataget(i));
                clonevector.myset.Add(i);
            }
            clonevector.Size = Size;
            return clonevector;
        }
    }
}



