using System;
using System.Collections.Generic;
using MISA.CukCuk.Core.Entities;

namespace MISA.CukCuk.Core.Interface.Services
{
    /// <summary>
    /// Service phục vụ đối tượng khách hàng
    /// </summary>
    /// Created by: dvtrung
    public interface ICustomerService : IBaseService<Customer>
    {
        

        IEnumerable<Customer> GetOfPage(int pageIndex, int pageSize, string fullName, Guid? groupId);
    }
}
