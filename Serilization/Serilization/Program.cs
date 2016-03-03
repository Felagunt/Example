using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serilization
{
    class Program
    {
        static void Main(string[] args)
        {
            //объект серилзаии
            Person person1 = new Person("Tom", 29);
            Person person2 = new Person("Bob", 25);
            Person[] people = new Person[] { person1, person2 };
            Console.WriteLine("Obj create");

            //создаем объект бинари форматер
            BinaryFormatter formatter = new BinaryFormatter();
            //получаем пото куда бдем зписсывть сеилизовный объект
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
                Console.WriteLine("Obj serialized");
            }

            //десеарилизация из файл пипл.дат
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                Person[] deserilizePeople = (Person[])formatter.Deserialize(fs);
                Console.WriteLine("Obj desiariliz");
                foreach (Person p in deserilizePeople)
                {
                    Console.WriteLine("Name {0} - Age {1}", p.Name, p.Year);
                }
            }
            Console.ReadKey();
        }
    }
}
