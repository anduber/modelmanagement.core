using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using ModelManagement.Core.Business.Business.Model.Utils;
using System.Linq.Expressions;
using ModelManagement.Core.Business.Business.Helpers;

namespace ModelManagement.Core.Business.Business.Query.EntityProfile
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T item in enumerable) { action(item); }
        }

        public static List<KeyDescription> ToLookUp(this IQueryable source, params Expression<Func<KeyDescription, object>>[] membersToExpand)
        {
            return source.ProjectTo<KeyDescription>().ToList();
        }

        public static List<KeyDescriptionId> ToLookUpKeyDescId(this IQueryable source, params Expression<Func<KeyDescriptionId, object>>[] membersToExpand)
        {
            return source.ProjectTo<KeyDescriptionId>().ToList();
        }

        public static List<T> ToList<T>(this IQueryable source, params Expression<Func<KeyDescription, object>>[] membersToExpand)
        {
            return source.ProjectTo<T>().ToList();
        }

        public static T Get<T>(this IQueryable source, params Expression<Func<KeyDescription, object>>[] membersToExpand)
        {
            return source.ProjectTo<T>().SingleOrDefault();
        }

        public static IQueryable<TSource> Paginate<TSource, TKey>(this IQueryable<TSource> source,
          Expression<Func<TSource, TKey>> orderBy, int page, int pageSize)
        {
            return source.OrderBy(orderBy)
                .Skip(page * pageSize)
                .Take(pageSize);
        }

        //public static int ToAge(this DateTime date)
        //{
        //    return DateConverter.GetAgeFromDate(date);
        //}

        //public static int ToAge(this DateTime? date)
        //{
        //    return DateConverter.GetAgeFromDate(date);
        //}

        public static IQueryable<TSource> Paginate<TSource, TKey>(this IQueryable<TSource> source,
          Expression<Func<TSource, TKey>> orderBy, Pagination pagination)
        {
            if (pagination == null)
            {
                pagination = new Pagination();
            }
            if (pagination != null && pagination.PageSize == 0)
            {
                pagination.PageSize = 100;
            }
            return source.OrderBy(orderBy)
               .Skip(pagination.Page * pagination.PageSize)
               .Take(pagination.PageSize);
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (keySelector(element) != null)
                {
                    if (seenKeys.Add(keySelector(element)))
                    {
                        yield return element;
                    }
                }

            }

        }
    }
}
