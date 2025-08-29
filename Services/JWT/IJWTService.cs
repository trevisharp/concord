using Concord.Models;

namespace Concord.Services.JWT;

public interface IJWTService
{
    string CreateToken(ProfileToAuth data);
}