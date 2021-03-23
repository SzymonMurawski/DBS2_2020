using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace DataMapper
{
    class MovieMapper
    {
        private string connection_string = "Server=127.0.0.1;User Id=postgres;Password=pwd;Database=rental;";

        public Movie GetById(int id)
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
                        string title = (string)reader["title"];
                        int year = (int)reader["year"];
                        double price = Convert.ToDouble(reader["price"]);
                        return new Movie(id, title, year, price);
                    } else
                    {
                        return null;
                    }
                }
            }
        }

        public void Save(Movie movie)
        {
            throw new NotImplementedException();
        }
        public void Delete(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
