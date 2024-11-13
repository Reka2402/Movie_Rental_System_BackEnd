﻿namespace Movie_Rental_Management.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public Guid GenreId { get; set; }
        public Guid DirectorId { get; set; }
        public string MovieName { get; set; }
        public string Director { get; set; }
        public string ReleaseDate { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Genre Genre { get; set; }
        public Director director { get; set; }
        public ICollection<Review> Reviews { get; set; }
     
    }
}
