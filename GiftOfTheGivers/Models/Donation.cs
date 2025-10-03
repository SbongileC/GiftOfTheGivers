namespace GiftOfTheGivers.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public string DonorName { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Purpose { get; set; }
        public string ? ResourceType { get; set; }
        public string ? Description { get; set; }
        public int Quantity { get; set; }
        public string? PickupLocation { get; set; }
        public bool IsResourceDonation { get; set; }
    }
}
