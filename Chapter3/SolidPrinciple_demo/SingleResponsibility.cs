using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SolidPrinciple_demo.Model;

namespace SolidPrinciple_demo
{
     class SingleResponsibility
    {

        static void DisplayS()
        {
            Console.WriteLine(" List of Books");
            Console.WriteLine("-------------------");
            var cadJSON = File.ReadAllText("Data/BookStore.json");
            var bookList = JsonConvert.DeserializeObject<Book[]>(cadJSON);
            foreach (var item in bookList)
            {
                Console.WriteLine($" {item.Title.PadRight(39, ' ')} " +
                    $"{item.Author.PadRight(15, ' ')} {item.Price}");
            }
            Console.Read();
        }
    }
}
