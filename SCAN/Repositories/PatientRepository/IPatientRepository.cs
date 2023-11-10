using SCAN.ViewModels;

namespace SCAN.Repositories.PatientRepository
{
    public interface IPatientRepository
    {
        bool AddPatient(PatientVM patientVM);
        Task<PatientVM> GetPatient(int patientID);
        Task<List<PatientVM>> GetAllPatients();
    }
}
