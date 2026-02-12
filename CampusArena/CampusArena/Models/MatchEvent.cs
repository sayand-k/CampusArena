namespace CampusArena.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public string Description { get; set; } = string.Empty; // e.g., "Goal by Team A"
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // The Scorer who recorded this event
        public string RecordedByUserId { get; set; } = string.Empty;
    }
}