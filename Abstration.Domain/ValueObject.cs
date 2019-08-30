using System;
using System.Collections.Generic;
using System.Linq;

namespace eGP.Abstration.Domain
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
       

        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var obj in GetAttributesToIncludeInEqualityCheck())
                hash = hash * 31 + (obj == null ? 0 : obj.GetHashCode());
            return hash;
        }
        protected IEnumerable<object> GetAttributesToIncludeInEqualityCheck(T value)
        {
            var properties = value.GetType().GetProperties();
            var lst = new List<object>();
            foreach (var property in properties)
            {
                lst.Add(property.Name);
            }
            return lst;
        }
        protected abstract IEnumerable<object> GetAttributesToIncludeInEqualityCheck();
        public bool Equals(T other)
        {
            if (other == null) return false;
            return GetAttributesToIncludeInEqualityCheck()
                .SequenceEqual(other.GetAttributesToIncludeInEqualityCheck());
        }
        public override bool Equals(object other)
        {
            return Equals(other as T);
        }

       

       
        public static bool operator ==(ValueObject<T> left, ValueObject<T> right) => Equals(left, right);

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right) => !(left == right);


        public ValueObject<T> GetCopy()
        {
            return this.MemberwiseClone() as ValueObject<T>;
        }
    }

    public class SimpleLookup : ValueObject<SimpleLookup>
    {
        public int Id { get; private set; }
        public string Description { get; private set; }

        public SimpleLookup()
        {
            Id = 0;
            Description = String.Empty;
        }
        public SimpleLookup(int id, string description)
        {
            Id = id;
            Description = description;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>() { Id, Description };
        }
    }

}