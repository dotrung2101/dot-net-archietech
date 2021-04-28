using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface.Repository;
using MySqlConnector;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class CustomerGroupRepository : BaseRepository<CustomerGroup>, ICustomerGroupRepository
    {
        public CustomerGroupRepository()
        {
        }
    }
}
