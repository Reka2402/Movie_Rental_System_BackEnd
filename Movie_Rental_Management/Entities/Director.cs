namespace Movie_Rental_Management.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }


    }
}
