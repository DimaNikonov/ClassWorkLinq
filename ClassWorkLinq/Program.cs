using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWorkLinq
{
    class Program
    {
        public class Person
        {
            public int PersonId;
            public string FullName;
        }

        public class Car
        {
            public int CarId;
            public string Model;
            public int PersonId;
            public string Color;
            public DateTime CreationDate;
        }

        public class MySort : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                int countX = 0;
                int countY = 0;

                foreach (var item in x)
                {
                    if (item == 'a' || item == 'e') countX++;
                }

                foreach (var item in y)
                {
                    if (item == 'a' || item == 'e') countY++;
                }

                if (countX > countY) return 1;
                else if (countX < countY) return -1;
                else return 0;
            }

        }
        static void Main(string[] args)
        {


            //Console.WriteLine();

            //MySort ms = new MySort();
            //List<string> firstList = new List<string> { "alsdfk", "asdfgs", "testq", "adgdfk", "aabcqw", "aabck" };
            //List<string> secondList = new List<string> { "al123fk", "asd456fgs", "testq", "ad12gdfk", "aabc23qw", "aabck" };
            //var stTemp = firstList.Where((t, i) => t.StartsWith("a") && t.EndsWith("k") && (i + 1) % 2 == 0).ToArray();
            //Console.WriteLine(string.Join(" ", stTemp));

            //var strTemp = firstList.Where(t => t.StartsWith("aa")).Select(t => t.Length).ToArray();
            //Console.WriteLine(string.Join(" ", strTemp));

            //var strTemp1 = firstList.Select(t => new { str1 = t, count = t.Length });
            //foreach (var item in strTemp1)
            //{
            //    Console.WriteLine(item.str1 + "-" + item.count);
            //}

            //var strTemp2 = firstList.Select(t => { return $" {t}   {t.Length }\n"; });
            //Console.WriteLine(string.Join("", strTemp2));

            //var strTemp3 = string.Join(" ", firstList.SelectMany(t => string.Join(" ", t)));
            //Console.WriteLine(strTemp3);

            //var strTemp4 = firstList.TakeWhile(t => t.StartsWith("a")).ToArray();
            //Console.WriteLine(string.Join(" ", strTemp4));

            //var strTemp5 = firstList.Where(t => t.ToUpper().Contains("AABC")).ToArray();
            //Console.WriteLine(string.Join(" ", strTemp5));

            //var strTemp6 = firstList.Skip(1).Concat(secondList.Skip(1));
            //Console.WriteLine(string.Join(" ", strTemp6));

            //var strTemp7 = firstList.Intersect(secondList);
            //Console.WriteLine(string.Join(" ", strTemp7));

            //var strTemp8 = firstList.Except(secondList).Concat(secondList.Except(firstList));
            //Console.WriteLine(string.Join(" ", strTemp8));

            //Console.WriteLine();

            //var strTemp9 =  firstList.Concat(secondList).ToList();
            //strTemp9.Sort(ms);
            //foreach (var item in strTemp9)
            //{
            //    Console.WriteLine(item);
            //}

            List<Person> persons = new List<Person>()
            {
                new Person { PersonId = 1, FullName = "user1" },
                new Person { PersonId = 2, FullName = "user2" },
                new Person { PersonId = 3, FullName = "user3" },
                new Person { PersonId = 4, FullName = "user4" }
            };

            List<Car> cars = new List<Car>()
            {
                    new Car { CarId = 1, Color = "Green", Model = "Tesla S", PersonId = 1, CreationDate = new DateTime(2015, 4, 1) },
                    new Car { CarId = 2, Color = "Blue", Model = "BMW 5", PersonId = 1, CreationDate = new DateTime(2010, 4, 1) },
                    new Car { CarId = 3, Color = "Green", Model = "Tesla S", PersonId = 2, CreationDate = new DateTime(2015, 2, 2) },
                    new Car { CarId = 4, Color = "Green", Model = "BMW 3", PersonId = 3, CreationDate = new DateTime(2013, 4, 1) },
                    new Car { CarId = 5, Color = "White", Model = "Tesla S", PersonId = 3, CreationDate = new DateTime(2012, 4, 1) }
            };

            var strTemp1 = persons.SelectMany(t => cars.Where(f => f.PersonId==t.PersonId).Select(f=>new { name = f.Model, fullname = t.FullName }));
            foreach (var item in strTemp1)
            {
                Console.WriteLine(item.fullname+" "+item.name);
            }

            var strTemp2 = persons.SelectMany(t => cars.Where(f => f.PersonId == t.PersonId).Where(f=>f.Color=="Blue").Select(f=>t.FullName));
            foreach (var item in strTemp2)
            {
                Console.WriteLine(item);
            }
        }
    }
}


