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
                string sqlCommand = $"SELECT * FROM Customer c WHERE c.FullName LIKE CONCAT(\"%\", '{fullName}', \"%\") AND c.CustomerGroupId = '{groupId}' LIMIT {fromIndex} , {numberOfRecords}";

                if (groupId == null)
                {
                    sqlCommand = $"SELECT * FROM Customer c WHERE c.FullName LIKE CONCAT(\"%\", '{fullName}', \"%\") LIMIT {fromIndex} , {numberOfRecords}";
                }

                var customers = dBConnection.Query<Customer>(sqlCommand, commandType: CommandType.Text);

                return customers;
            }
        }
    }
}
