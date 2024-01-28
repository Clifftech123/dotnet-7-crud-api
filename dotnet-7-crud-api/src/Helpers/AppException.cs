using System.Globalization;

namespace dotnet_7_crud_api.Helpers
{
    public class AppException : Exception
    {

        public AppException() : base() { }


        public AppException(string message) : base(message) { }

        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
