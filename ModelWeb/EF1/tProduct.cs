namespace ModelWeb.EF1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tProduct")]
    public partial class tProduct
    {
        public long ID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTittle { get; set; }

        [StringLength(550)]
        public string Description { get; set; }

        [Display(Name = "Ảnh đại diện")]
        [StringLength(250)]
        public string Image { get; set; }

        [Display(Name = "Giá")]
        public decimal? Price { get; set; }

        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [Display(Name = "Hãng sản xuất")]
        public long? CategoryID { get; set; }

        [Display(Name = "Thông tin chi tiết")]
        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [Display(Name = "Thời gian bảo hành")]
        public int? BaoHanh { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }

        [NotMapped]
        public List<CategoryProduct> Category { get; set; }

    }
}
