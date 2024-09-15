using System.ComponentModel.DataAnnotations;

namespace OrderProcessor.Models
{
    public class OrderRow
    {
        [Required]
        [StringLength(9, ErrorMessage = "Article number cannot exceed 9 characters.")]
        public string ArticleNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(5, ErrorMessage = "Size cannot exceed 5 characters.")]
        public string Size { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "PriceIncVat must be a positive decimal.")]
        public decimal PriceIncVat { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "PriceExcVat must be a positive decimal.")]
        public decimal PriceExcVat { get; set; }

        [StringLength(17, ErrorMessage = "Color cannot exceed 17 characters.")]
        public string Color { get; set; } = string.Empty;

        [StringLength(30, ErrorMessage = "Reference cannot exceed 30 characters.")]
        public string? Reference { get; set; } = string.Empty;
    }
}