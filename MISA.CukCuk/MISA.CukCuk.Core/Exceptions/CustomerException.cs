using System;
namespace MISA.CukCuk.Core.Exceptions
{
    public class CustomerException : Exception
    {
        private Object _ExceptionData;

        public Object ExceptionData
        {
            get
            {
                return this._ExceptionData;
            }
        }

        public CustomerException(Object data) : base()
        {
            _ExceptionData = data;
        }
    }
}
