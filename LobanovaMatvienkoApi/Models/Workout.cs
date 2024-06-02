namespace LobanovaMatvienkoApi.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public int GymId { get; set; }
        public int TrainerId { get; set; }
        public int SubscriptionId { get; set; }
    }
}
