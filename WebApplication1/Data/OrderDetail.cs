using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    [Table("OrderDetails")]

    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? BookId { get; set; }

        public string? UserId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("BookId")]    public virtual Product? Product { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser? ApplicationUser { get; set; }

    }
}
