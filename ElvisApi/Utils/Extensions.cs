using System;
using System.Collections.Generic;
using System.Linq;
using ElvisApi.Database.Entities;
using ElvisApi.Models;

namespace ElvisApi.Utils
{
 
        public static class Extensions
        {

     
            public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                int page, int pageSize) where T : class
            {
                var result = new PagedResult<T> { CurrentPage = page, PageSize = pageSize, RowCount = query.Count() };


                var pageCount = (double)result.RowCount / pageSize;
                result.PageCount = (int)Math.Ceiling(pageCount);

                var skip = (page - 1) * pageSize;
                result.Results = query.Skip(skip).Take(pageSize).ToList();

                return result;
            }

            public static PagedResult<T> GetPaged<T>(this IEnumerable<T> query,
                int page, int pageSize) where T : class
            {
                var result = new PagedResult<T> { CurrentPage = page, PageSize = pageSize, RowCount = query.Count() };


                var pageCount = (double)result.RowCount / pageSize;
                result.PageCount = (int)Math.Ceiling(pageCount);

                var skip = (page - 1) * pageSize;
                result.Results = query.Skip(skip).Take(pageSize).ToList();

                return result;
            }

            public static IQueryable<Statement> GridFilter<T>(this IQueryable<Statement> query, Statement filter) where T : class
            {
             

                if (!string.IsNullOrEmpty(filter.Title))
                {
                    query = query.Where(i => i.Title == filter.Title);
                }

                  return query;
            }

        
        }

    }