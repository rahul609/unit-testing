namespace Assignment3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class phones1
    {
        [Required]
        [StringLength(50)]
        public string phones { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int phoneID { get; set; }

        [Required]
        [StringLength(50)]
        public string color { get; set; }
        public string Name { get; set; }
    }
}
