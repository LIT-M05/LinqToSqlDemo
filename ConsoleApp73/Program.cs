using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp73
{
    class Program
    {
        static void Main(string[] args)
        {
            PeopleDataContext context = new PeopleDataContext();
            context.Log = Console.Out;

            Person oldest = context.Persons.OrderBy(p => p.Age).First();
            oldest.LastName = " and I'm youngest";
            context.SubmitChanges();

            //foreach (Person older in context.Persons.Where(p => p.Age > 35 && !p.FirstName.StartsWith("a")))
            //{
            //    Console.WriteLine(older.FirstName + " " + older.Age);
            //}

            //Console.WriteLine(context.Persons.Average(p => p.Age));

            //context.Log = Console.Out;
            //Person person = new Person();
            //person.FirstName = "Avrumi";
            //person.LastName = "Friedman";
            //person.Age = 9876;
            //context.Persons.InsertOnSubmit(person);
            //context.SubmitChanges();
            //Console.WriteLine($"Person added, new id: {person.Id}");

            //foreach (People p in context.Peoples)
            //{
            //    Console.WriteLine(p.FirstName);
            //}

            Console.ReadKey(true);
        }
    }
}
