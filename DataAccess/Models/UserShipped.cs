using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class UserShipped
    {
        public int TransactionId { get; set; }
        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }
        public string City { get; set; } = null!;
        public string? State { get; set; }
        public string Country { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string AddressType { get; set; } = null!;
        public DateTime DateAdded { get; set; }

        public virtual Transaction Transaction { get; set; } = null!;
    }
}
