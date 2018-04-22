using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;

namespace Sidetech.Sne.Data.Helpers
{
    /// <summary>
    /// Assistente para ordenação
    /// </summary>
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> source, string sortBy)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (string.IsNullOrEmpty(sortBy))
                throw new ArgumentNullException("sortBy");

            var sortExpression = string.Empty;

            var listSortBy = sortBy.Split(',');
            foreach (var item in listSortBy)
            {
                sortExpression += AdjustDirection(item) + ",";
            }

            sortExpression = sortExpression.Substring(0, sortExpression.Length - 1);

            try
            {
                source = source.OrderBy(sortExpression);
            }
            catch (ParseException)
            {
                // o campo não faz parte do modelo
            }

            return source;
        }

        private static string AdjustDirection(string item)
        {
            if (!item.Contains(' '))
                return item; // nenhuma direção especificada

            var field = item.Split(' ')[0];
            var direction = item.Split(' ')[1];

            switch (direction)
            {
                case "asc":
                case "Ascending":
                    return field + " ascending";

                case "desc":
                case "Descending":
                    return field + " descending";

                default:
                    return field;
            };
        }
    }
}
