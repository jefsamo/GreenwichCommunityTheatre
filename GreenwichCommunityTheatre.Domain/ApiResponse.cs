namespace GreenwichCommunityTheatre.Domain
{
    public class ApiResponse<T>
    {
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public List<string>? Errors { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public ApiResponse(bool isSucceeded, int statusCode, string message, T data, List<string> errors)
        {
            Succeeded = isSucceeded;
            StatusCode = statusCode;
            Message = message;
            Data = data;
            Errors = errors;
        }

        public ApiResponse(bool isSucceeded, int statusCode, string message)
        {
            Succeeded = isSucceeded;
            StatusCode = statusCode;
            Message = message;
        }

        public ApiResponse(bool isSucceeded, T data, List<string> errors)
        {
            Succeeded = isSucceeded;
            Data = data;
            Errors = errors;
        }

        public ApiResponse(T data, string? message = null)
        {
            Succeeded = true;
            Data = data;
            Message = message;
        }
        public ApiResponse(bool succeeded, int statusCode, string? message, List<string>? errors)
        {
            Succeeded = succeeded;
            StatusCode = statusCode;
            Errors = errors;
            Message = message;
        }

        public static ApiResponse<T> Success(string message, int statusCode, T data, bool isSucceeded = true)
        {
            return new ApiResponse<T>(isSucceeded, statusCode, message, data, []);
        }

        public static ApiResponse<T> Failed(List<string> errors, bool isSucceeded = false)
        {
            return new ApiResponse<T>(isSucceeded, default!, errors);
        }

        public static ApiResponse<T> Failed(string message, int statusCode, List<string> errors, bool isSucceeded = false)
        {
            return new ApiResponse<T>(isSucceeded, statusCode, message, errors);
        }
    }
}
