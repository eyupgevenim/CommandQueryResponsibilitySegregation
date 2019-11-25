namespace CommandQueryResponsibilitySegregation.Infrastructure.Query
{
    public interface IQueryInvoker
    {
        IResult Query(IQuery query);
    }
}
