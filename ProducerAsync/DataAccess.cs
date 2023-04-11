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
        public static async Task<int> InsertDataAsync(MessageObject message, double cpu, double ram)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            DbCommand dbCommand = CreateCommandQuery(connection, message, cpu, ram, true);
            var result = await dbCommand.ExecuteNonQueryAsync();
            connection.Close();
            return result;
        }
        private static DbCommand CreateCommandQuery(SqlConnection connection, MessageObject message, double cpu, double ram, bool isAsync)
        {
            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = "insert into Messages(CreateDate,QueedDate,ProcessedDate,Cpu,Ram,IsAsync,MessageGroup) VALUES(@CreateDate,@QueedDate,@ProcessedDate,@Cpu,@Ram,@IsAsync,@MessageGroup)";
            AddParameter(dbCommand, "@CreateDate", message.CreateDate);
            AddParameter(dbCommand, "@QueedDate", message.QueedDate);
            AddParameter(dbCommand, "@ProcessedDate", message.ProcessedDate);
            AddParameter(dbCommand, "@MessageGroup", message.MessageGroup);
            AddParameter(dbCommand, "@Cpu", cpu);
            AddParameter(dbCommand, "@Ram", ram);
            AddParameter(dbCommand, "@IsAsync", isAsync);
           
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
