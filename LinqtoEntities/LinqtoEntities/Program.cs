using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LinqtoEntities
{
    class Program
    {
        static void Main(string[] args)
        {
            //выборка
            using (PhoneContext db = new PhoneContext())
            {
                var phones = db.Phones.Where(p => p.Company.Name = "Samsung");
                foreach (var p in phones)
                    Console.WriteLine("{0}.{1}-{2}", p.Id, p.Name, p.Price);
            }
            //проекция
            using (PhoneContext db = new PhoneContext())
            {
                var phones = db.Phones.Select(p => new//создание анонимного типа
                {
                    Name = p.Name,
                    Price = p.Price,
                    Company = p.Company.Name
                })
                .OrderBy(p => p.Price).ThenBy(p => p.Company);//сортировка по цене и компаниям
                foreach (var p in phones)
                    Console.WriteLine("{0} ({1}) - {2}", p.Name, p.Company, p.Price);
            }
            //объединение таблиц
            using (PhoneContext db = new PhoneContext())
            {
                var phones = db.Phones.Join(db.Companies,
                    p => p.CompanyId,
                    c => c.Id,
                    (p, c) => new
                    {
                        Name = p.Name,
                        Company = c.Name,
                        Price = p.Price
                    });
                foreach (var p in phones)
                    Console.WriteLine("{0} ({1}) - {2}", p.Name, p.Company, p.Price);
            }

            //объединение таблиц в один набор
            using (PhoneContext db = new PhoneContext())
            {
                var result = from phone in db.Phones
                             join company in db.Companies on phone.CompanyId equals company.Id
                             join country in db.Countries on company.CountryId equals country.Id
                             select new
                             {
                                 Name = phone.Name,
                                 Company = company.Name,
                                 Price = phone.Price,
                                 Country = country.Name
                             };
                foreach (var p in result)
                    Console.WriteLine("{0} {1} ({2}) : {3}", p.Country, p.Name, p.Company, p.Price);
            }

            //группировка данных по параметрам
            using (PhoneContext db = new PhoneContext())
            {
                var group = db.Phones.GroupBy(p => p.Company.Name);
                foreach (var g in group)
                {
                    Console.WriteLine(g.Key);
                    foreach (var p in g)
                        Console.WriteLine("{0} - {1}", p.Name, p.Price);
                    Console.WriteLine();
                }
            }

            //количество элементов
            using (PhoneContext db = new PhoneContext())
            {
                var groups = db.Phones.GroupBy(p => p.Company.Name)
                    .Select(g => new { Name = g.Key, Count = g.Count() });
                foreach (var c in groups)
                    Console.WriteLine("Company: {0} How many: {1}", c.Name, c.Count);
            }
            //объединение - только сходные наборы выборок
            using (PhoneContext db = new PhoneContext())
            {
                var phones = db.Phones.Where(p => p.Price < 600)
                    .Union(db.Phones.Where(p => p.Name.Contains("Samsung")));
                //одоко можно тк обе формируют один солбец нейм
                //var result = db.Phones.Select(p=> new {Name = p.Name})
                //.Union(db.Companies.Select(c=> new {Name = c.Name}));
                foreach (var item in phones)
                    Console.WriteLine(item.Name);
            }

            //пересечение двух выборок
            using (PhoneContext db = new PhoneContext())
            {
                var phones = db.Phones.Where(p => p.Price < 600)
                    .Intersect(db.Phones.Where(p => p.Name.Contains("Samsung")));
                foreach (var item in phones)
                    Console.WriteLine(item.Name);
            }
            //разость - элементы из 1о выборке отсутствующие во второй
            using (PhoneContext db = new PhoneContext())
            {
                var selector1 = db.Phones.Where(p => p.Price < 600); // Samsung Galaxy S4, Samsung Galaxy S4, iPhone S4
                var selector2 = db.Phones.Where(p => p.Name.Contains("Samsung")); // Samsung Galaxy S4, Samsung Galaxy S4
                var phones = selector1.Except(selector2); // результат -  iPhone S4

                foreach (var item in phones)
                    Console.WriteLine(item.Name);
            }

            //max\min\average
            using (PhoneContext db = new PhoneContext())
            {
                int minPrice = db.Phones.Min(p => p.Price);
                int maxPrice = db.Phones.Max(p => p.Price);
                double avgPrice = db.Phones.Where(p => p.Company.Name == "Samsung")
                    .Average(p => p.Price);
                Console.WriteLine(minPrice);
                Console.WriteLine(maxPrice);
                Console.WriteLine(avgPrice);
            }

            //sum
            using (PhoneContext db = new PhoneContext())
            {
                int sum1 = db.Phones.Sum(p => p.Price);
                int sum2 = db.Phones.Where(p => p.Name.Contains("Sumsung").Sum(p => p.Price));
                Console.WriteLine(sum1);
                Console.WriteLine(sum2);
            }
    }
}
