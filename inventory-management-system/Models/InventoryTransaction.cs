using System;
using System.ComponentModel.DataAnnotations;

namespace inventory_management_system.Models
{
    public class InventoryTransaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public string TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
