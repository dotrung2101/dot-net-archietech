using System;
using System.Collections.Generic;
using MISA.CukCuk.Core.Entities;

namespace MISA.CukCuk.Core.Interface.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        

        /// <summary>
        /// Check CustomerCode exist in the table Customer
        /// </summary>
        /// <param name="customerCode">string</param>
        /// <returns>
        /// true if customerCode exist in the table
        /// and false if not
        /// </returns>
        /// Created by: dvtrung
        bool CheckPostCustomerCodeExist(string customerCode);

        /// <summary>
        /// Check Email exist in the table Customer
        /// </summary>
        /// <param name="email">string</param>
        /// <returns>
        /// true if email exist in the table
        /// and false if not
        /// </returns>
        /// Created by: dvtrung
        bool CheckPostEmailExist(string email);

        /// <summary>
        /// Check PhoneNumber exist in the table Customer
        /// </summary>
        /// <param name="phoneNumber">string</param>
        /// <returns>
        /// true if PhoneNumber exist in the table
        /// and false if not
        /// </returns>
        /// Created by: dvtrung
        bool CheckPostPhoneNumberExist(string phoneNumber);

        /// <summary>
        /// Check CustomerCode exist in other records in the table
        /// </summary>
        /// <param name="customerCode">string</param>
        /// <param name="id">Guid</param>
        /// <returns>
        /// The current record is the record has CustomerId = id
        /// true if there is another record records has CustomerCode like customerCode
        /// and false if there isn't any record has this CustomerCode
        /// </returns>
        /// Created by: dvtrung
        bool CheckPutCustomerCodeExist(string customerCode, Guid id);

        /// <summary>
        /// Check PhoneNumber exist in other records in the table
        /// </summary>
        /// <param name="phoneNumber">string</param>
        /// <param name="id">Guid</param>
        /// <returns>
        /// The current record is the record has CustomerId = id
        /// true if there is another record has PhoneNumber like phoneNumber
        /// and false if there isn't any record has this PhoneNumber
        /// </returns>
        /// Created by: dvtrung
        bool CheckPutPhoneNumberExist(string phoneNumber, Guid id);

        /// <summary>
        /// Check Email exist in other records in the table
        /// </summary>
        /// <param name="email">string</param>
        /// <param name="id">Guid</param>
        /// <returns>
        /// The current record is the record has CustomerId = id
        /// true if there is another record has Email like email
        /// and false if there isn't any record has this Email
        /// </returns>
        /// Created by: dvtrung
        bool CheckPutEmailExist(string email, Guid id);

        /// <summary>
        /// Get Customers in range from 'fromIndex' to 'fromIndex + numberOfRecords'
        /// </summary>
        /// <param name="fromIndex">int</param>
        /// <param name="numberOfRecords">int</param>
        /// <returns>List Customers</returns>
        /// created by: dvtrung
        IEnumerable<Customer> GetInRange(int fromIndex, int numberOfRecords, string fullName, Guid? groupId);
    }
}
