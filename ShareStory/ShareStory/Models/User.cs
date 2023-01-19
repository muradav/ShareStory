using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareStory.Models
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ImageUrl { get; set; }
        [NotMappedAttribute]
        public IFormFile? Image { get; set; }

        #region Relations
        public List<Story> Stories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
        #endregion

    }

    public enum Roles
    {
        Admin,
        Guest
    }
}
