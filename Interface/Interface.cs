using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IStack
    {
        int Size { get; }

        bool Add(string symbol);
        void GetSize();
        void Operate(string symbol);
        void Print();
        void PrintList();
    }
}
