using System;

namespace ActiveRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome do DVD rental store");
            Console.Write("Please provide an ID of a movie: ");
            int movie_id = int.Parse(Console.ReadLine());
            MovieRecord movie = new MovieRecord(movie_id);
            Console.WriteLine(movie.ToString());

            Console.Write("Provice new price for the movie: ");
            double new_price = double.Parse(Console.ReadLine());
            movie.Price = new_price;
            movie.Save();

        }
    }
}
