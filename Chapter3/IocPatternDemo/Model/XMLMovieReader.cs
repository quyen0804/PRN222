using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPatternDemo.Model
{
    public class XMLMovieReader : IMovieReader
    {
        static string url = @"Data\";
        static XDocument films = XDocument.Load(url + "MoviesDB.xml");
        public List<Movie> ReadMovies()
        {
            var movieCollection = (from f in films.Descendants("Movie")
                                   select new Movie
                                   {
                                       ID = f.Element("ID").Value,
                                       Title = f.Element("Title").Value,
                                       OscarNomination = f.Element("OscarNomination").Value,
                                       OscarWin = f.Element("OscarWin").Value

                                   }).ToList();
            return movieCollection;
        }
    } 
}

