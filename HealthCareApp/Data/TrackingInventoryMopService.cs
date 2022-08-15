using System;
using AreaLibrary.Models;
using DateTimeLibrary;
using DepartmentLibrary.Models;
using LabelLibrary.Models;
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
        public async Task<List<TrackingInventoryMopDto>> GetTrackingInventoryMopByDateAsync(IDateTimeRange dateTime)
        {
            List<TrackingInventoryMopDto> trackingInventoryMopDtoList = new();

            /* Raw query with joins, filters and ordering */
            var query =
                (
                    from trackingInventoryMop in _applicationDbContext.Set<TrackingInventoryMop>()
                    join labelMop in _applicationDbContext.Set<LabelMop>()
                        on trackingInventoryMop.LabelMopId equals labelMop.Id
                    join area in _applicationDbContext.Set<Area>()
                        on labelMop.AreaId equals area.Id
                    join department in _applicationDbContext.Set<Department>()
                        on area.DepartmentId equals department.Id
                    where (trackingInventoryMop.ScanTime.Date >= dateTime.Start.Date && trackingInventoryMop.ScanTime.Date <= dateTime.End.Date)
                    orderby trackingInventoryMop.CreatedAt descending
                    select new { trackingInventoryMop, labelMop, area, department }
                ).AsNoTracking();

            foreach (var i in query)
            {
                trackingInventoryMopDtoList.Add(SetTrackingInventotyMopDto(i.trackingInventoryMop, i.labelMop, i.area, i.department));
            }

            return await Task.FromResult(trackingInventoryMopDtoList);

        }

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

        private static TrackingInventoryMopDto SetTrackingInventotyMopDto(TrackingInventoryMop trackingInventoryMop, LabelMop labelMop, Area area, Department department)
        {
            TrackingInventoryMopDto trackingInventoryMopDto = new();
            trackingInventoryMopDto.Id = trackingInventoryMop.Id;
            trackingInventoryMopDto.ScanTime = trackingInventoryMop.ScanTime;
            trackingInventoryMopDto.EntryType = trackingInventoryMop.EntryType;
            trackingInventoryMopDto.CleanMopQuantity = trackingInventoryMop.CleanMopQuantity;
            trackingInventoryMopDto.DirtyMopQuantity = trackingInventoryMop.DirtyMopQuantity;
            trackingInventoryMopDto.IsActive = trackingInventoryMop.IsActive;

            if (trackingInventoryMop.LabelMopId == labelMop?.Id)
            {
                trackingInventoryMopDto.Barcode = labelMop.Barcode;
                trackingInventoryMopDto.MopQuantity = labelMop.Quantity;
            }

            if (labelMop?.AreaId == area?.Id)
            {
                trackingInventoryMopDto.AreaName = area?.Name;
            }

            if (department?.Id == area?.DepartmentId)
            {
                trackingInventoryMopDto.DepartmentName = department?.Name;
            }

            return trackingInventoryMopDto;
        }
    }
}
