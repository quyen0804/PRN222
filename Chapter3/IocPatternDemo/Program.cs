﻿using System;
using System.Linq;
using IocPatternDemo.Model;
namespace IocPatternDemo
{
    public class ReaderFactory
    {
        public IMovieReader _IMovieReader { get; }
        public ReaderFactory(string fileType)
        {
            switch (fileType)
            {
                case "XML":
                    _IMovieReader = new XMLMovieReader();
                    break;
                case "JSON":
                    _IMovieReader = new JSONMoviesReader();
                    break;
                default: break;
            }
        }

        class Program
        {
            static IMovieReader _IMovieReader;
            static void Main(string[] args)
            {
                Console.Title = "IoC Pattern";
                Console.WriteLine("Please select file type to read: ");
                Console.WriteLine("(1) XML, (2) JSON: ");
                var ans = Console.ReadLine();
                var fileType = (ans == "1") ? "XML" : "Json";
                _IMovieReader = new ReaderFactory(fileType)._IMovieReader;
                var typeSelected = _IMovieReader.GetType().Name;
                var movieCollection = _IMovieReader.ReadMovies();
                Console.WriteLine($"Movie Title: ({typeSelected})");
                Console.WriteLine("----------------");
                foreach (var movie in movieCollection)
                {
                    Console.WriteLine($"{movie.ID}, {movie.Title}, " +
                        $"{movie.OscarNomination}, {movie.OscarWin}");
                }
                Console.ReadLine();
            }
        }
    }
}
