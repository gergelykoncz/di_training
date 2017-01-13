namespace DataAccess.Entities
{
    public class Product : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int StockLevel { get; set; }
        public decimal Price { get; set; }
    }
}
