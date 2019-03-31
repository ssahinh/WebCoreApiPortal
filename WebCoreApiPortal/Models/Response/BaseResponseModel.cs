namespace WebCoreApiPortal.Models.Response
{
    public class BaseResponseModel<T>
    {
        public string code { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
