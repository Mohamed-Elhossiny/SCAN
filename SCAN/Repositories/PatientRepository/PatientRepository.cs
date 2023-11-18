using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCAN.Enums;
using SCAN.Models;
using SCAN.ViewModels;

namespace SCAN.Repositories.PatientRepository
{
	public class PatientRepository : IPatientRepository
	{
		private readonly ScanContext _context;

		public PatientRepository(ScanContext context)
		{
			_context = context;
		}
		public bool AddPatient(PatientVM patientVM)
		{
			// Check Patient exist in the database
			var ispatientexist = _context.Patients.Any(p => p.PatientID == patientVM.PatinetID);
			if (ispatientexist == false)
			{
				var patient = new Patient()
				{
					FirstName = patientVM.FirstName,
					LastName = patientVM.LastName,
					ArabicFirstName = patientVM.ArabicFirstName,
					ArabicLastName = patientVM.ArabicLastName,
					City = patientVM.City,
					Government = patientVM.Government,
					Phone = patientVM.Phone,
					Age = patientVM.Age,
					Gender = patientVM.Gender,
					ReferenceName = Enum.GetName(typeof(References), patientVM.ReferenceID),
					ReferenceID = (int)patientVM.ReferenceID,
					BirthDate = patientVM.BirthDate,
					DateofAppointment = patientVM.DateofAppointment,
					CheckTpye = Enum.GetName(typeof(CheckType), patientVM.CheckTypeID),
					CheckTpyeID = (int)patientVM.CheckTypeID,
					Scan_ID = (int)patientVM.Scan_ID
				};
				_context.AddAsync(patient);
				_context.SaveChanges();
				return true;
			}
			return false;
		}

		public async Task<List<PatientVM>> GetAllPatients()
		{
			var patientsdb = await _context.Patients.Include(p => p.Scan).ToListAsync();
			var patientsVM = new List<PatientVM>();
			if (patientsdb != null)
			{
				foreach (var patient in patientsdb)
				{
					patientsVM.Add(new PatientVM()
					{
						PatinetID = patient.PatientID,
						FirstName = patient.FirstName,
						LastName = patient.LastName,
						ArabicFirstName = patient.ArabicFirstName,
						ArabicLastName = patient.ArabicLastName,
						City = patient.City,
						Government = patient.Government,
						Phone = patient.Phone,
						Age = patient.Age != null ? (int)patient.Age : 0,
						Gender = patient.Gender,
						ReferenceID = patient.ReferenceID,
						BirthDate = patient.BirthDate,
						DateofAppointment = patient.DateofAppointment,
						CheckTypeID = patient.CheckTpyeID,
						ScanImageUrl = patient.ScanImageUrl,
						ScanName = patient.Scan?.ScanName ?? ""
					});
				}
				return patientsVM;
			}
			return patientsVM;
		}

		public async Task<PatientVM> GetPatient(int patientID)
		{
			var patientdb = await _context.Patients.Where(p => p.PatientID == patientID).FirstOrDefaultAsync();
			if (patientdb != null)
			{
				var patientVM = new PatientVM()
				{
					FirstName = patientdb.FirstName,
					LastName = patientdb.LastName,
					ArabicFirstName = patientdb.ArabicFirstName,
					ArabicLastName = patientdb.ArabicLastName,
					City = patientdb.City,
					Government = patientdb.Government,
					Phone = patientdb.Phone,
					Age = patientdb.Age != null ? (int)patientdb.Age : 0,
					Gender = patientdb.Gender,
					ReferenceID = patientdb.ReferenceID,
					BirthDate = patientdb.BirthDate,
					DateofAppointment = patientdb.DateofAppointment,
					CheckTypeID = patientdb.CheckTpyeID,
					ScanImageUrl = patientdb.ScanImageUrl
				};
				return patientVM;
			}
			return new PatientVM();
		}

		public IEnumerable<SelectListItem> GetReferenceList()
		{
			var referenceList = Enum.GetValues(typeof(References))
						   .Cast<References>()
						   .Select(r => new SelectListItem
						   {
							   Value = ((int)r).ToString(),
							   Text = r.ToString()
						   });
			return referenceList;

		}
		public IEnumerable<SelectListItem> GetCheckTypeList()
		{
			var checktype = Enum.GetValues(typeof(CheckType))
				.Cast<CheckType>()
				.Select(c => new SelectListItem
				{
					Value = ((int)c).ToString(),
					Text = c.ToString()
				});
			return checktype;

		}

	}
}
