using DataAccess.Models;

namespace WEB.ViewModel
{
    public class CommentViewModel
    {
        public int ReviewID { get; set; }
        public int? ProductID { get; set; }
        public int? UserID { get; set; }
        public string? Comment { get; set; }
        public DateTime? ReviewDate { get; set; }
        public User? User { get; set; } 
        public List<ProductReview> Comments { get; set; }
    }
}
