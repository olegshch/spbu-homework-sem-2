using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{
    public class List
    {
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
        public bool IsEmpty() => start == null;
        private bool CorrectAdd(int position) => position >= 0 && position < Size+1 ;
        private bool Correct(int position) => position >= 0 && position < Size ;
        private Node Get (int position)
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
                if (CorrectAdd(position) == false) return false;
                Node newNode = new Node(data, null);
                if (position == 0)
                {
                    newNode.Next = start;
                    start = newNode;
                }
                else
                {
                    var current = Get(position);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                }
                Size++;
                return true;
            }
        public int Dataget(int position)
            {
                if (Correct(position) == false) return 0;
                Node current = Get(position);
                return current.Data;
            }
        public bool Delete(int position)
            {
                if (Correct(position) == false) return false;
                if (position == 0) start = start.Next;
                else
                {
                    Node current = Get(position - 1);
                    current.Next = current.Next.Next;
                }
                Size--;
                return true;
            }
        public bool Dataset(int position,int data)
            {
                if (Correct(position) == false) return false;
                Node current = Get(position);
                current.Data = data;
                return true;
            }
        

    }
}
