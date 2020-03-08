using System.ComponentModel.DataAnnotations;

namespace Cenema.Models.Domain
{
    public class Movie : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public Genres[] Genres { get; set; }
        public int MinAge { get; set; }
        public string Director { get; set; }
        public string ImgUrl { get; set; }
        public double Rating { get; set; }
        public int? ReleaseDate { get; set; }

    }
}