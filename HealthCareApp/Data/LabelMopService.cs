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
        public async Task<List<LabelMop>> GetLabelMopsAsync()
        {
            UserService userService = new UserService(_httpContextAccessor);
            List<LabelMop> labelMopList = new List<LabelMop>();

            /* Raw query with joins, filters and ordering */
            var query =
                (
                    from labelMop in _applicationDbContext.Set<LabelMop>()
                    where labelMop.InsertedBy == userService.UserId()
                    orderby labelMop.CreatedAt descending
                    select new { labelMop }
                ).AsNoTracking();

            foreach (var i in query)
            {
                labelMopList.Add(SetLabelMopDetails(i.labelMop));
            }

            return await Task.FromResult(labelMopList);
        }

        public async Task<List<LabelMop>> SearchAsync(string searchTerm)
        {
            UserService userService = new UserService(_httpContextAccessor);
            List<LabelMop> labelMopList = new List<LabelMop>();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await Task.FromResult(labelMopList);
            }

            var query =
                (
                    from labelMop in _applicationDbContext.Set<LabelMop>()
                    where labelMop.InsertedBy == userService.UserId()
                    && (EF.Functions.Like(labelMop.Barcode, $"%{searchTerm}%")
                    || EF.Functions.Like(labelMop.Location, $"%{searchTerm}%"))
                    orderby labelMop.CreatedAt descending
                    select new { labelMop }
                ).AsNoTracking();

            foreach (var i in query)
            {
                labelMopList.Add(SetLabelMopDetails(i.labelMop));
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
                        where labelMop.Id == guid
                        select new { labelMop }
                    ).AsNoTracking().FirstOrDefault();

                return SetLabelMopDetails(query.labelMop);

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
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        private static LabelMop SetLabelMopDetails(LabelMop labelMop)
        {
            LabelMop labelMopDetails = labelMop;

            return labelMopDetails;
        }
    }
}
