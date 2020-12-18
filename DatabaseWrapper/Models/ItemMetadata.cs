using System;

namespace DatabaseWrapper.Models
{
    /// <summary>
    /// Represents an item owned by a <see cref="User"/>.
    /// </summary>
    public class ItemMetadata : IEquatable<ItemMetadata>
    {
        /// <summary>
        /// Initialise a new instance of the <see cref="ItemMetadata"/> class.
        /// Only to be used by Dapper using reflection.
        /// </summary>
        /// <param name="id">Database ID.</param>
        /// <param name="path">Item's path.</param>
        private ItemMetadata(int id, string path, ItemType type)
        {
            Id = id;
            Path = path;
            Type = type;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="ItemMetadata"/> class.
        /// </summary>
        /// <param name="id">Database ID.</param>
        /// <param name="path">Item's path.</param>
        /// <param name="owner">Item's owner.</param>
        internal ItemMetadata(int id, string path, ItemType type, User owner)
        {
            Id = id;
            Path = path;
            Type = type;
            Owner = owner;
        }

        /// <summary>
        /// The database ID.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The path to the item.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The Type of Item.
        /// </summary>
        public ItemType Type { get; }

        /// <summary>
        /// The Item's owner.
        /// </summary>
        public User Owner { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return Equals(obj as ItemMetadata);
        }

        /// <inheritdoc/>
        public bool Equals(ItemMetadata other)
        {
            if (other == null) return false;

            return Id == other.Id
                && Path == other.Path
                && Type == other.Type
                && Owner == other.Owner;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Id.GetHashCode()
                ^ Path.GetHashCode()
                ^ Type.GetHashCode()
                ^ Owner.GetHashCode();
        }
    }
}
