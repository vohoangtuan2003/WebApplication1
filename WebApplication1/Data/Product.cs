using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    [Table("Product")]

    public partial class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string BookPrice { get; set; } = null!;

        public string BookImage { get; set; } = null!;

        public int? PublishedYear { get; set; }

        public int? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author? AuthorNavigation { get; set; }

        public virtual ICollection<OrderDetail> OwnerDetails { get; set; } = new List<OrderDetail>();
    }
}
