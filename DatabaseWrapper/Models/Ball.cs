using System;

namespace DatabaseWrapper.Models
{
    public class Ball : Item, IEquatable<Ball>
    {
        public string Colour { get; }

        public int Size { get; }

        private Ball(string colour, int size)
        {
            Colour = colour;
            Size = size;
        }

        internal Ball(int id, string path, User owner, string colour, int size)
        {
            Colour = colour;
            Size = size;
            Metadata = new ItemMetadata(id, path, ItemType.Ball, owner);
        }

        public bool Equals(Ball other)
        {
            if (other == null) return false;

            return base.Equals(other)
                && Colour == other.Colour
                && Size == other.Size;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Ball);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Colour.GetHashCode() ^ Size.GetHashCode();
        }
    }
}
