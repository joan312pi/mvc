using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabMVC.Models.NorthwindDbContext
{
    [Table("Orders")]
    public partial class Order
    {
        [Key]
        public int OrderID { get; set; }
         
        [Column(TypeName = "nchar(5)")]
        [StringLength(5)]
        [DisplayName("客戶ID")]
        public string? CustomerID { get; set; }

        [DisplayName("員工ID")]
        public int? EmployeeID { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("訂單日期")]
        public DateTime? OrderDate { get; set; }

        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        [DisplayName("所需日期")]
        public DateTime? RequiredDate { get; set; }

        [DisplayName("發貨日期")]
        public DateTime? ShippedDate { get; set; }

        [DisplayName("運送方式")]
        public int? ShipVia { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("運費")]
        [DisplayFormat(DataFormatString = "{0:$#,##0.00}", ApplyFormatInEditMode = true)]
        public decimal? Freight { get; set; }

        [StringLength(40)]
        [DisplayName("運送公司")]
        public string? ShipName { get; set; }

        [StringLength(60)]
        [DisplayName("運送地址")]
        public string? ShipAddress { get; set; }

        [StringLength(15)]
        [DisplayName("運送城市")]
        public string? ShipCity { get; set; }

        [StringLength(15)]
        [DisplayName("運送地區")]
        public string? ShipRegion { get; set; }

        [StringLength(10)]
        [DisplayName("運送郵政編碼")]
        public string? ShipPostalCode { get; set; }

        [StringLength(15)]
        [DisplayName("運送國家")]
        public string? ShipCountry { get; set; }
    }
}
