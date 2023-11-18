using Microsoft.EntityFrameworkCore;
using SCAN.Models;
using SCAN.ViewModels;

namespace SCAN.Repositories.ScanRepository
{
	public class ScanRepository : IScanRepository
	{
		private readonly ScanContext context;

		public ScanRepository(ScanContext context)
        {
			this.context = context;
		}
		public async Task<List<ScanVM>> GetAllScans()
		{
			var scanList = new List<ScanVM>();
			var scanlistdb = await context.Scans.ToListAsync();
			foreach (var scan in scanlistdb) 
			{
				scanList.Add(new ScanVM
				{
					ScanID = scan.ScanID,
					ScanName = scan.ScanName,
				});
			}
			return scanList;
		}
	}
}
