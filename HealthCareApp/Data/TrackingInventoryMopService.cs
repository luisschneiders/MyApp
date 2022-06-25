using System;
using DateTimeLibrary;
using Microsoft.EntityFrameworkCore;
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

        /*
		 * async method to add tracking inventory for mops
		 */
        public async Task AddTrackingInventoryMopAsync(TrackingInventoryMop trackingInventoryMop)
        {
            UserService userService = new UserService(_httpContextAccessor);

            trackingInventoryMop.IsActive = true;
            trackingInventoryMop.CreatedAt = trackingInventoryMop.UpdatedAt = DateTime.UtcNow;
            // Get current logged user ID
            trackingInventoryMop.InsertedBy = userService.UserId();

            try
            {
                _applicationDbContext.HcaTrackingInvetoryMop.Add(trackingInventoryMop);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(trackingInventoryMop).State = EntityState.Detached;
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                await Task.CompletedTask;
            }
        }
    }
}
