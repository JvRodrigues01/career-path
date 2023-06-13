namespace Domain.Dtos
{
    public class PagedResponse<T> : BaseResponse
    {
        public IEnumerable<T> Result { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
    }
}
