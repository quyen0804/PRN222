using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciple_demo.Model
{
     public class Book : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }

    //------------------

    public class TopicBoook : Book
    {
        public string Topic { get; set; }
    }

    //----------------- interface segregation
    public class TopicBook02 : IBook, ITopic
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Topic { get; set; }
    }

    public class Video : IBook, ITopic, IDuration
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Topic { get; set; }
        public string Duration { get; set; }
    }


}
