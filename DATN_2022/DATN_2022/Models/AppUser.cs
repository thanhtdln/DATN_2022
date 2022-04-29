namespace DATN_2022.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AppUser")]
    public partial class AppUser
    {
        public long Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(1000)]
        public string Address { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(1000)]
        public string Email { get; set; }

        public long AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
