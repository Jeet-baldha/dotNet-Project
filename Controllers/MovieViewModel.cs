namespace FillmyHub.Controllers
{
    public class MovieViewModel
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; } 
        public double popularity { get; set; }
        public string release_date { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }

        public List<CastMember> cast { get; set; } // List of cast members

        // Constructor to initialize the list
        public MovieViewModel()
        {
            cast = new List<CastMember>();
        }

    }

    public class CastMember
    {
        public int id { get; set; }
        public string name { get; set; }
        public string character { get; set; }
        // Add other properties if needed
    }
}
