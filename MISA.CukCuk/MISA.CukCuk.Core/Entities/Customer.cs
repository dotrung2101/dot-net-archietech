using System;
using MISA.CukCuk.Core.AttributesCustom;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Thông tin khách khách
    /// </summary>
    /// CreatedBy: NVMANH ()
    public class Customer
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [MISARequiredNotNull("Mã khách hàng không được phép để trống!!!")]
        [MISARequiredNotDuplicate("Mã khách hàng đã tồn tại trong hệ thống")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string MemberCardCode { get; set; }
        public Guid? CustomerGroupId { get; set; }

        [MISARequiredNotNull("Số điện thoại không được phép để trống!!!")]
        [MISARequiredNotDuplicate("Số điện thoại đã tồn tại trong hệ thống")]
        public string PhoneNumber { get; set; }

        [MISARequiredNotNull("Email không được phép để trống!!!")]
        [MISARequiredNotDuplicate("Email đã tồn tại trong hệ thống")]
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
