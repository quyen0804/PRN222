using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciple_demo.Model;

namespace SolidPrinciple_demo
{
    class OpenClosed
    {
        static List<Book> bookList;

        static void PrintBook(List<Book> books)
        {
            Console.WriteLine("\n List of books: ");
            Console.WriteLine("----------------");
            foreach (var items in books)
            {
                Console.WriteLine($"{items.Title.PadRight(39, ' ')} " +
                                  $"{items.Author.PadRight(20, ' ')} " +
                                  $"{items.Price}");
            }
            Console.ReadLine();
        }

        static void DisplayO()
        {
            Console.WriteLine("Please press 'yes' to read an extra file, ");
            Console.WriteLine("or any other key for a single file");
            var ans = Console.ReadLine();
            bookList = (ans.ToLower() != "yes") ? Utilities.Utilities.ReadData() :
                Utilities.Utilities.ReadDataExtra();
            PrintBook(bookList);
        }
    }
}
