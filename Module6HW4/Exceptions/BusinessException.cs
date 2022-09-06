using System;

namespace Module6HW4.Exceptions
{
    public class BusinessException : Exception
    {
        public string ErrorMessage { get; set; }

        public BusinessException(string errorMessage) : base()
        {
            ErrorMessage = errorMessage;
        }
    }
}
