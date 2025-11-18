using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talapat.Repository
{
    internal class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery , ISpecifications<TEntity> spec)
        {
             var query = inputQuery; // dbContext.Set<TEntity>()

            if(spec.Criteria is not null) // E=>E.ID==1
                query = query.Where(spec.Criteria);
            if(spec.OrderBy is not null)
                query = query.OrderBy(spec.OrderBy);
           else if (spec.OrderByDesc is not null)
                query = query.OrderByDescending(spec.OrderByDesc);
            
                return query;
        }
    }
}
