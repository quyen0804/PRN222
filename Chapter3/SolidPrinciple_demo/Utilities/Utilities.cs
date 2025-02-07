using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SolidPrinciple_demo.Model;

namespace SolidPrinciple_demo.Utilities
{
     class Utilities
    {
        static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }

        internal static List<Book> ReadData()
        {
            var cadJSON = ReadFile("Data/BookStore.json");
            return JsonConvert.DeserializeObject<List<Book>>(cadJSON);
        }

        internal static List<Book> ReadData(string extra)
        {
            List<Book> data = ReadData();
            var filename = "Data/BookStore02.json";
            var cadJSON = ReadFile(filename);
            data.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON));
            if(extra == "topic")
            {
                filename = "Data/BookStore03.json";
                cadJSON = ReadFile(filename);
                data.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON));
            }
            return data;

        }

        internal static List<Book> ReadDataExtra()
        {
            List<Book> data = ReadData();
            var cadJSON = ReadFile("Data/BookStore02.json");
            data.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON));
            return data;
        }

        //------- I
        internal static List<Video> ReadData02(string fileId)
        {
            var filename = "Data/BookStore"+fileId+".json";
            var cadJSON = ReadFile(filename);
            return JsonConvert.DeserializeObject<List<Video>>(cadJSON);
        }
    }
}
