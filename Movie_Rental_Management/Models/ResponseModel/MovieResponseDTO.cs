namespace Movie_Rental_Management.Models.ResponseModel
{
    public class MovieResponseDTO
    {
       
            public Guid Id { get; set; }
            public string MovieName { get; set; }
            public string DirectorName { get; set; }
            public string GenreName { get; set; }
            public string ReleaseDate { get; set; }
            public int Price { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
      
    }
}
