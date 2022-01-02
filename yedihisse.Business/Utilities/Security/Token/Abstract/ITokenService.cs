using System.Security.Claims;
using System.Security.Principal;
using yedihisse.Entities.Dtos;

namespace yedihisse.Business.Utilities.Security.Token.Abstract
{
    public interface ITokenService
    {
        string GenerateToken(UserLoggedinDto userLoggedinDto);
        public UserLoggedinDto DecodeToken();
    }
}