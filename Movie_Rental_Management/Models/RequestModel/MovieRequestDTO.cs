namespace Movie_Rental_Management.Models.RequestModel
{
    public class MovieRequestDTO
    {
       
            public Guid Id { get; set; } 
            public string MovieName { get; set; }
            public Guid GenreId { get; set; }
            public Guid DirectorId { get; set; }
            public string ReleaseDate { get; set; }
            public int Price { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
        

    }
}
