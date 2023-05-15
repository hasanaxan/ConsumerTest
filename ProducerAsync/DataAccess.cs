using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
namespace ConsumerAsync
{
    internal class DataAccess
    {
        private const string connectionString = "Server=.\\SQLEXPRESS;Database=Test;Trusted_Connection=True;Max Pool Size=131072;Pooling=true;";
        public static async Task<int> InsertDataAsync(MessageObject message)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            DbCommand dbCommand = CreateCommandQuery(connection, message);
            var result = await dbCommand.ExecuteNonQueryAsync();
            connection.Close();
            return result;
        }
        private static DbCommand CreateCommandQuery(SqlConnection connection, MessageObject message)
        {
            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = "insert into Messages(CreateDate,QueedDate,ProcessedDate,Cpu,Ram,MessageGroup,MessageOrder,IsAsync,IsParallel) VALUES(@CreateDate,@QueedDate,@ProcessedDate,@Cpu,@Ram,@MessageGroup,@MessageOrder,@IsAsync,@IsParallel)";
            AddParameter(dbCommand, "@CreateDate", message.CreateDate);
            AddParameter(dbCommand, "@QueedDate", message.QueedDate);
            AddParameter(dbCommand, "@ProcessedDate", message.ProcessedDate);
            AddParameter(dbCommand, "@MessageGroup", message.MessageGroup);
            AddParameter(dbCommand, "@MessageOrder", message.MessageOrder);
            AddParameter(dbCommand, "@Cpu", message.Cpu);
            AddParameter(dbCommand, "@Ram", message.Ram);
            AddParameter(dbCommand, "@IsAsync", message.IsAsync);
            AddParameter(dbCommand, "@IsParallel", message.IsParallel);
            return dbCommand;
        }
        private static void AddParameter(DbCommand dbCommand, string parameterName, object? value)
        {
            var parameter = dbCommand.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            dbCommand.Parameters.Add(parameter);
        }
    }
}
