using System.ComponentModel.DataAnnotations;

namespace MovieReview.Server.Model
{
    public class MovieData
    {
        [Key]
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public float  MovieRating { get; set; }
    }
}
