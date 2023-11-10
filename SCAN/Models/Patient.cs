using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAN.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ArabicFirstName { get; set; }

        public string? ArabicLastName { get; set; }

        public string? City { get; set; }
        public string? Government { get; set; }

        public string? Phone { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? ReferenceName { get; set; }
        public int ReferenceID { get; set; }

        public DateTime? BirthDate { get; set; }
        public DateTime? DateofAppointment { get; set; }
        public string? ScanImageUrl { get; set; }

        public string? CheckTpye { get; set; }
        public int? CheckTpyeID { get; set; }
    }
}
