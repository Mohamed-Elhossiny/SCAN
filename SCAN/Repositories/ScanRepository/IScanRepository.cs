using SCAN.ViewModels;

namespace SCAN.Repositories.ScanRepository
{
	public interface IScanRepository
	{
		Task<List<ScanVM>> GetAllScans();
	}
}
