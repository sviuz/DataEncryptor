
using System.Web.Mvc;

namespace DataEncryptor.Attributes
{
    public class AuthorizedOnlyAttribute : AuthorizeAttribute
    {
        public string View { get; set; }
        public string Master { get; set; }

        public AuthorizedOnlyAttribute()
        {
            View = "error";
            Master = string.Empty;
        }

    }
}
