namespace Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base(ErrorMessages.Bad_Request)
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }
    }
}
