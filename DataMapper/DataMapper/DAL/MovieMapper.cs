using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace DataMapper
{
    class MovieMapper: IMapper<Movie>
    {
        private string connection_string = "Server=127.0.0.1;User Id=postgres;Password=pwd;Database=rental;";
        private Dictionary<int, Movie> _cache = new Dictionary<int, Movie>();

        public static MovieMapper Instance { get; } = new MovieMapper();

        private MovieMapper()
        {

        }

        public Movie GetById(int id)
        {
            if (_cache.ContainsKey(id))
            {
                return _cache[id];
            }
            Movie movie = GetByIdFromDb(id);
            _cache[movie.Id] = movie;
            return movie;
        }

        public Movie GetByIdFromDb(int id)
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

                        var copyMapper = new CopyMapper();
                        var copies = copyMapper.GetByMovieId(id);
                        return new Movie(id, title, year, price, copies);
                    } else
                    {
                        return null;
                    }
                }
            }
        }

        public void Save(Movie movie)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connection_string))
            {
                conn.Open();
                // This is an UPSERT operation - if record doesn't exist in the database it is created, otherwise it is updated
                using (var command = new NpgsqlCommand("INSERT INTO movies(movie_id, title, year, price) " +
                    "VALUES (@ID, @title, @year, @price) " +
                    "ON CONFLICT (movie_id) DO UPDATE " +
                    "SET title = @title, year = @year, price = @price", conn))
                {
                    command.Parameters.AddWithValue("@ID", movie.Id);
                    command.Parameters.AddWithValue("@title", movie.Title);
                    command.Parameters.AddWithValue("@year", movie.Year);
                    command.Parameters.AddWithValue("@price", movie.Price);
                    command.ExecuteNonQuery();
                }
                // We need to save every copy in our list. 
                // Notice the "?" symbol - Copies might be an empty list, so we need protection from NullReferenceException
                //movie.Copies?.ForEach(obj => CopyMapper.Instance.Save(obj));
            }
            _cache[movie.Id] = movie;
        }
        public void Delete(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
