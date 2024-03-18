using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Status
    {
        public Status()
        {
            ProductCategories = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
            Transactions = new HashSet<Transaction>();
            UserShippeds = new HashSet<UserShipped>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<UserShipped> UserShippeds { get; set; }
    }
}
