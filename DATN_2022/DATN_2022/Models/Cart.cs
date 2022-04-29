namespace DATN_2022.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public long Id { get; set; }

        public long EndUserId { get; set; }

        public long ProductId { get; set; }

        public long Amount { get; set; }

        public virtual EndUser EndUser { get; set; }

        public virtual Product Product { get; set; }
    }
}
