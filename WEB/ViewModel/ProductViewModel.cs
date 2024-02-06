namespace WEB.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DatePosted { get; set; }
        public int StatusId { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}