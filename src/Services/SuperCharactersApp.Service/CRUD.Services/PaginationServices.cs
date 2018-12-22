namespace SuperCharactersApp.Services.CRUD.Services
{
    using X.PagedList;
    using SuperCharactersApp.Services.CRUD.Services.Contracts;

    /// <summary>
    /// By using a third-party library called X.PagedList, the following class performs the back-end logic
    /// for implementing paging function on all web-pages.Since it is a template class the Pagination method 
    /// is used by every entity,therefore IService<T> interface as parameter is the injected services needed
    /// for calling the GetAll method which will retrieve all records from DbSet.
    /// The paginatedEntitiesList variable is a type of IPaged<T> - custom collection implementation of the library.
    /// In few words, ToPagedList slices the allEntities collection in same-sized parts.The size is the page size,
    /// set by the pagesSize variable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginationServices<T>
        where T : class
    {
        private const int pageSize = 5;
        private const int firstPage = 1;
        public IPagedList<T> Pagination(int? pageNumber, IService<T> entityServices)
        {
            var nextPage = pageNumber ?? firstPage;

            var allEntities = entityServices.GetAll();
            var paginatedEntitiesList = allEntities.ToPagedList(nextPage, pageSize);

            return paginatedEntitiesList;
        }
    }
}
