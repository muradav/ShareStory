namespace ShareStory.Models
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        #region UserStoryRelation
        public string UserId { get; set; }
        public User User { get; set; }
        #endregion

        #region StoryCommentRelation
        public int StoryId { get; set; }
        public Story Story { get; set; }
        #endregion

    }
}
