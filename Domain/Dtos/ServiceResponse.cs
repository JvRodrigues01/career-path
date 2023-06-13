namespace Domain.Dtos
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public ServiceResponse()
        {

        }

        public ServiceResponse(bool success)
        {
            Success = success;
        }

        public ServiceResponse(bool success, T data)
        {
            Success = success;
            Data = data;
        }

        public ServiceResponse(bool success, List<string> errors)
        {
            Success = success;
            Errors = errors;
        }

        public ServiceResponse(bool success, string error)
        {
            Success = success;
            Errors = new()
            {
                error
            };
        }
    }
}
