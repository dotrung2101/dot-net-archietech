using System;
using System.Collections.Generic;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface.Repository;
using MISA.CukCuk.Core.Interface.Services;

namespace MISA.CukCuk.Core.Service
{
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {

        ICustomerGroupRepository _customerGroupRepository; 

        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository):base(customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }

        

    }
}
