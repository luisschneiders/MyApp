using System;
using AreaLibrary.Models;
using DepartmentLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareApp.Data
{
	public class AreaService
	{
		private readonly ApplicationDbContext _applicationDbContext;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AreaService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
		{
			_applicationDbContext = applicationDbContext;
			_httpContextAccessor = httpContextAccessor;
		}

        /*
         * async method to get list of Areas
         */
        public async Task<List<AreaDto>> GetAreasAsync()
        {
            UserService userService = new UserService(_httpContextAccessor);
            List<AreaDto> areaList = new List<AreaDto>();

            /* Raw query with joins, filters and ordering */
            var query =
                (
                    from area in _applicationDbContext.Set<Area>()
                    join department in _applicationDbContext.Set<Department>()
                        on area.DepartmentId equals department.Id
                    orderby area.CreatedAt descending
                    select new { area, department }
                ).AsNoTracking();

            foreach (var i in query)
            {
                areaList.Add(SetAreaDetailsDto(i.area, i.department));
            }

            return await Task.FromResult(areaList);
        }

        // async method to get list of Areas active
        public async Task<List<AreaDto>> GetActiveAreasAsync()
        {
            UserService userService = new UserService(_httpContextAccessor);
            List<AreaDto> areaList = new List<AreaDto>();

            /* Raw query with joins, filters and ordering */
            var query =
                (
                    from area in _applicationDbContext.Set<Area>()
                    join department in _applicationDbContext.Set<Department>()
                        on area.DepartmentId equals department.Id
                    where area.IsActive == true
                    orderby area.Name ascending
                    select new { area, department }
                ).AsNoTracking();

            foreach (var i in query)
            {
                areaList.Add(SetAreaDetailsDto(i.area, i.department));
            }

            return await Task.FromResult(areaList);
        }

        /*
         * async method to search Area by name
         */
        public async Task<List<AreaDto>> SearchAsync(string searchTerm)
        {
            UserService userService = new UserService(_httpContextAccessor);
            List<AreaDto> areaList = new List<AreaDto>();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await Task.FromResult(areaList);
            }

            var query =
                (
                    from area in _applicationDbContext.Set<Area>()
                    join department in _applicationDbContext.Set<Department>()
                        on area.DepartmentId equals department.Id
                    where EF.Functions.Like(area.Name, $"%{searchTerm}%")
                    orderby area.CreatedAt descending
                    select new { area, department }
                ).AsNoTracking();

            foreach (var i in query)
            {
                areaList.Add(SetAreaDetailsDto(i.area, i.department));
            }

            return await Task.FromResult(areaList);
        }

        /*
         * method to get Area by ID
         */
        public Area GetAreaById(Guid guid)
        {
            try
            {
                UserService userService = new UserService(_httpContextAccessor);

                /* Raw query with joins, filters and ordering */
                var query =
                    (
                        from area in _applicationDbContext.Set<Area>()
                        join department in _applicationDbContext.Set<Department>()
                          on area.DepartmentId equals department.Id
                        where area.Id == guid
                        select new { area, department }
                    ).AsNoTracking().FirstOrDefault();

                return SetAreaDetails(query.area, query.department);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                throw;
            }
        }

        /*
         * async method to add new Area
         */
        public async Task AddAreaAsync(Area area)
        {

            UserService userService = new UserService(_httpContextAccessor);

            area.IsActive = true;
            area.CreatedAt = area.UpdatedAt = DateTime.UtcNow;
            // Get current logged user ID
            area.InsertedBy = userService.UserId();

            try
            {
                _applicationDbContext.HcaArea.Add(area);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(area).State = EntityState.Detached;

                await Task.CompletedTask;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                await Task.CompletedTask;
            }
        }

        /*
         * async method to update Area
         */
        public async Task UpdateAreaAsync(Area area)
        {
            area.UpdatedAt = DateTime.UtcNow;

            try
            {
                _applicationDbContext.HcaArea.Update(area);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(area).State = EntityState.Detached;

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);

                await Task.CompletedTask;
            }
        }

        /*
         * async method to update Area status
         */
        public async Task UpdateAreaStatusAsync(Area area)
        {
            try
            {

                Area areaUpdated = new();

                areaUpdated = GetAreaById(area.Id);
                areaUpdated.IsActive = area.IsActive;
                areaUpdated.UpdatedAt = DateTime.UtcNow;

                _applicationDbContext.HcaArea.Update(areaUpdated);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(areaUpdated).State = EntityState.Detached;

                await Task.CompletedTask;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                await Task.CompletedTask;
            }
        }

        private static Area SetAreaDetails(Area area, Department department)
        {
            Area areaDetails = area;

            return areaDetails;
        }

        private static AreaDto SetAreaDetailsDto(Area area, Department department)
        {
            AreaDto areaDto = new();
            areaDto.Id = area.Id;
            areaDto.DepartmentId = area.DepartmentId;
            areaDto.IsActive = area.IsActive;
            areaDto.Name = area.Name;

            if (area.DepartmentId == department?.Id)
            {
                areaDto.DepartmentName = department.Name;
            }

            return areaDto;
        }
    }
}
