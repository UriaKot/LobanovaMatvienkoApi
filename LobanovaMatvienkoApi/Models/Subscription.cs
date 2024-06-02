namespace LobanovaMatvienkoApi.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public decimal Price { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string Specialization { get; set; }
        public int ClientId { get; set; }
        public int WorkoutId { get; set; }

    }
}
