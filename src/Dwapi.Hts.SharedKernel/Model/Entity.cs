using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dwapi.Hts.SharedKernel.Custom;

namespace Dwapi.Hts.SharedKernel.Model
{
    public abstract class Entity<TId>
    {
        [Key, Column(Order = 0)]
        public virtual TId Id { get; set; }
        public virtual Guid? RefId { get; set; }

        protected Entity()
        {
           Type idType = typeof(TId);
            if (idType ==typeof(Guid))
            {
                Id = (TId)(object)LiveGuid.NewGuid();
            }
        }
        protected Entity(TId id)
        {
            Id = id;
        }

        public virtual void UpdateRefId()
        {
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity<TId>;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}