using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LabMVC.Models.NorthwindDbContext
{
    public class OrderMetaData
    {
        [Required(ErrorMessage = "客戶ID為必填欄位")]
        public string? CustomerID { get; set; }
    }

    [ModelMetadataType(typeof(OrderMetaData))]
    public partial class Order
    {
    }
}
