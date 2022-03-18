namespace Dukkantek.ViewModel.Products
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public long? CategoryId { get; set; }
        public string Category { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}
