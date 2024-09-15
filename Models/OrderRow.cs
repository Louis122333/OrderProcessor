namespace OrderProcessor.Models
{
    public class OrderRow
    {
        public string ArticleNumber { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal PriceIncVat { get; set; }
        public decimal PriceExcVat { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
    }
}
