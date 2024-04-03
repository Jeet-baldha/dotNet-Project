namespace FillmyHub.Models
{
    public class MovieCard
    {
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string OriginalLanguage { get; set; }
        public string original_title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string MediaType { get; set; }
        public List<int> GenreIds { get; set; }
        public double Popularity { get; set; }
        public string ReleaseDate { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }

    public class ApiResponse
    {
        public int Page { get; set; }
        public List<MovieCard> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
