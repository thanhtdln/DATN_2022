namespace DATN_2022.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Carts = new HashSet<Cart>();
            Promotions = new HashSet<Promotion>();
            ReceiveHistories = new HashSet<ReceiveHistory>();
            ShopHistories = new HashSet<ShopHistory>();
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Không th? ?? tr?ng tên s?n ph?m")]
        [StringLength(1000)]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public long CategoryId { get; set; }

        public long ProducerId { get; set; }
        [Required(ErrorMessage = "Không th? ?? tr?ng giá g?c")]
        public double CostPrice { get; set; }
        [Required(ErrorMessage = "Không th? ?? tr?ng giá bán")]
        public double SellPrice { get; set; }
        public long Amount { get; set; }

        [Required(ErrorMessage = "Vui lòng ch?n ?nh ??i di?n c?a s?n ph?m")]
        [StringLength(1000)]
        public string Avatar { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Category Category { get; set; }

        public virtual Producer Producer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Promotion> Promotions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceiveHistory> ReceiveHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopHistory> ShopHistories { get; set; }
    }
}
