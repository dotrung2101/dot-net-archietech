using System;
namespace MISA.CukCuk.Core.AttributesCustom
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequiredNotNull : MISARequiredBase
    {
        public MISARequiredNotNull(string msg) : base(msg)
        {
        }
    }
}
