using MediatR;
using System;
using System.Collections.Generic;

namespace eGP.Abstration.Domain
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {

        protected Entity(TId id)
        {
            if (Equals(id, default(TId)))
            {
                throw new ArgumentException(
                    "The ID cannot be the default value.", "id"
                );
            }

            Id = id;
        }
        public TId Id { get; }

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public bool IsTransient()
        {
            return Equals(this.Id, default(TId));
        }

        public bool Equals(Entity<TId> other)
        {
            if (other == null) return false;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Entity<TId>)obj);
        }
        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return left?.Equals(right) ?? object.Equals(right, null);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !(left == right);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}