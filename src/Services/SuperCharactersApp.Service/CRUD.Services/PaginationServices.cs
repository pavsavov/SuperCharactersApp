namespace SuperCharactersApp.Services.CRUD.Services
{
    using X.PagedList;
    using System.Linq;
    using SuperCharactersApp.Services.CRUD.Services.Contracts;
    /// <summary>
    /// By implementing the IPaginService interface, the following class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginationServices<T>
        where T : class
    {
        private const int pageSize = 5;
        public IPagedList<T> Pagination(int? pageNumber, IService<T> entityServices)
        {
            var nextPage = pageNumber ?? 1;

            var allEntities = entityServices.GetAll();
            var paginatedEntitiesList = allEntities.ToPagedList(nextPage, pageSize);

            return paginatedEntitiesList;
        }
    }
}
