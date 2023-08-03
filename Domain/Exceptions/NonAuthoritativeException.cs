namespace Domain.Exceptions
{
    public class NonAuthoritativeException : Exception
    {
        public NonAuthoritativeException() : base(ErrorMessages.Unable_Login)
        {
        }

        public NonAuthoritativeException(string message) : base(message)
        {
        }
    }
}
