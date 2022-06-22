using System;
using DateTimeLibrary;
using TrackingInventoryLibrary.Models;

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
		 * async method to get mop tracking inventory by date
		 */

        //public async Task<TrackingInventoryMopDto> GetBarcodeByDateAsync(IDateTimeRange dateTime)
        //{
        //    await Task.CompletedTask;
        //}
    }
}
