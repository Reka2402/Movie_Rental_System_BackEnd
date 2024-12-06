namespace Movie_Rental_Management.Models.ResponseModel
{
    public class MovieResponseDTO
    {
       
            public int Id { get; set; }
            public string MovieName { get; set; }
            public int DirectorId { get; set; }
            public int GenreId { get; set; }
            public DateTime ReleaseDate { get; set; }
            public int Price { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
      
    }
}
