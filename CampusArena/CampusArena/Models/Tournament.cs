using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusArena.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SportType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }

        // RBAC tracking
        public string CreatedByUserId { get; set; } = string.Empty;

        // Concurrency token (Crucial for live updates)
        [Timestamp]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public List<Match> Matches { get; set; } = new List<Match>();
    }
}