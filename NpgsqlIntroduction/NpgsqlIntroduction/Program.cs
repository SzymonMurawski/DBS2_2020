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

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT title FROM movies", conn);

            NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine($"title: {dataReader[0]}");
            }

            conn.Close();
        }
    }
}
