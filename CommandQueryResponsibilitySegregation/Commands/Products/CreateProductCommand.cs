using CommandQueryResponsibilitySegregation.Infrastructure.Command;

namespace CommandQueryResponsibilitySegregation.Commands.Products
{
    public class CreateProductCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
