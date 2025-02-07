using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciple_demo.Model;

namespace SolidPrinciple_demo
{
    internal class LiskovSubstitution
    {
        static List<Book> bookList;

        static void PrintBook(List<Book> books)
        {
            Console.WriteLine("\n List of books: ");
            Console.WriteLine("----------------");
            foreach (var items in books)
            {
                Console.WriteLine($"{items.Title.PadRight(36, ' ')} " +
                                  $"{items.Author.PadRight(20, ' ')} " +
                                  $"{items.Price}");
            }
            Console.ReadLine();
        }
        static void DisplayL()
        {
            Console.WriteLine("Please press 'yes' to read an extra file, ");
            Console.WriteLine("'topic' to include topic books or any other key for a single file");
            var ans = Console.ReadLine();
            bookList = (ans.ToLower() != "yes") && (ans !="topic") ? Utilities.Utilities.ReadData() :
                Utilities.Utilities.ReadData(ans);
            PrintBook(bookList);
        }
    }
}
