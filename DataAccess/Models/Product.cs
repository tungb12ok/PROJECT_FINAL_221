using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Product
    {
        public Product()
        {
            Favorites = new HashSet<Favorite>();
            ProductImages = new HashSet<ProductImage>();
            ProductReviews = new HashSet<ProductReview>();
            Transactions = new HashSet<Transaction>();
        }

        public int ProductId { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DatePosted { get; set; }
        public int StatusId { get; set; }

        public virtual ProductCategory? Category { get; set; }
        public virtual Status Status { get; set; } = null!;
        public virtual User? User { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
