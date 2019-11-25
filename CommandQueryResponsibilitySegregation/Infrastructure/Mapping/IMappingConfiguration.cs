using Microsoft.EntityFrameworkCore;

namespace CommandQueryResponsibilitySegregation.Infrastructure.Mapping
{
    public interface IMappingConfiguration
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
