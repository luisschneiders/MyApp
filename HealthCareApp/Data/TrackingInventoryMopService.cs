using System;
namespace HealthCareApp.Data
{
	public class TrackingInventoryMopService
	{
		private readonly ApplicationDbContext _applicationDbContext;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public TrackingInventoryMopService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
		{
			_applicationDbContext = applicationDbContext;
			_httpContextAccessor = httpContextAccessor;
		}

		/*
		 * async method to get label by barcode
		 */

		//public async Task<> GetLabelMopAsync()
  //      {
		//	await Task.CompletedTask;
  //      }
	}
}
