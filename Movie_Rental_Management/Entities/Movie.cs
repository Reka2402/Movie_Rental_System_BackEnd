namespace Movie_Rental_Management.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public int  GenreId { get; set; }
        public int  DirectorId { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ? ImageUrl { get; set; }
        public Genre? Genre { get; set; }
        public Director? director { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public int TotalCopies { get; set; }

        public ICollection<Rent>
            Rent { get; set; }
        public ICollection<Favouirtes> Favourites { get; set; }


    }
}
