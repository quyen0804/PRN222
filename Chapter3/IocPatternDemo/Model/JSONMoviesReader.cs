﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IocPatternDemo.Model
{
    public class JSONMoviesReader:IMovieReader
    {
        static string file = @"Data\MoviesDB.json";
        static List<Movie> movies = new List<Movie>();
        public List<Movie> ReadMovies()
        {
            var moviesText = File.ReadAllText(file);
            return JsonSerializer.Deserialize<List<Movie>>(moviesText);
        }
    }
}
