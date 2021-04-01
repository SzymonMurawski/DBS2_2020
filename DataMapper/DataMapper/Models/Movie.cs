using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataMapper
{
    class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public List<Copy> Copies { get; set; }

        public Movie(int id, string title, int year, double price, List<Copy> copies)
        {
            Id = id;
            Title = title;
            Year = year;
            Price = price;
            Copies = copies;
        }
        public override string ToString()
        {
            int availableCopies = Copies.Count(copy => copy.Available);
            return $"Movie {Id}: {Title} produced in {Year} costs {Price}. Copies: {availableCopies}/{Copies.Count()}";
        }

        public void updatePrice()
        {

        }
    }
}
