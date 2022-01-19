namespace CreditCardServiceApi.Applications
{
    public interface ICommandService<VMEntity>
    {
        VMEntity Model { get; set; }
        void Handle();
    }
}
