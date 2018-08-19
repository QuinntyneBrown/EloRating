using EloRating.Core.Common;
using EloRating.Core.DomainEvents;
using System;

namespace EloRating.Core.Models
{
    public class Match: AggregateRoot
    {
        public Match(string name)
            => Apply(new MatchCreated(MatchId,name));

        public Guid MatchId { get; set; } = Guid.NewGuid();
        public Guid Player1Id { get; set; }
        public Guid Player2Id { get; set; }
        public bool IsDraw { get; set; }
        public Guid WinningPlayerId { get; set; }
        public string Name { get; set; }        
		public bool IsDeleted { get; set; }

        protected override void EnsureValidState()
        {
            
        }

        protected override void When(DomainEvent @event)
        {
            switch (@event)
            {
                case MatchCreated matchCreated:
                    Name = matchCreated.Name;
					MatchId = matchCreated.MatchId;
                    break;

                case MatchNameChanged matchNameChanged:
                    Name = matchNameChanged.Name;
                    break;

                case MatchRemoved matchRemoved:
                    IsDeleted = true;
                    break;
            }
        }

        public void ChangeName(string name)
            => Apply(new MatchNameChanged(name));

        public void Remove()
            => Apply(new MatchRemoved());
    }
}
