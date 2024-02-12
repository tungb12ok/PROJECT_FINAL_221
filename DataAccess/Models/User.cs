using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Favorites = new HashSet<Favorite>();
            FinancialTransactions = new HashSet<FinancialTransaction>();
            MessageFromUsers = new HashSet<Message>();
            MessageToUsers = new HashSet<Message>();
            ProductReviews = new HashSet<ProductReview>();
            Products = new HashSet<Product>();
            TransactionBuyers = new HashSet<Transaction>();
            TransactionSellers = new HashSet<Transaction>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public DateTime? LastLogin { get; set; }
        public int RoldeId { get; set; }

        public virtual Role Rolde { get; set; } = null!;
        public virtual Wallet? Wallet { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<FinancialTransaction> FinancialTransactions { get; set; }
        public virtual ICollection<Message> MessageFromUsers { get; set; }
        public virtual ICollection<Message> MessageToUsers { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Transaction> TransactionBuyers { get; set; }
        public virtual ICollection<Transaction> TransactionSellers { get; set; }
    }
}
