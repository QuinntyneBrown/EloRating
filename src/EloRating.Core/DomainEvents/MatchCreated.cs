using System;

namespace EloRating.Core.DomainEvents
{
    public class MatchCreated: DomainEvent
    {
        public MatchCreated(Guid matchId, string name)
        {
            MatchId = matchId;
            Name = name;
        }
        public Guid MatchId { get; set; }
        public string Name { get; set; }
    }
}
