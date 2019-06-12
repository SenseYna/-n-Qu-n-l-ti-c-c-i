namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonAn")]
    public partial class MonAn
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string MaMA { get; set; }

        [StringLength(50)]
        public string TenMA { get; set; }

        public string MoTaMA { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        public int? DonGiaMA { get; set; }

        [StringLength(50)]
        public string LoaiMA { get; set; }
    }
}
