using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Status
    {
        public Status()
        {
            Products = new HashSet<Product>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
