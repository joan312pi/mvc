using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabMVC.Models.NorthwindDbContext
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage ="姓名不可留空")]
        [StringLength(20)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "姓名不可留空")]
        [StringLength(10)]
        public string FirstName { get; set; } = null!;

        [StringLength(30)]
        public string? Title { get; set; }

        [StringLength(25)]
        public string? TitleOfCourtesy { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        [StringLength(60)]
        public string? Address { get; set; }

        [StringLength(15)]
        public string? City { get; set; }

        [StringLength(15)]
        public string? Region { get; set; }

        [StringLength(10)]
        public string? PostalCode { get; set; }

        [StringLength(15)]
        public string? Country { get; set; }

        [StringLength(24)]
        public string? HomePhone { get; set; }

        [StringLength(4)]
        public string? Extension { get; set; }

        public byte[]? Photo { get; set; }

        public string? Notes { get; set; }

        public int? ReportsTo { get; set; }

        [StringLength(255)]
        public string? PhotoPath { get; set; }
    }
}
