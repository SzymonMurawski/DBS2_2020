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

            Console.Write("Provide new price for the movie: ");
            double new_price = double.Parse(Console.ReadLine());
            movie.Price = new_price;
            movie.Save();

            Console.WriteLine("Provide values for new movie: ");
            string title = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            movie = new MovieRecord(title, year, price);
            Console.WriteLine(movie.ToString());
            movie.Save();
        }
    }
}
