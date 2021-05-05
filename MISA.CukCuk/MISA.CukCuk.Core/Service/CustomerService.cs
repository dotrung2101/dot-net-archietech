using System;
using System.Collections.Generic;
using MISA.CukCuk.Core.AttributesCustom;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Exceptions;
using MISA.CukCuk.Core.Interface.Repository;
using MISA.CukCuk.Core.Interface.Services;

namespace MISA.CukCuk.Core.Service
{
    public class CustomerService :BaseService<Customer>, ICustomerService
    {

        ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        private bool IsEmailRightForm(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsPhoneNumberRightForm(string phoneNumber)
        {
            return int.TryParse(phoneNumber, out _);
        }


        protected override void CustomPostValidate(Customer customer)
        {
            if (!IsEmailRightForm(customer.Email))
            {
                _listValidate.Add(new { devMsg = "Email không đúng định dạng" });
            }
            if (!IsPhoneNumberRightForm(customer.PhoneNumber))
            {
                _listValidate.Add(new { devMsg = "Số điện thoại không đúng định dạng" });
            }
        }

        protected override void CustomPutValidate(Customer customer, Guid entityId)
        {
            if (!IsEmailRightForm(customer.Email))
            {
                _listValidate.Add(new { devMsg = "Email không đúng định dạng" });
            }
            if (!IsPhoneNumberRightForm(customer.PhoneNumber))
            {
                _listValidate.Add(new { devMsg = "Số điện thoại không đúng định dạng" });
            }
        }

        public IEnumerable<Customer> GetOfPage(int pageIndex, int pageSize, string fullName, Guid? groupId)
        {
            if (pageIndex < 0 || pageSize < 0)
            {
                return null;
            }
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            if(pageSize == 0)
            {
                pageSize = 10;
            }

            if (string.IsNullOrEmpty(fullName))
            {
                fullName = "";
            }
            
            int fromIndex = (pageIndex - 1) * pageSize;

            var customers =_customerRepository.GetInRange(fullName: fullName, groupId: groupId, fromIndex: fromIndex, numberOfRecords: pageSize);

            return customers;
        }
    }
}
