using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SCAN.Models
{
    public class ScanContext : IdentityDbContext<ScanUser>
    {
        public ScanContext() { }
        public ScanContext(DbContextOptions<ScanContext> option) :base(option) { }
        public virtual DbSet<Patient> Patients { get; set; }

    }
}
