namespace VendingMachine.Business.Exceptions
{
    public class IdException : Exception
    {
        public IdException()
        {
        }
        public IdException(string message)
            : base(message)
        {
        }
    }
}
