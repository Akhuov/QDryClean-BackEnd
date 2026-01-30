
namespace QDryClean.Domain.Entities
{
    public class Charge : Auditable
    {
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public ItemType? ItemType { get; set; }
    }
}
