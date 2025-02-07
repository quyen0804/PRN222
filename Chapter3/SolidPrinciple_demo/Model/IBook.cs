using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciple_demo.Model
{
    interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        double Price { get; set; }
    }

    //--------------------interface segregation
    interface ITopic
    {
        string Topic { get; set;}
    }

    interface IDuration
    {
        string Duration { get; set; }
    }
}
