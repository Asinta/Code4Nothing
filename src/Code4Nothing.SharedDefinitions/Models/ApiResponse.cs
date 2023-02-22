namespace Code4Nothing.SharedDefinitions.Models;

public class ApiResponse<T> where T: class
{
    public T Data { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    
    public static ApiResponse<T> Fail(string errorMessage) => new() { Succeeded = false, Message = errorMessage };
    public static ApiResponse<T> Success(T data) => new() { Succeeded = true, Data = data };
    
    public string ToJsonString() => JsonSerializer.Serialize(this);
}
