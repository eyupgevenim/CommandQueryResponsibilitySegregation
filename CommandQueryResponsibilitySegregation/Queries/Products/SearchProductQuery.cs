using CommandQueryResponsibilitySegregation.Infrastructure.Query;

namespace CommandQueryResponsibilitySegregation.Queries.Products
{
    public class SearchProductQuery : IQuery
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
