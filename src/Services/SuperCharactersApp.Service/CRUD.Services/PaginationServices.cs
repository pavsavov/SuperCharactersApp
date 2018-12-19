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
        public IPagedList<T> Paginate(IQueryable<T> entity, int? page)
        {
            var pageNumber = page ?? 1;
            var onePageOfEntityViewModel = entity.ToPagedList(pageNumber, pageSize);
            return onePageOfEntityViewModel;
        }
    }
}
