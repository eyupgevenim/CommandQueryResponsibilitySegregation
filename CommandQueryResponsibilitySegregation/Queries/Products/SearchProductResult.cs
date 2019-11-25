using CommandQueryResponsibilitySegregation.Infrastructure.Entities;
using CommandQueryResponsibilitySegregation.Infrastructure.Query;
using System.Collections.Generic;

namespace CommandQueryResponsibilitySegregation.Queries.Products
{
    public class SearchProductResult : IResult
    {
        public SearchProductResult()
        {
            Products = new List<Product>();
        }

        public List<Product> Products { get; set; }
    }
}
