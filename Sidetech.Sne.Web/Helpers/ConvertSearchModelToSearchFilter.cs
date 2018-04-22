using Sidetech.Sne.Domain.Helpers.FilterHelpers;
using Sidetech.Sne.Web.Helpers.Filters;
using System;

namespace Sidetech.Sne.Web.Helpers
{
    public static class ConvertSearchModelToSearchFilter<TEntity> where TEntity : class
    {
        public static SearchFilter<TEntity> Convert(SearchModel filter)
        {
            var request = new SearchFilter<TEntity>();

            if (filter != null)
            {
                request.PageIndex = filter.PageIndex ?? filter.PageIndex;
                request.PageSize = filter.PageSize ?? filter.PageSize;

                if (!string.IsNullOrEmpty(filter.SortField))
                {
                    request.Sort.Add(filter.SortDirection, filter.SortField);
                }

                if (filter.Filters != null && filter.Filters.Count > 0)
                {
                    foreach (var item in filter.Filters)
                    {
                        if (!string.IsNullOrEmpty(item.Key) && !string.IsNullOrEmpty(item.Value))
                        {
                            request.Filters.Add(item.Key.Trim(new Char[] { ' ', '\"', '*' }), item.Value.Trim(new Char[] { ' ', '\"', '*' }));
                        }
                    }
                }
            }

            return request;
        }
    }
}
