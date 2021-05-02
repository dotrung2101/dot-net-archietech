using System;
namespace MISA.CukCuk.Core.AttributesCustom
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequiredBase : Attribute
    {

        public string Msg { get; set; }

        public MISARequiredBase(string msg)
        {
            Msg = msg;
        }
    }
    
    
    
}
