using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace ActiveRecord
{
    class MovieRecord
    {
        private string connection_string = "Server=127.0.0.1;User Id=postgres;Password=pwd;Database=rental;";
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public MovieRecord(int id, string title, int year, double price)
        {
            Id = id;
            Title = title;
            Year = year;
            Price = price;
        }
        public MovieRecord(int id)
        {
            using (var conn = new NpgsqlConnection(connection_string))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM movies WHERE movie_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Id = (int)reader["movie_id"];
                        Title = (string)reader["title"];
                        Year = (int)reader["year"];
                        Price = Convert.ToDouble(reader["price"]);
                    }
                }
            }
        }
        public override string ToString()
        {
            return $"Movie {Id}: {Title} produced in {Year} costs {Price}";
        }

        public void Save()
        {
            using(var conn = new NpgsqlConnection(connection_string))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE movies " +
                    "SET title = @title, year = @year, price = @price " +
                    "WHERE movie_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@title", Title);
                    cmd.Parameters.AddWithValue("@year", Year);
                    cmd.Parameters.AddWithValue("@price", Price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Remove()
        {

        }
    }
}
