using System;

namespace DataMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieMapper mm = new MovieMapper();
            Movie movie = mm.GetById(2);

            movie = mm.GetById(2);
            Console.WriteLine(movie);
            movie = mm.GetById(2);
            Console.WriteLine(movie);
            movie = mm.GetById(2);
            Console.WriteLine(movie);



        }
    }
}
