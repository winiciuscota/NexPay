using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace NexPay.Data.Extensions
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">query object</param>
        /// <param name="page">Initial page</param>
        /// <param name="pageSize">Size of watch page</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int page, int pageSize)
        {
            if (pageSize <= 0)
                pageSize = 10;

            return query.Skip(page * pageSize).Take(pageSize);
        }


    }

}