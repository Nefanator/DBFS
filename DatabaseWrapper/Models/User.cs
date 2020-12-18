namespace DatabaseWrapper.Models
{
    /// <summary>
    /// Represents a user's profile.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initialise an instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="name">The user's name.</param>
        internal User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// The database ID.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The user's name.
        /// </summary>
        public string Name { get; set; }
    }
}
