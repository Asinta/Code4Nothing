namespace Code4Nothing.Api.Exceptions;

public record ApiException(int StatusCode, string Message = null, string Details = null);
