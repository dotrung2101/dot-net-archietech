using System;
using System.Collections.Generic;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface.Repository;
using MySqlConnector;
using Dapper;
using System.Data;
using System.Linq;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        public CustomerRepository()
        {

            
        }

        
        public IEnumerable<Customer> GetInRange(int fromIndex, int numberOfRecords, string fullName, Guid? groupId)
        {
            
            using (dBConnection = new MySqlConnection(connectionString))
            {
                string sqlCommand = $"Proc_DVTRUNG_FilterAndGetCustomerInRange";

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add($"@fullName", fullName);
                parameters.Add($"@groupId", groupId);
                parameters.Add($"@fromIndex", fromIndex);
                parameters.Add($"@numberOfRecords", numberOfRecords);

                var customers = dBConnection.Query<Customer>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);

                return customers;
            }
        }
    }
}

/*
*/