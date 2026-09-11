using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabMVC.Models.ViewModel
{
    public class OrdersViewModel
    {
        [DisplayName("客戶ID")]
        public int OrderID { get; set; }
        [DisplayName("客戶ID")]
        public string CustomerID { get; set; }
        [DisplayName("員工姓名")]
        public string EmployeeName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("訂單日期")]
        public DateTime? OrderDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("所需日期")]
        public DateTime? RequiredDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("發貨日期")]
        public DateTime? ShippedDate { get; set; }
        [DisplayName("運費")]
        [DisplayFormat(DataFormatString = "{0:$#,##0.00}", ApplyFormatInEditMode = true)]
        public decimal? Freight { get; set; }
    }
}
