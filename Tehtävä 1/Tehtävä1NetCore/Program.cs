using System;
using Tehtävä1NetCore.Model;
using Tehtävä1NetCore.Repositories;

namespace Tehtävä1NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database CRUD operations");
            //Person person = new Person("Anja",43);
            //PersonRepositories.Create(person);
            var persons = PersonRepositories.Get();
            foreach ( var p in persons)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
