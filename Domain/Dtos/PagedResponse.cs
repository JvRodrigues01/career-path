namespace Domain.Dtos
{
    public class SingleResponse<T> : BaseResponse
    {
        public T Result { get; set; }

        public SingleResponse()
        {
        }

        public SingleResponse(T result)
        {
            Result = result;
        }
    }
}
