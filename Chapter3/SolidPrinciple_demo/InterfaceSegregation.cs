using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciple_demo.Model;
using static System.Reflection.Metadata.BlobBuilder;

namespace SolidPrinciple_demo
{
    internal class InterfaceSegregation
    {
        static List<Video> bookList;

        static void PrintBook(List<Video> book)
        {
            Console.WriteLine("\n List of books: ");
            Console.WriteLine("----------------");
            foreach (var items in book)
            {
                Console.WriteLine($"{items.Title.PadRight(39, ' ')} " +
                                  $"{items.Author.PadRight(20, ' ')} " +
                                  $"{items.Price} " +
                                  $"{items.Topic?.PadRight(12, ' ')} " +
                                  $"{items.Duration ?? ""} ");
            }
            Console.WriteLine();
        }

        static void DisplayI()
        {
            string id = string.Empty;
            Console.Title = "Interface Segregation Principle demo";
            do
            {
                Console.WriteLine("File no. to read: 1/2/3/4 - Enter(exit): ") ;
                id= Console.ReadLine();
                if("123".Contains(id) && !String.IsNullOrEmpty(id))
                {
                    bookList = Utilities.Utilities.ReadData02(id);
                    PrintBook(bookList);
                }
            }while(!String.IsNullOrWhiteSpace(id));
        }
    }
}
