using System;

namespace delete.DTO
{
    public enum ResponseType
    {
        Success,
        NotFound,
        ServerError
    }

    public class ServiceResponse
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public ResponseType Type { get; set; }
        public bool Success => Type == ResponseType.Success;
    }

    public class ServiceDataResponse<T> : ServiceResponse where T: class
    {
        public T Data { get; set; }
    }
}
