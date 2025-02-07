using System.Collections.Generic;

namespace IocPatternDemo.Model
{
    public interface IMovieReader
    {
        List<Movie> ReadMovies();
    }
}
