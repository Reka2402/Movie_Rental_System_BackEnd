namespace Movie_Rental_Management.Models.RequestModel
{
    public class MovieRequestDTO
    {
       
         
            public string MovieName { get; set; }
            public int  GenreId { get; set; }
            public string? GenreName { get; set; }
            public int DirectorId { get; set; }
            public string? DirectorName { get; set; }
            public DateTime ReleaseDate { get; set; }
            public int Price { get; set; }
            public string Description { get; set; }
            public string? ImageUrl { get; set; }
            public int Totalcopies { get; set; }


    }
}
