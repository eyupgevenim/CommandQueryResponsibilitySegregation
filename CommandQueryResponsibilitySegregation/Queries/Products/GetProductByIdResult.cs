using CommandQueryResponsibilitySegregation.Infrastructure.Query;

namespace CommandQueryResponsibilitySegregation.Queries.Products
{
    public class GetProductByIdResult: IResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
