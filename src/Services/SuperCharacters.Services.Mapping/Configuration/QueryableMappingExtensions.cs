namespace SuperCharacters.Services.Mapping
{
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    /// <summary>
    /// Extensions for simplifing mapping methods.
    /// </summary>
    public static class QueryableMappingExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(
           this IQueryable source,
           params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo(membersToExpand);
        }

        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            object parameters)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo<TDestination>(parameters);
        }
    }
}
