using Microsoft.AspNetCore.Identity;

namespace SCAN.Models
{
    public class ScanUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
