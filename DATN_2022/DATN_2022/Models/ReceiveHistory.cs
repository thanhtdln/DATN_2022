namespace DATN_2022.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReceiveHistory")]
    public partial class ReceiveHistory
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public DateTime CreatedAt { get; set; }

        public long Amount { get; set; }

        public virtual Product Product { get; set; }
    }
}
