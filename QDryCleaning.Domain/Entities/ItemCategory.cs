namespace QDryClean.Domain.Entities
{
    public class ItemCategory : Auditable
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<ItemType> Invoices { get; set; } = new List<ItemType>();
    }
}