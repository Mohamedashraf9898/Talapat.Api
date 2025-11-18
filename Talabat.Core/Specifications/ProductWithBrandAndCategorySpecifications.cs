using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpecifications(string sort ,int? brandId , int? categoryId )
            : base(p => 
                     (!brandId.HasValue || p.BrandId==brandId.Value ) &&
                     (!categoryId.HasValue || p.CategoryId == categoryId.Value)
            )
        {
            if(!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        //OrderBy = p=> p.Price;
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        //OrderByDesc = p => p.Price;
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
            else
            {
                AddOrderBy(p => p.Name);
            }

        }
    }
}
