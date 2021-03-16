using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace ActiveRecord
{
    class MovieRecord
    {
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

        public static MovieRecord GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {

        }

        public void Remove()
        {

        }
    }
}
