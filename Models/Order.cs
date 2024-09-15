namespace OrderProcessor.Models
{
    public class Order
    {
        public string OrderNumber { get; set; } = string.Empty;
        public string OrderDate { get; set; } = string.Empty;
        public string CompanyCode { get; set; } = string.Empty;
        public string PosNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<OrderRow> Rows { get; set; } = [];
    }
}
