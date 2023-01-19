using ShareStory.Helpers;
using ShareStory.Models;

namespace ShareStory.ViewModels
{
    public class HomeVM
    {
        public Story Story { get; set; }
        public List<Story> Stories { get; set; }
        public Comment Comment { get; set; }
        public PagedList<Story> PagedLists { get; set; }
    }
}
