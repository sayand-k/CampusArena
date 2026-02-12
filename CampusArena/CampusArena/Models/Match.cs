using System.ComponentModel.DataAnnotations;

namespace CampusArena.Models
{
    public class Match
    {
        public int Id { get; set; }

        // Links this match to a specific tournament
        public int TournamentId { get; set; }

        public string TeamA { get; set; } = string.Empty;
        public string TeamB { get; set; } = string.Empty;
        public int ScoreA { get; set; }
        public int ScoreB { get; set; }
        public DateTime MatchTime { get; set; }
        public bool IsCompleted { get; set; }

        // REQUIRED: Optimistic Concurrency token
        // This ensures two scorers don't overwrite each other
        [Timestamp]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        // For Bracket Logic
        public int? NextMatchId { get; set; }
    }
}