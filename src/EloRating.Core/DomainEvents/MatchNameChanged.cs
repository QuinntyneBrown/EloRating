using System;

namespace EloRating.Core.DomainEvents
{
    public class MatchNameChanged: DomainEvent
    {
        public MatchNameChanged(string name)
        {
             Name = name;
        }

        public string Name { get; set; }
    }
}
