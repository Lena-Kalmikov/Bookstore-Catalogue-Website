using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;

namespace WebProjectLena.Models.QueryHelpers
{
    public static class Helper
    {
        // This class allows to run an SQL query (as a string) in SQL format and returns the results of that query in a list.
        public static List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map, DbContext context)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = query;
            command.CommandType = CommandType.Text;

            context.Database.OpenConnection();

            using var result = command.ExecuteReader();
            var entities = new List<T>();

            while (result.Read())
            {
                entities.Add(map(result));
            }

            return entities;
        }
    }
}