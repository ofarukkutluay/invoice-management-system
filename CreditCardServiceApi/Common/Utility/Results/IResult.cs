namespace CreditCardServiceApi.Common.Utility.Results
{
    public interface IResult
    {
        public bool Status { get; }
        public int StatusCode { get; }
        public string Message { get; }
    }
}
