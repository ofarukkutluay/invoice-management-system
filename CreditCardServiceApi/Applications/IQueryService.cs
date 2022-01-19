namespace CreditCardServiceApi.Applications
{
    public interface IQueryService<VMEntity>
    {
        VMEntity Handle();
        string CompanyId { get; set; }
    }
}
