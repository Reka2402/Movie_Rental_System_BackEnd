namespace Movie_Rental_Management.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public string DirectorName { get; set; }
        public ICollection<Movie> Movies { get; set; }


    }
}
