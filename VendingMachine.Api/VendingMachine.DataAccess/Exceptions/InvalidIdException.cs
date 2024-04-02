namespace VendingMachine.DataAccess.Exceptions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException()
        {
        }
        public InvalidIdException(string message)
            : base(message)
        {
        }
    }
}
