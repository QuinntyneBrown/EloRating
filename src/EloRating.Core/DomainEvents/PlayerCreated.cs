using System;

namespace EloRating.Core.DomainEvents
{
    public class PlayerCreated: DomainEvent
    {
        public PlayerCreated(Guid playerId, string name)
        {
            PlayerId = playerId;
             Name = name;
        }
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
    }
}
