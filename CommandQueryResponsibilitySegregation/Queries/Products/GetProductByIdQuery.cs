using CommandQueryResponsibilitySegregation.Infrastructure.Query;

namespace CommandQueryResponsibilitySegregation.Queries.Products
{
    public class GetProductByIdQuery: IQuery
    {
        public int Id { get; set; }
    }
}
