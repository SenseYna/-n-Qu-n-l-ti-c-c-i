namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThucUong")]
    public partial class ThucUong
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string MaTU { get; set; }

        [StringLength(50)]
        public string TenTU { get; set; }

        [StringLength(50)]
        public string MoTaTU { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        public int? DonGiaTU { get; set; }
    }
}
