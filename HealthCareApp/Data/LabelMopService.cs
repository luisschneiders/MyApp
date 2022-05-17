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

        // async method to get list of LabelMops
        public async Task<List<LabelMopDto>> GetLabelMopsAsync()
        {
            UserService userService = new UserService(_httpContextAccessor);
            List<LabelMopDto> labelMopList = new List<LabelMopDto>();

            /* Raw query with joins, filters and ordering */
            var query =
                (
                    from labelMop in _applicationDbContext.Set<LabelMop>()
                    join department in _applicationDbContext.Set<Department>()
                        on labelMop.DepartmentId equals department.Id
                    where labelMop.InsertedBy == userService.UserId()
                    orderby labelMop.CreatedAt descending
                    select new { labelMop, department }
                ).AsNoTracking();

            foreach (var i in query)
            {
                labelMopList.Add(SetLabelMopDto(i.labelMop, i.department));
            }

            return await Task.FromResult(labelMopList);
        }

        public async Task<List<LabelMopDto>> SearchAsync(string searchTerm)
        {
            UserService userService = new UserService(_httpContextAccessor);
            List<LabelMopDto> labelMopList = new List<LabelMopDto>();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await Task.FromResult(labelMopList);
            }

            var query =
                (
                    from labelMop in _applicationDbContext.Set<LabelMop>()
                    join department in _applicationDbContext.Set<Department>()
                        on labelMop.DepartmentId equals department.Id
                    where labelMop.InsertedBy == userService.UserId()
                    && (EF.Functions.Like(labelMop.Barcode, $"%{searchTerm}%")
                    || EF.Functions.Like(labelMop.Location, $"%{searchTerm}%"))
                    orderby labelMop.CreatedAt descending
                    select new { labelMop, department }
                ).AsNoTracking();

            foreach (var i in query)
            {
                labelMopList.Add(SetLabelMopDto(i.labelMop, i.department));
            }

            return await Task.FromResult(labelMopList);
        }

        /*
         * method to get label mop by ID
         */
        public LabelMop GetLabelMopById(Guid guid)
        {
            try
            {
                UserService userService = new UserService(_httpContextAccessor);

                /* Raw query with joins, filters and ordering */
                var query =
                    (
                        from labelMop in _applicationDbContext.Set<LabelMop>()
                        join department in _applicationDbContext.Set<Department>()
                          on labelMop.DepartmentId equals department.Id
                        where labelMop.Id == guid
                        select new { labelMop, department }
                    ).AsNoTracking().FirstOrDefault();

                return SetLabelMopDetails(query.labelMop, query.department);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * async method to add new label
         */
        public async Task<LabelMop> AddLabelMopAsync(LabelMop labelMop)
        {

            UserService userService = new UserService(_httpContextAccessor);

            labelMop.IsActive = true;
            labelMop.CreatedAt = labelMop.UpdatedAt = DateTime.UtcNow;
            // Get current logged user ID
            labelMop.InsertedBy = userService.UserId();

            try
            {
                _applicationDbContext.LabelMop.Add(labelMop);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(labelMop).State = EntityState.Detached;
            }
            catch (Exception)
            {
                throw;
            }

            return labelMop;
        }

        /*
         * async method to update label
         */
        public async Task<bool> UpdateLabelMopAsync(LabelMop labelMop)
        {
            labelMop.UpdatedAt = DateTime.UtcNow;

            try
            {
                _applicationDbContext.LabelMop.Update(labelMop);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(labelMop).State = EntityState.Detached;

                await Task.CompletedTask;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                await Task.CompletedTask;

                return false;
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

                _applicationDbContext.LabelMop.Update(labelMopUpdated);
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

        private static LabelMop SetLabelMopDetails(LabelMop labelMop, Department department)
        {
            LabelMop labelMopDetails = labelMop;

            return labelMopDetails;
        }

        private static LabelMopDto SetLabelMopDto(LabelMop labelMop, Department department)
        {
            LabelMopDto labelMopDto = new();
            labelMopDto.Id = labelMop.Id;
            labelMopDto.Barcode = labelMop.Barcode;
            labelMopDto.Quantity = labelMop.Quantity;
            labelMopDto.TimeIn = labelMop.TimeIn;
            labelMopDto.TimeOut = labelMop.TimeOut;
            labelMopDto.DepartmentId = labelMop.DepartmentId;
            labelMopDto.IsActive = labelMop.IsActive;
            labelMopDto.CompanyName = labelMop.CompanyName;
            labelMopDto.Location = labelMop.Location;

            if (labelMop.DepartmentId == department?.Id)
            {
                labelMopDto.DepartmentName = department.Name;
            }

            return labelMopDto;
        }
    }
}
