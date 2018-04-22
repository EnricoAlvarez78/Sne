using Sidetech.Sne.Domain.Helpers.FilterHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sidetech.Sne.Data.Helpers
{
    public static class GenericFilterHelper<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GenericFilter(IQueryable<TEntity> query, Dictionary<string, string> filters)
        {
            var entityType = typeof(TEntity);

            if (filters != null && filters.Count > 0)
            {
                foreach (var filterItem in filters)
                {
                    if (!string.IsNullOrEmpty(filterItem.Key) && !string.IsNullOrEmpty(filterItem.Value))
                    {
                        foreach (var property in entityType.GetProperties())
                        {
                            var initialDatePrefix = "InitialDate_";
                            var finalDatePrefix = "FinalDate_";

                            if (filterItem.Key.StartsWith(initialDatePrefix))
                            {
                                if (property.Name.ToLower().Equals(filterItem.Key.ToLower().Substring(initialDatePrefix.Length, (filterItem.Key.Length - initialDatePrefix.Length))))
                                {
                                    if (DateTime.TryParse(filterItem.Value, out DateTime initialDate))
                                    {
                                        query = query.Where(w => Convert.ToDateTime(w.GetType().GetProperty(property.Name).GetValue(w, null)) >= initialDate);
                                    }
                                }
                            }

                            if (filterItem.Key.StartsWith(finalDatePrefix))
                            {
                                if (property.Name.ToLower().Equals(filterItem.Key.ToLower().Substring(finalDatePrefix.Length, (filterItem.Key.Length - finalDatePrefix.Length))))
                                {
                                    if (DateTime.TryParse(filterItem.Value, out DateTime finalDate))
                                    {
                                        query = query.Where(w => Convert.ToDateTime(w.GetType().GetProperty(property.Name).GetValue(w, null)) <= finalDate);
                                    }
                                }
                            }

                            if (property.Name.ToLower().Equals(filterItem.Key.ToLower()))
                            {
                                var propertyType = property.PropertyType.Name;

                                switch (propertyType)
                                {
                                    case nameof(String):
                                        query = query.Where(w => w.GetType().GetProperty(property.Name).GetValue(w).ToString().ToLower().Contains(filterItem.Value.ToLower()));
                                        break;

                                    case nameof(Boolean):
                                        if (Boolean.TryParse(filterItem.Value, out bool isBoolean))
                                        {
                                            query = query.Where(w => w.GetType().GetProperty(property.Name).GetValue(w, null).Equals(isBoolean));
                                        }
                                        break;

                                    case nameof(Int16):
                                        if (int.TryParse(filterItem.Value, out int isInt16))
                                        {
                                            query = query.Where(w => w.GetType().GetProperty(property.Name).GetValue(w, null).Equals(isInt16));
                                        }
                                        break;

                                    case nameof(Int32):
                                        if (int.TryParse(filterItem.Value, out int isInt32))
                                        {
                                            query = query.Where(w => w.GetType().GetProperty(property.Name).GetValue(w, null).Equals(isInt32));
                                        }
                                        break;

                                    case nameof(Int64):
                                        if (int.TryParse(filterItem.Value, out int isInt64))
                                        {
                                            query = query.Where(w => w.GetType().GetProperty(property.Name).GetValue(w, null).Equals(isInt64));
                                        }
                                        break;

                                    case nameof(DateTime):
                                        if (int.TryParse(filterItem.Value, out int isDateTime))
                                        {
                                            query = query.Where(w => w.GetType().GetProperty(property.Name).GetValue(w, null).Equals(isDateTime));
                                        }
                                        break;

                                    default:
                                        break;
                                }
                            }
                        } 
                    }
                } 
            }
            return query;
        }
    }
}
