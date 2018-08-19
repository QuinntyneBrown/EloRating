using System;

namespace EloRating.Core.DomainEvents
{
    public class PlayerNameChanged: DomainEvent
    {
        public PlayerNameChanged(string name)
        {
             Name = name;
        }

        public string Name { get; set; }
    }
}
