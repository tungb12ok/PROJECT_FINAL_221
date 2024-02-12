using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class FinancialTransaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public string TransactionType { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; } = null!;
        public string? Description { get; set; }

        public virtual User User { get; set; } = null!;

        public override string ToString()
        {
            return $"TransactionId: {TransactionId}, UserId: {UserId}, TransactionType: {TransactionType}, Amount: {Amount}, TransactionDate: {TransactionDate}, Status: {Status}, Description: {Description ?? "N/A"}";
        }

    }
}
