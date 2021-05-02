using System;
namespace MISA.CukCuk.Core.AttributesCustom
{

    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequiredNotDuplicate : MISARequiredBase
    {
        public MISARequiredNotDuplicate(string msg) : base(msg)
        {
        }
    }
}
