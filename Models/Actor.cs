using eFilm.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eFilm.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture URL")]
        [Required]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //Relationships

        //public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
