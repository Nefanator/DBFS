using DatabaseWrapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseWrapper
{
    public abstract class Item : IEquatable<Item>
    {
        public ItemMetadata Metadata { get; internal set; }

        public bool Equals(Item other)
        {
            if (other == null) return false;

            return Metadata.Equals(other.Metadata);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Item);
        }

        public override int GetHashCode()
        {
            return Metadata.GetHashCode();
        }
    }
}
