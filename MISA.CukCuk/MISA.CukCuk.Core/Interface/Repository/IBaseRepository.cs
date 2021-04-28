using System;
using System.Collections.Generic;

namespace MISA.CukCuk.Core.Interface.Repository
{
    public interface IBaseRepository<MISAEntity> where MISAEntity : class
    {
        /// <summary>
        /// Get all customers in table Customer in database
        /// </summary>
        /// <returns>List customer</returns>
        /// Created by: dvtrung
        IEnumerable<MISAEntity> GetAll();

        /// <summary>
        /// Get customer has CustomerID like param 'id'
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns>
        ///     Customer if CustomerID in the table
        ///     and null if there is not CustomerID in the table
        /// </returns>
        /// Created by: dvtrung
        MISAEntity GetByID(Guid id);

        /// <summary>
        /// Insert a record to the table Customer
        /// </summary>
        /// <param name="entity">Customer</param>
        /// <returns>Number of customer was inserted</returns>
        /// Created by: dvtrung
        int Insert(MISAEntity entity);

        /// <summary>
        /// Update a record in the table Customer
        /// </summary>
        /// <param name="entity">Customer</param>
        /// <returns>Number of customer was updated</returns>
        /// Created by: dvtrung
        int Update(MISAEntity entity);

        /// <summary>
        /// Delete a record in the table Customer which has CustomerId
        /// like param 'id'
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns>Number of customer was deleted</returns>
        /// Created by: dvtrung
        int Delete(Guid id);
    }
}
