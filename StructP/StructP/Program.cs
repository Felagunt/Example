using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructP
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                switch(Int32.Parse(Console.ReadLine()))
                {
                    case 0:
                        {
                            Person person;
                            person.age = 29;
                            person.height = 179;
                            Person* p = &person;
                            p->age = 30;
                            Console.WriteLine(p->age);

                            //разименование
                            (*p).height = 180;
                            Console.WriteLine((*p).height);
                            break;
                        }
                    case 1:
                        {
                            Persons persons = new Persons();
                            persons.age = 29;
                            persons.height = 170;
                            //блок фиксации указателя
                            fixed(int*p = &persons.age)
                            {
                                if (*p < 30)
                                    *p = 30;
                            }
                            Console.WriteLine(persons.age);
                            break;
                        }
                    case 2:
                        {
                            const int size = 7;
                            int* factorial = stackalloc int[size];//выделяем память
                            int* p = factorial;
                            *(p++) = 1;//первая ячейка=1 и указатель ++
                            //
                            for (int i = 2; i <= size; i++,p++)
                            {
                                //считываем факториал числа
                                *p = p[-1] * i;
                            }
                            for(int i=1;i<=size;++i)
                            {
                                Console.WriteLine(factorial[i - 1]);
                            }
                            break;
                        }
                }
            }
        }
    }

    public struct Person
    {
        public int age;
        public int height;
    }

    public class Persons
    {
        public int age;
        public int height;
    }
}
