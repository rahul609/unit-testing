namespace Assignment3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class phones2
    {
        [Required]
        [StringLength(50)]
        public string brand { get; set; }

        public int phoneID { get; set; }

        [Key]
        [Column("customerno.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int customerno_ { get; set; }
    }
}
