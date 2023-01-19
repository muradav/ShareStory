namespace ShareStory.Models
{
    public class Like
    {
        public int Id { get; set; }
        public DateTime LikedDate { get; set; } = DateTime.Now;
        public bool Liked { get; set; }

        #region UserStoryRelation
        public string LikedUserId { get; set; }
        public User LikedUser { get; set; }
        #endregion

        #region StoryLikeRelation
        public int LikedStoryId { get; set; }
        public Story LikedStory { get; set; }
        #endregion

    }
}
