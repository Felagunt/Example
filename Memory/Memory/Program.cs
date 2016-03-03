using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//указатели
namespace Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                int* x;
                int y = 10;
                x = &y;
                //получаем адресс переменной y
                uint addr = (uint)x;
                Console.WriteLine("Adress y: {0}", addr);
                
                byte* bytePointer = (byte*)addr + 4;//указатель на следующий байт поле addr
                Console.WriteLine("Value int {0} from {1}", addr + 4, *bytePointer);
                //обратная операция
                uint oldAddr = (uint)bytePointer - 4;
                int* intPointer = (int*)oldAddr;
                Console.WriteLine("Value int {0} from {1}", oldAddr, *intPointer);
                //преобразоваие  в double
                double* doublePointer = (double*)addr + 4;
                Console.WriteLine("Value double {0} from {1}", addr+4, *doublePointer);
            }
          

        }
    }
}
