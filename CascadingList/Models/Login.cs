using NuGet.Packaging.Signing;

namespace CascadingList.Models
{
    public class Login
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginToken { get; set; }
        public bool? IsActive { get; set; }
       public DateTimeOffset LastLogin { get; set; }
        
    }
}
