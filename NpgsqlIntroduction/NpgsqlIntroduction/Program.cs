using System;
using Npgsql;

namespace NpgsqlIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection_string = "Server=127.0.0.1;User Id=postgres;Password=pwd;Database=rental;";
            Console.Write("Display movies produced in year:");
            string year = Console.ReadLine();

            using (NpgsqlConnection conn = new NpgsqlConnection(connection_string))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT title, price, movie_id FROM movies WHERE year = @year", conn))
                {
                    cmd.Parameters.AddWithValue("@year", int.Parse(year));
                    NpgsqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //Console.WriteLine($"Movie {dataReader[2]} has title \"{dataReader[0]}\" and price: {dataReader[1]}");
                        Console.WriteLine($"Movie {dataReader["movie_id"]} has title \"{dataReader["title"]}\" and price: {dataReader["price"]}");
                    }
                }
            }

            int new_id;
            using (NpgsqlConnection conn = new NpgsqlConnection(connection_string))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT MAX(movie_id)+1 FROM movies", conn);
                new_id = (int)cmd.ExecuteScalar();
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(connection_string))
            {
                conn.Open();
                Console.WriteLine("Title of new movie: ");
                string title = Console.ReadLine();
                Console.WriteLine("Year of new movie: ");
                int year2 = int.Parse(Console.ReadLine());

                var cmd2 = new NpgsqlCommand("INSERT INTO movies(movie_id, title, year) VALUES (@id, @title, @year)", conn);
                cmd2.Parameters.AddWithValue("@id", new_id);
                cmd2.Parameters.AddWithValue("@title", title);
                cmd2.Parameters.AddWithValue("@year", year2);

                cmd2.ExecuteNonQuery();
            }
        }
    }
}
