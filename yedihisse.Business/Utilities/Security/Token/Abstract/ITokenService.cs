using yedihisse.Entities.Dtos;

namespace yedihisse.Business.Utilities.Security.Token.Abstract
{
    public interface ITokenService
    {
        string GenerateToken(UserLoggedinDto userLoggedinDto);
    }
}