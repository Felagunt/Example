using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamReaderAndWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\SomeDir\note.txt";
            Console.WriteLine("0-reader 2-write");
            switch(Int32.Parse(Console.ReadLine()))
            {
                case 0:
                    {
                        try
                        {
                            Console.WriteLine("*******");
                            using (StreamReader sr = new StreamReader(path))
                            {
                                Console.WriteLine(sr.ReadToEnd());
                            }

                            Console.WriteLine();
                            Console.WriteLine("******считываем построчно********");
                            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                            {
                                string line;
                                while ((line =sr.ReadLine()))!=null)//ggw
                                    {
                                    Console.WriteLine(line);
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine("******считываем блоками********");
                            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                            {
                                char[] array = new char[4];
                                // считываем 4 символа
                                sr.Read(array, 0, 4);

                                Console.WriteLine(array);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }
                case 1:
                    {
                        string readPath = @"C:\SomeDir\note.txt";
                        string writePath = @"C:\SomeDir\notew.txt";
                        string text = "";
                        try
                        {
                            using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
                            {
                                text = sr.ReadToEnd();
                            }
                            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                            {
                                sw.Write(text);
                            }
                            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine("Дозапиь");
                                sw.Write(4.5);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }
            }
        }
    }
}
