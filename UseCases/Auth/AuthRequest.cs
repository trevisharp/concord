namespace Concord.UseCases.Auth;

public record AuthRequest(
    string Login,
    string Password
);