using System;
using Npgsql;

namespace NpgsqlIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=pwd;Database=rental;");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT title, price, movie_id  FROM movies", conn);
            NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                //Console.WriteLine($"Movie {dataReader[2]} has title \"{dataReader[0]}\" and price: {dataReader[1]}");
                Console.WriteLine($"Movie {dataReader["movie_id"]} has title \"{dataReader["title"]}\" and price: {dataReader["price"]}");
            }

            conn.Close();
        }
    }
}
