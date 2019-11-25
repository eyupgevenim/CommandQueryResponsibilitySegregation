using CommandQueryResponsibilitySegregation.Infrastructure.Entities;
using CommandQueryResponsibilitySegregation.Infrastructure.Query;
using CommandQueryResponsibilitySegregation.Infrastructure.Repository;
using System.Linq;

namespace CommandQueryResponsibilitySegregation.Queries.Products
{
    public class ProductQueryHandlers 
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>,
        IQueryHandler<SearchProductQuery, SearchProductResult>
    {
        private readonly IQueryRepository<Product> _queryProductRepository;
        public ProductQueryHandlers(IQueryRepository<Product> queryProductRepository)
        {
            _queryProductRepository = queryProductRepository;
        }

        public GetProductByIdResult Query(GetProductByIdQuery query)
        {
            GetProductByIdResult result = null;

            if (query == null)
                return result;

            var product = _queryProductRepository.GetById(query.Id);
            if (product == null)
                return result;

            result = new GetProductByIdResult
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Stock = product.Stock,
                Price = product.Price
            };

            return result;
        }

        public SearchProductResult Query(SearchProductQuery query)
        {
            var result = new SearchProductResult();
            if (query == null)
                return result;

            var sql = _queryProductRepository.Get();
            if (!string.IsNullOrEmpty(query.Name))
                sql = sql.Where(x => x.Name.Contains(query.Name));
            if (!string.IsNullOrEmpty(query.Description))
                sql = sql.Where(x => x.Description.Contains(query.Description));

            if (sql.Any())
                result.Products = sql.ToList();

            return result;
        }
    }
}
