
using AreaLibrary.Models;
using DepartmentLibrary.Models;
using LabelLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareApp.Data
{
	public class LabelMopService
	{
		private readonly ApplicationDbContext _applicationDbContext;
		private readonly IHttpContextAccessor _httpContextAccessor;

        public LabelMopService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
		{
			_applicationDbContext = applicationDbContext;
			_httpContextAccessor = httpContextAccessor;
		}

        /*
         * async method to get list of LabelMops
         */
        public async Task<List<LabelMopDto>> GetLabelMopsAsync()
        {

            List<LabelMopDto> labelMopList = new List<LabelMopDto>();

            /* Raw query with joins, filters and ordering */
            var query =
                (
                    from labelMop in _applicationDbContext.Set<LabelMop>()
                    join area in _applicationDbContext.Set<Area>()
                        on labelMop.AreaId equals area.Id
                    join department in _applicationDbContext.Set<Department>()
                        on area.DepartmentId equals department.Id
                    orderby labelMop.CreatedAt descending
                    select new { labelMop, area, department }
                ).AsNoTracking();

            foreach (var i in query)
            {
                labelMopList.Add(SetLabelMopDto(i.labelMop, i.area, i.department));
            }

            return await Task.FromResult(labelMopList);
        }

        /*
         * async method to search Label by barcode or area
         */
        public async Task<List<LabelMopDto>> SearchAsync(string searchTerm)
        {

            List<LabelMopDto> labelMopList = new List<LabelMopDto>();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await Task.FromResult(labelMopList);
            }

            var query =
                (
                    from labelMop in _applicationDbContext.Set<LabelMop>()
                    join area in _applicationDbContext.Set<Area>()
                        on labelMop.AreaId equals area.Id
                    join department in _applicationDbContext.Set<Department>()
                        on area.DepartmentId equals department.Id
                    where (EF.Functions.Like(labelMop.Barcode, $"%{searchTerm}%")
                    || EF.Functions.Like(area.Name, $"%{searchTerm}%")
                    || EF.Functions.Like(department.Name, $"%{searchTerm}%"))
                    orderby labelMop.CreatedAt descending
                    select new { labelMop, area, department }
                ).AsNoTracking();

            foreach (var i in query)
            {
                labelMopList.Add(SetLabelMopDto(i.labelMop, i.area, i.department));
            }

            return await Task.FromResult(labelMopList);
        }

        /*
         * method to get label mop by ID
         */
        public LabelMop GetLabelMopById(Guid guid)
        {
            UserService userService = new UserService(_httpContextAccessor);

            try
            {

                /* Raw query with joins, filters and ordering */
                var query =
                    (
                        from labelMop in _applicationDbContext.Set<LabelMop>()
                        join area in _applicationDbContext.Set<Area>()
                          on labelMop.AreaId equals area.Id
                        where labelMop.Id == guid
                        select new { labelMop, area }
                    ).AsNoTracking().FirstOrDefault();

                return SetLabelMopDetails(query.labelMop, query.area);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                throw;
            }
        }

        /*
         * async method to get label mop by barcode
         */

        public async Task<LabelMopDto> GetLabelMopByBarcodeAsync(string barcode)
        {

            UserService userService = new UserService(_httpContextAccessor);

            try
            {
                LabelMopDto labelMopDto = new();

                /* Raw query with joins, filters and ordering */
                var query =
                    (
                        from labelMop in _applicationDbContext.Set<LabelMop>()
                        join area in _applicationDbContext.Set<Area>()
                          on labelMop.AreaId equals area.Id
                        join department in _applicationDbContext.Set<Department>()
                          on area.DepartmentId equals department.Id
                        where labelMop.Barcode == barcode
                        select new { labelMop, area, department }
                    ).AsNoTracking().FirstOrDefault();

                labelMopDto = SetLabelMopDto(query.labelMop, query.area, query.department);

                return await Task.FromResult(labelMopDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                return await Task.FromResult(new LabelMopDto());
            }

        }

        /*
         * async method to add new Label
         */
        public async Task AddLabelMopAsync(LabelMop labelMop)
        {

            UserService userService = new UserService(_httpContextAccessor);

            labelMop.IsActive = true;
            labelMop.CreatedAt = labelMop.UpdatedAt = DateTime.UtcNow;
            // Get current logged user ID
            labelMop.InsertedBy = userService.UserId();

            try
            {
                _applicationDbContext.HcaLabelMop.Add(labelMop);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(labelMop).State = EntityState.Detached;
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                await Task.CompletedTask;
            }
        }

        /*
         * async method to update Label
         */
        public async Task UpdateLabelMopAsync(LabelMop labelMop)
        {

            labelMop.UpdatedAt = DateTime.UtcNow;

            try
            {
                _applicationDbContext.HcaLabelMop.Update(labelMop);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(labelMop).State = EntityState.Detached;

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                await Task.CompletedTask;
            }
        }

        /*
         * async method to update label status
         */
        public async Task UpdateLabelMopStatusAsync(LabelMop labelMop)
        {
            try
            {

                LabelMop labelMopUpdated = new();

                labelMopUpdated = GetLabelMopById(labelMop.Id);
                labelMopUpdated.IsActive = labelMop.IsActive;
                labelMopUpdated.UpdatedAt = DateTime.UtcNow;

                _applicationDbContext.HcaLabelMop.Update(labelMopUpdated);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(labelMopUpdated).State = EntityState.Detached;

                await Task.CompletedTask;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                await Task.CompletedTask;
            }
        }

        private static LabelMop SetLabelMopDetails(LabelMop labelMop, Area area)
        {
            LabelMop labelMopDetails = labelMop;

            return labelMopDetails;
        }

        private static LabelMopDto SetLabelMopDto(LabelMop labelMop, Area area, Department department)
        {
            LabelMopDto labelMopDto = new();
            labelMopDto.Id = labelMop.Id;
            labelMopDto.Barcode = labelMop.Barcode;
            labelMopDto.Quantity = labelMop.Quantity;
            labelMopDto.TimeIn = labelMop.TimeIn;
            labelMopDto.TimeOut = labelMop.TimeOut;
            labelMopDto.DepartmentId = labelMop.AreaId;
            labelMopDto.IsActive = labelMop.IsActive;
            labelMopDto.CompanyName = labelMop.CompanyName;

            if (labelMop.AreaId == area?.Id)
            {
                labelMopDto.AreaName = area.Name;
            }

            if (department?.Id == area?.DepartmentId)
            {
                labelMopDto.DepartmentName = department.Name;
            }

            return labelMopDto;
        }
    }
}
