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

        //public bool CheckPostCustomerCodeExist(string customerCode)
        //{
        //    using(dBConnection = new MySqlConnection(connectionString))
        //    {
        //        string sqlCommand = $"IF EXISTS (SELECT * FROM Customer c WHERE c.CustomerCode =  '{customerCode}') THEN SELECT TRUE; ELSE SELECT FALSE; END IF; ";
        //        var customerCodeExists = dBConnection.QueryFirstOrDefault<bool>(sqlCommand, commandType: CommandType.Text);

        //        return customerCodeExists;
        //    }


        //}

        //public bool CheckPutCustomerCodeExist(string customerCode, Guid id)
        //{
        //    using (dBConnection = new MySqlConnection(connectionString))
        //    {
        //        string sqlCommand = $"IF EXISTS (SELECT * FROM Customer c WHERE c.CustomerCode =  '{customerCode}' AND !(c.CustomerId = '{id}')) THEN SELECT TRUE; ELSE SELECT FALSE; END IF; ";
        //        var customerCodeExists = dBConnection.QueryFirstOrDefault<bool>(sqlCommand, commandType: CommandType.Text);

        //        return customerCodeExists;
        //    }

        //}


        //public bool CheckPostEmailExist(string email)
        //{
        //    using (dBConnection = new MySqlConnection(connectionString))
        //    {
        //        string sqlCommand = $"IF EXISTS (SELECT * FROM Customer c WHERE c.Email =  '{email}') THEN SELECT TRUE; ELSE SELECT FALSE; END IF; ";
        //        var emailExist = dBConnection.QueryFirstOrDefault<bool>(sqlCommand, commandType: CommandType.Text);

        //        return emailExist;
        //    }

        //}

        //public bool CheckPostPhoneNumberExist(string phoneNumber)
        //{
        //    using (dBConnection = new MySqlConnection(connectionString))
        //    {
        //        string sqlCommand = $"IF EXISTS (SELECT * FROM Customer c WHERE c.PhoneNumber =  '{phoneNumber}') THEN SELECT TRUE; ELSE SELECT FALSE; END IF; ";
        //        var phoneNumberExist = dBConnection.QueryFirstOrDefault<bool>(sqlCommand, commandType: CommandType.Text);

        //        return phoneNumberExist;
        //    }

        //}

        //public bool CheckPutEmailExist(string email, Guid id)
        //{
        //    using (dBConnection = new MySqlConnection(connectionString))
        //    {
        //        string sqlCommand = $"IF EXISTS (SELECT * FROM Customer c WHERE c.Email =  '{email}' AND !(c.CustomerId = '{id}')) THEN SELECT TRUE; ELSE SELECT FALSE; END IF; ";
        //        var emailExist = dBConnection.QueryFirstOrDefault<bool>(sqlCommand, commandType: CommandType.Text);

        //        return emailExist;
        //    }

        //}

        //public bool CheckPutPhoneNumberExist(string phoneNumber, Guid id)
        //{
        //    using (dBConnection = new MySqlConnection(connectionString))
        //    {
        //        string sqlCommand = $"IF EXISTS (SELECT * FROM Customer c WHERE c.PhoneNumber =  '{phoneNumber}' AND !(c.CustomerId = '{id}')) THEN SELECT TRUE; ELSE SELECT FALSE; END IF; ";
        //        var phoneNumberExist = dBConnection.QueryFirstOrDefault<bool>(sqlCommand, commandType: CommandType.Text);

        //        return phoneNumberExist;
        //    }

        //}

        public IEnumerable<Customer> GetInRange(int fromIndex, int numberOfRecords, string fullName, Guid? groupId)
        {
            using (dBConnection = new MySqlConnection(connectionString))
            {
                string sqlCommand = $"SELECT * FROM Customer c WHERE " + "c.FullName LIKE CONCAT(\"%\", " + "\"" + fullName + "\"" + $" ,\"%\") AND c.CustomerGroupId = '{groupId}'" + " LIMIT " + fromIndex + " , " + numberOfRecords + " ; ";

                if (groupId == null)
                {
                    sqlCommand = $"SELECT * FROM Customer c WHERE " + "c.FullName LIKE CONCAT(\"%\", " + "\"" + fullName + "\"" + $" ,\"%\")" + " LIMIT " + fromIndex + " , " + numberOfRecords + " ; ";
                }

                var customers = dBConnection.Query<Customer>(sqlCommand, commandType: CommandType.Text);

                return customers;
            }


        }
    }
}
