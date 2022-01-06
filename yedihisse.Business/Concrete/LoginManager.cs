using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using yedihisse.Business.Abstract;
using yedihisse.Business.Utilities;
using yedihisse.Business.Utilities.Security.Token.Abstract;
using yedihisse.DataAccess.Abstract;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;
using yedihisse.Shared.Utilities.Results.Complex_Type;
using yedihisse.Shared.Utilities.Results.Concrete;

namespace yedihisse.Business.Concrete
{
    public class LoginManager : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public LoginManager(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<IDataResult<string>> Authenticate(UserLoginDto userLoginDto)
        {
            try
            {
                var user = await _unitOfWork.Users.GetAsync(
                    u => u.UserPhoneNumber == userLoginDto.UserName,
                    u => u
                        .Include(x => x.UserJoinTypes)
                        .ThenInclude(y => y.UserType));

                if (user == null)
                    return new DataResult<string>(ResultStatus.Error, Messages.AuthMessage.ErrorUserName(), null, null);

                if (!Shared.Utilities.Encrytpions.PasswordEncryption.VerifyHashPassword(user.PasswordHash, userLoginDto.Password))
                    return new DataResult<string>(ResultStatus.Error, Messages.AuthMessage.ErrorPassword(), null, null);

                var userLoggedinDto = new UserLoggedinDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmailAddress = user.EmailAddress,
                    UserPhoneNumber = user.UserPhoneNumber,
                    UserJoinTypes = user.UserJoinTypes
                };

                return new DataResult<string>(ResultStatus.Success, Messages.AuthMessage.LoginSuccess(), _tokenService.GenerateToken(userLoggedinDto), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<string>(ResultStatus.Danger, Messages.ExceptionMessage.Auth(), null, exMessage);
            }
        }
    }
}
