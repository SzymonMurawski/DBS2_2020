using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace DataMapper
{
    class CopyMapper: IMapper<Copy>
    {
        private string connection_string = "Server=127.0.0.1;User Id=postgres;Password=pwd;Database=rental;";
        public Copy GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Copy> GetByMovieId(int movieId)
        {
            List<Copy> copies = new List<Copy>();
            using (var conn = new NpgsqlConnection(connection_string))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM copies WHERE movie_id = @movieId", conn))
                {
                    cmd.Parameters.AddWithValue("@movieId", movieId);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        copies.Add(new Copy((int)reader["copy_id"], (bool)reader["available"], movieId)); 
                    }
                }
            }
            return copies;
        }

        public void Save(Copy copy)
        {
            throw new NotImplementedException();
        }
        public void Delete(Copy copy)
        {
            throw new NotImplementedException();
        }
    }
}
