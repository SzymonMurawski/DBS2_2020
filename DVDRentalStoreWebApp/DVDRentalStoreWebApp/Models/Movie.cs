using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVDRentalStoreWebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        public Movie(int id, string title, int year, double price)
        {
            Id = id;
            Title = title;
            Year = year;
            Price = price;
        }
        public Movie()
        {

        }
    }
}
