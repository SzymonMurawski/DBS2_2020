using System;

namespace DataMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieMapper mm = MovieMapper.Instance;
            Movie movie = mm.GetById(2);
            movie.Title = "soimething else";

            MovieMapper mm2 = MovieMapper.Instance;
            Movie movie2 = mm.GetById(2);

            mm.Save(movie);

            mm2.Save(movie2);

            
            Console.WriteLine(movie);



        }
    }
}
