using System.Collections.Generic;

namespace WSPro.Backend.Application.Dto
{
    public record LoginInput(string Email, string Password);
    public record LoginPayload(string Token);
    public record InvalidLoginPayload(string ErrorCode, string Message);
    public record MePayload(string Email, string Id, string FirstName, string LastName, int Role);
    public record UserPayload(string Email, string Id, string FirstName, string LastName);
    public record UserInput(string Id);
    public record RegisterInput(string Email, string Password, string FirstName, string LastName,string ConfirmPassword);
    public record RegisterPayload(bool Success);
    public record ErrorMessagePayload(string Type, string Title, int Status,string TraceId, Dictionary<string, string[]> Errors);
}