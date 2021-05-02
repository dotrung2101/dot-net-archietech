using System;
using MISA.CukCuk.Core.AttributesCustom;

namespace MISA.CukCuk.Core.Entities
{
    public class CustomerGroup
    {
        public CustomerGroup()
        {
        }

        public Guid CustomerGroupId { get; set; }

        [MISARequiredNotNull("Tên nhóm khách hàng không được phép để trống!!!")]
        [MISARequiredNotDuplicate("Tên nhóm khách hàng đã tồn tại trong hệ thống")]
        public string CustomerGroupName { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
