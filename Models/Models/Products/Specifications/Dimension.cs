namespace Models.Models.Products.Specifications
{
    public class Dimension
    {
        public DimensionItem Height { get; set; }

        public DimensionItem Weight { get; set; }
    }

    public class DimensionItem
    {
        public int Foot { get; set; }

        public int Inch { get; set; }
    }
}