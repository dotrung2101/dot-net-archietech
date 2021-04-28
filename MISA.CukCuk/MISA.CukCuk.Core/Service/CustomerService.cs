using System;
using System.Collections.Generic;
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


        protected override void ValidatePutData(Customer customer)
        {
            List<Object> validate = new List<Object>();
            var validateCustomerCode = CheckPutValidateCustomerCode(customer.CustomerCode, customer.CustomerId);
            var validateEmail = CheckPutValidateEmail(customer.Email, customer.CustomerId);
            var validatePhoneNumber = CheckPutValidatePhoneNumber(customer.PhoneNumber, customer.CustomerId);

            if (!(validateCustomerCode is null))
            {
                validate.Add(validateCustomerCode);
            }
            if (!(validateEmail is null))
            {
                validate.Add(validateEmail);
            }
            if (!(validatePhoneNumber is null))
            {
                validate.Add(validatePhoneNumber);
            }

            if (validate.Count > 0)
            {
                throw new CustomerException(validate.ToArray());
            }
        }

        protected override void ValidatePostData(Customer customer)
        {
            List<Object> validate = new List<Object>();
            var validateCustomerCode = CheckPostValidateCustomerCode(customer.CustomerCode);
            var validateEmail = CheckPostValidateEmail(customer.Email);
            var validatePhoneNumber = CheckPostValidatePhoneNumber(customer.PhoneNumber);

            if (!(validateCustomerCode is null))
            {
                validate.Add(validateCustomerCode);
            }
            if (!(validateEmail is null))
            {
                validate.Add(validateEmail);
            }
            if (!(validatePhoneNumber is null))
            {
                validate.Add(validatePhoneNumber);
            }

            if(validate.Count > 0)
            {
                throw new CustomerException(validate.ToArray());
            }
        }

        private Object CheckPostValidateCustomerCode(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode))
            {
                var response = new
                {
                    devMsg = "Mã khách hàng không được phép để trống",
                    MISACode = "001"
                };
                return response;
            }

            var customerCodeExists = _customerRepository.CheckPostCustomerCodeExist(customerCode);
            if (customerCodeExists == true)
            {
                var response = new
                {
                    devMsg = "Mã khách hàng đã tồn tại trong hệ thống!",
                    MISACode = "002"
                };
                return response;
            }

            return null;
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

        private Object CheckPostValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                var response = new
                {
                    devMsg = "Email không được phép để trống",
                    MISACode = "001"
                };
                return response;
            }

            if (!IsEmailRightForm(email))
            {
                var response = new
                {
                    devMsg = "Email không đúng định dạng",
                    MISACode = "003"
                };
                return response;
            }

            var emailExists = _customerRepository.CheckPostEmailExist(email);
            if (emailExists == true)
            {
                var response = new
                {
                    devMsg = "Email đã tồn tại trong hệ thống!",
                    MISACode = "002"
                };
                return response;
            }

            return null;
        }

        private Object CheckPostValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                var response = new
                {
                    devMsg = "Số điện thoại không được phép để trống",
                    MISACode = "001"
                };
                return response;
            }

            bool regrexPhoneNumber = int.TryParse(phoneNumber, out _);

            if (!regrexPhoneNumber)
            {
                var response = new
                {
                    devMsg = "Số điện thoại không đúng định dạng",
                    MISACode = "003"
                };
                return response;
            }

            var phoneNumberExists = _customerRepository.CheckPostPhoneNumberExist(phoneNumber);
            if (phoneNumberExists == true)
            {
                var response = new
                {
                    devMsg = "Số điện thoại đã tồn tại trong hệ thống!",
                    MISACode = "002"
                };
                return response;
            }

            return null;
        }

        private Object CheckPutValidateCustomerCode(string customerCode, Guid id)
        {
            if (string.IsNullOrEmpty(customerCode))
            {
                var response = new
                {
                    devMsg = "Mã khách hàng không được phép để trống",
                    MISACode = "001"
                };
                return response;
            }

            var customerCodeExists = _customerRepository.CheckPutCustomerCodeExist(customerCode, id);
            if (customerCodeExists == true)
            {
                var response = new
                {
                    devMsg = "Mã khách hàng đã tồn tại trong hệ thống!",
                    MISACode = "002"
                };
                return response;
            }

            return null;
        }

        private Object CheckPutValidateEmail(string email, Guid id)
        {
            if (string.IsNullOrEmpty(email))
            {
                var response = new
                {
                    devMsg = "Email không được phép để trống",
                    MISACode = "001"
                };
                return response;
            }

            if (!IsEmailRightForm(email))
            {
                var response = new
                {
                    devMsg = "Email không đúng định dạng",
                    MISACode = "003"
                };
                return response;
            }

            var emailExists = _customerRepository.CheckPutEmailExist(email, id);
            if (emailExists == true)
            {
                var response = new
                {
                    devMsg = "Email đã tồn tại trong hệ thống!",
                    MISACode = "002"
                };
                return response;
            }

            return null;
        }

        private Object CheckPutValidatePhoneNumber(string phoneNumber, Guid id)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                var response = new
                {
                    devMsg = "Số điện thoại không được phép để trống",
                    MISACode = "001"
                };
                return response;
            }

            bool regrexPhoneNumber = int.TryParse(phoneNumber, out _);

            if (!regrexPhoneNumber)
            {
                var response = new
                {
                    devMsg = "Số điện thoại không đúng định dạng",
                    MISACode = "003"
                };
                return response;
            }

            var phoneNumberExists = _customerRepository.CheckPutPhoneNumberExist(phoneNumber, id);
            if (phoneNumberExists == true)
            {
                var response = new
                {
                    devMsg = "Số điện thoại đã tồn tại trong hệ thống!",
                    MISACode = "002"
                };
                return response;
            }

            return null;
        }

        public IEnumerable<Customer> GetOfPage(int pageIndex, int pageSize, string fullName, Guid? groupId)
        {

            int fromIndex = (pageIndex - 1) * pageSize;

            var customers =_customerRepository.GetInRange(fullName: fullName, groupId: groupId, fromIndex: fromIndex, numberOfRecords: pageSize);

            return customers;
        }
    }
}
