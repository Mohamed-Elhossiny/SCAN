namespace SCAN.Models
{
	public class Scan
	{
		public int ScanID { get; set; }
		public string? ScanName { get; set; }
		public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    }
}
