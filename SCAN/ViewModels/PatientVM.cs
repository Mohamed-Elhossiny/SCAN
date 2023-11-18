using Microsoft.AspNetCore.Mvc.Rendering;
using SCAN.Enums;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace SCAN.ViewModels
{
    public class PatientVM
    {
        public int? PatinetID { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        [MinLength(3)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [MinLength(3)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter arabic name")]
        public string? ArabicFirstName { get; set; }
        [Required(ErrorMessage = "Please enter arabic name")]
        public string? ArabicLastName { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string? Government { get; set; }

        [MaxLength(11)]
        [RegularExpression(@"^(010|011|012|015)[0-9]{8}$", ErrorMessage = "Enter Valid Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Enter age of the patient")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter gender of the patient")]
        public string? Gender { get; set; }

        //public References Reference { get; set; }
        public int? ReferenceID { get; set; }

		public IEnumerable<SelectListItem>? ReferenceList { get; set; }

		[Required(ErrorMessage = "Please choose appointment date")]
        public DateTime? DateofAppointment { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }

        //public CheckType CheckType { get; set; }
        public int? CheckTypeID { get; set; }
		public IEnumerable<SelectListItem>? CheckTypeList { get; set; }
		public string? ScanImageUrl { get; set; }

        public int? ResultID { get; set; }

        [Required(ErrorMessage = "Please Choose Type of Scan")]
		public int Scan_ID { get; set; }
		public string? ScanName { get; set; }

	}
}
