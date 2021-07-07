using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteArray
{
    public class Array
    {
        public List<byte> array = new List<byte>();
        public void AddArray(byte data)
        {
            array.Add(data);
        }
        public class Element
        {
            public int Count { get; set; }
            public byte Data { get; set; }
            public Element Next { get; set; }
            public Element(int count, byte data, Element next)
            {
                Count = count;
                Data = data;
                Next = next;
            }
        }

        private Element head;
        public int Size { set; get; }
        public bool IsEmpty() => head == null;
        private Element Get(int position)
        {
            Element current = head;
            for (int i = 1; i < position; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public void AddInList()
        {
            int pos=0;
            int count;
            while (pos < array.Count())
            {
                count = 0;
                if (array[pos] != array[pos + 1])
                {
                    count = 1;
                    pos++;
                }
                else
                {
                    while (array[pos] == array[pos + 1])
                    {
                        count++;
                        pos++;
                    }
                }
                var NewElement = new Element(count, array[pos], null);
                var Now = Get(Size);
                NewElement.Next = Now.Next;
                Now.Next = NewElement;
                Size++;
            }
        }
        public void Print()
        {
            Element current = head;
            while (current != null)
            {
                Console.Write($"{current.Count}, {current.Data}");
                current = current.Next;
            }
            Console.WriteLine();
        }

        
    }
}
