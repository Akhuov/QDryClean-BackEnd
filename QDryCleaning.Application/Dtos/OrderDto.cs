
using QDryClean.Domain.Enums;

namespace QDryClean.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int customerId { get; set; }
        public int ReceiptNumber { get; set; }
        public required ProcessStatus ProcessStatus { get; set; }
        public required DateOnly ExpectedCompletionDate { get; set; }
        public IList<string> Notes { get; set; } = new List<string>();

        //public ICollection<Item> Items { get; set; } = new List<Item>();
        //public Customer Customer { get; set; }
        //public Invoice Invoice { get; set; }
    }
}
