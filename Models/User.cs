using System.ComponentModel.DataAnnotations;

namespace FillmyHub.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public List<Movie> arr { get; set; } = new List<Movie>();
    }

    public class  Movie
    {
        [Key]
        public int Id { get; set; }

        public int movieId { get; set; }
    }
}
