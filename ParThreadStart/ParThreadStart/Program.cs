using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ParThreadStart
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 4;
            //создем новый поток
            Thread myThread = new Thread(new ParameterizedThreadStart(Count));
            //Thread myThread = new Thead(Count);//тоже саммое
            myThread.Start(number);//запуск потока

            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Главный поток: ");
                Console.WriteLine(i * i);
                Thread.Sleep(300);
            }
            Console.Read();
        }

        public static void Count(object x)
        {
            int n = (int)x; 
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Второй поток: ");
                Console.WriteLine(i*n);
                Thread.Sleep(400);
            }
        }
    }
}
