using EloRating.Core.Common;
using EloRating.Core.DomainEvents;
using System;

namespace EloRating.Core.Models
{
    public class Player: AggregateRoot
    {
        public Player(string name)
            => Apply(new PlayerCreated(PlayerId, name));

        public Guid PlayerId { get; set; } = Guid.NewGuid();        
        public string Name { get; set; }        
		public bool IsDeleted { get; set; }

        protected override void EnsureValidState()
        {
            
        }

        protected override void When(DomainEvent @event)
        {
            switch (@event)
            {
                case PlayerCreated playerCreated:
                    Name = playerCreated.Name;
					PlayerId = playerCreated.PlayerId;
                    break;

                case PlayerNameChanged playerNameChanged:
                    Name = playerNameChanged.Name;
                    break;

                case PlayerRemoved playerRemoved:
                    IsDeleted = true;
                    break;
            }
        }

        public void ChangeName(string name)
            => Apply(new PlayerNameChanged(name));

        public void Remove()
            => Apply(new PlayerRemoved());
    }
}
