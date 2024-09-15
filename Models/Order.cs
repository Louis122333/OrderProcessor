using System.ComponentModel.DataAnnotations;

namespace OrderProcessor.Models
{
    public class Order
    {
        [Required]
        [StringLength(9, ErrorMessage = "Order number cannot exceed 9 characters.")]
        public string OrderNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(7, ErrorMessage = "Company code cannot exceed 7 characters.")]
        public string CompanyCode { get; set; } = string.Empty;

        [Required]
        [StringLength(13, ErrorMessage = "Order date cannot exceed 13 characters.")]
        public string OrderDate { get; set; } = string.Empty;

        [StringLength(5, ErrorMessage = "Pos number cannot exceed 5 characters.")]
        public string? PosNumber { get; set; } = string.Empty;

        [StringLength(25, ErrorMessage = "Address cannot exceed 25 characters.")]
        public string Address { get; set; } = string.Empty;

        [StringLength(15, ErrorMessage = "Phone cannot exceed 15 characters.")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public List<OrderRow> Rows { get; set; } = new();
    }
}