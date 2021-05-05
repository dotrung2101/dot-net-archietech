using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MISA.CukCuk.Core.Interface.Repository;
using MySqlConnector;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity : class
    {

        protected MySqlConnection dBConnection;
        protected string connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port=3306;" +
                "User Id = dev;" +
                "Password =12345678;" +
                "Database = MF0_NVManh_CukCuk02;" +
                "convert zero datetime=True";

        private readonly string tableName = typeof(MISAEntity).Name;

        public BaseRepository()
        {
        }

        public IEnumerable<MISAEntity> GetAll()
        {
            using (dBConnection = new MySqlConnection(connectionString))
            {
                string sqlCommand = $"Proc_Get{tableName}s";
                var customerGroups = dBConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.StoredProcedure);

                if (customerGroups.Count() >= 0)
                {
                    return customerGroups;
                }
                else
                {
                    return null;
                }
            }
        }

        public MISAEntity GetByID(Guid id)
        {
            using (dBConnection = new MySqlConnection(connectionString))
            {
                string sqlCommand = $"Proc_Get{tableName}ById";

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}Id", id);

                var entity = dBConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);

                if (entity != null)
                {
                    return entity;
                }
                else
                {
                    return null;
                }
            }
        }

        public int Insert(MISAEntity entity)
        {
            using (dBConnection = new MySqlConnection(connectionString))
            {
                string sqlCommand = $"Proc_Insert{tableName}";
                var result = dBConnection.Execute(sqlCommand, param: entity, commandType: CommandType.StoredProcedure);

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Update(MISAEntity entity)
        {
            using (dBConnection = new MySqlConnection(connectionString))
            {
                string sqlCommand = $"Proc_Update{tableName}";
                var result = dBConnection.Execute(sqlCommand, param: entity, commandType: CommandType.StoredProcedure);

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Delete(Guid id)
        {
            using (dBConnection = new MySqlConnection(connectionString))
            {
                string sqlCommand = $"Proc_Delete{tableName}";

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}Id", id);

                var result = dBConnection.Execute(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool CheckPostAttributeDuplicate(string attributeName, string value)
        {
            using (dBConnection = new MySqlConnection(connectionString))
            {
                string sqlCommand = $"IF EXISTS (SELECT * FROM {tableName} c WHERE c.{attributeName} =  '{value}') THEN SELECT TRUE; ELSE SELECT FALSE; END IF; ";
                var attributeExist = dBConnection.QueryFirstOrDefault<bool>(sqlCommand, commandType: CommandType.Text);

                return attributeExist;
            }
        }

        public bool CheckPutAttributeDuplicate(Guid entityId, string attributeName, string value)
        {
            using (dBConnection = new MySqlConnection(connectionString))
            {
                string sqlCommand = $"IF EXISTS (SELECT * FROM {tableName} c WHERE c.{attributeName} =  '{value}' AND !(c.{tableName}Id = '{entityId}')) THEN SELECT TRUE; ELSE SELECT FALSE; END IF; ";
                var attributeExist = dBConnection.QueryFirstOrDefault<bool>(sqlCommand, commandType: CommandType.Text);

                return attributeExist;
            }
        }
    }
}
