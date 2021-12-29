namespace yedihisse.Shared.Utilities.Security.Token.Abstract
{
    public interface ITokenService
    {
        AccessToken CreateToken(int userId, string userName);
    }
}
