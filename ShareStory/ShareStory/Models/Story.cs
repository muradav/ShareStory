using System.ComponentModel.DataAnnotations.Schema;

namespace ShareStory.Models
{
    public class Story : BaseEntity
    {
        public string? Topic { get; set; }
        public int LikeCount { get; set; }


        #region UserStoryRelation
        public string AuthorId { get; set; }
        public User Author { get; set; }
        #endregion

        #region Relations
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
        #endregion

    }
}
