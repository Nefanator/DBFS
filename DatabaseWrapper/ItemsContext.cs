using Dapper;
using DatabaseWrapper.Models;
using System.Collections.Generic;
using System.Data;

namespace DatabaseWrapper
{
    public class ItemsContext
    {
        private readonly IDbConnection _connection;

        public ItemsContext(IDbConnection connection)
        {
            _connection = connection;
        }

        public Ball CreateBall(User owner, string path, string colour, int size)
        {
            var ballParams = new
            {
                OwnerId = owner.Id,
                Path = path,
                Type = ItemType.Ball,
                Colour = colour,
                Size = size
            };

            var id =
                _connection.QuerySingle<int>(
                    "CreateBall",
                    ballParams,
                    commandType: CommandType.StoredProcedure);

            return new Ball(id, path, owner, colour, size);
        }

        public IEnumerable<ItemMetadata> ReadMetadata(User owner)
        {
            var items = _connection.Query<ItemMetadata>(
                "ReadUsersItems",
                new { OwnerId = owner.Id },
                commandType: CommandType.StoredProcedure);

            foreach (var item in items)
            {
                item.Owner = owner;
            }

            return items;
        }

        public IEnumerable<ItemMetadata> ReadMetadata(User owner, string path)
        {
            var items = _connection.Query<ItemMetadata>(
                "ReadItemsWithPath",
                new { OwnerId = owner.Id, Path = path },
                commandType: CommandType.StoredProcedure);

            foreach (var item in items)
            {
                item.Owner = owner;
            }

            return items;
        }

        public T Read<T>(ItemMetadata metadata) where T : Item
        {
            var storedProcedure = $"Read{typeof(T).Name}WithId";

            var item = _connection.QuerySingle<T>(
                storedProcedure,
                new { metadata.Id },
                commandType: CommandType.StoredProcedure);

            item.Metadata = metadata;
            return item;
        }

        //public Item Read(ItemMetadata metadata)
        //{

        //}

        public void Update(ItemMetadata item)
        {
            _connection.Execute(
                "UpdateItem",
                new { item.Id, item.Path, OwnerId = item.Owner.Id },
                commandType: CommandType.StoredProcedure);
        }

        public void Delete(ItemMetadata item)
        {
            _connection.Execute(
                "DeleteItem",
                new { item.Id },
                commandType: CommandType.StoredProcedure);
        }
    }
}
