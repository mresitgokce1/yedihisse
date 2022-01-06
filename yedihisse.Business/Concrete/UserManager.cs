using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Business.Abstract;
using yedihisse.Business.Utilities;
using yedihisse.Business.Utilities.Security.Token.Abstract;
using yedihisse.DataAccess.Abstract;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;
using yedihisse.Shared.Utilities.Results.Complex_Type;
using yedihisse.Shared.Utilities.Results.Concrete;

namespace yedihisse.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserManager(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<UserDto>> GetAsync(int userId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetAsync(u => u.Id == userId);

                if (user != null)
                    return new DataResult<UserDto>(ResultStatus.Success, _mapper.Map<UserDto>(user));

                return new DataResult<UserDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Kullanıcı"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Kullanıcı"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserListDto>> GetAllAsync()
        {
            try
            {
                var users = await _unitOfWork.Users.GetAllAsync();

                if (users.Count > -1)
                {
                    return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto
                    {
                        Users = _mapper.Map<IList<UserDto>>(users)
                    });
                }

                return new DataResult<UserListDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(true, "Kullanıcı"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserListDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Kullanıcı"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserDto>> AddAsync(UserAddDto userAddDto, int createdByUserId)
        {
            try
            {
                var user = _mapper.Map<User>(userAddDto);
                user.CreatedByUserId = createdByUserId;
                user.ModifiedByUserId = createdByUserId;
                user.PasswordHash = Shared.Utilities.Encrytpions.PasswordEncryption.CreateHashPassword(userAddDto.PasswordHash);

                var addedUser = await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveAsync();

                return new DataResult<UserDto>(ResultStatus.Success, Messages.CommonMessage.Add(addedUser.FirstName + " " + addedUser.LastName, "Kullanıcı"), _mapper.Map<UserDto>(addedUser));
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserDto>(ResultStatus.Danger, Messages.ExceptionMessage.Add("Kullanıcı"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserUpdateDto>> GetUpdateDtoAsync(int userId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetAsync(u => u.Id == userId);

                if (user != null)
                    return new DataResult<UserUpdateDto>(ResultStatus.Success, _mapper.Map<UserUpdateDto>(user));

                return new DataResult<UserUpdateDto>(ResultStatus.Success, Messages.CommonMessage.NotFound(false, "Kullanıcı"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserUpdateDto>(ResultStatus.Danger, Messages.ExceptionMessage.Update("Kullanıcı"), null,
                    exMessage);
            }
        }

        public async Task<IDataResult<UserDto>> UpdateAsync(UserUpdateDto userUpdateDto, int modifiedByUserId)
        {
            try
            {
                var oldUser = await _unitOfWork.Users.GetAsync(u => u.Id == userUpdateDto.Id);

                if (oldUser != null)
                {
                    var user = _mapper.Map<UserUpdateDto, User>(userUpdateDto, oldUser);
                    user.ModifiedByUserId = modifiedByUserId;
                    user.PasswordHash = Shared.Utilities.Encrytpions.PasswordEncryption.CreateHashPassword(userUpdateDto.PasswordHash);
                    var updatedUser = await _unitOfWork.Users.UpdateAsync(user);
                    await _unitOfWork.SaveAsync();
                    return new DataResult<UserDto>(ResultStatus.Success, Messages.CommonMessage.Update(updatedUser.FirstName + " " + updatedUser.LastName, "Kullanıcı"), _mapper.Map<UserDto>(updatedUser));
                }

                return new DataResult<UserDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Kullanıcı"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Kullanıcı"), null, exMessage);
            }
        }

        public async Task<IResult> DeleteAsync(int userId, int modifiedByUserId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetAsync(u => u.Id == userId);

                if (user != null)
                {
                    if (user.IsDeleted)
                        return new Result(ResultStatus.Info, Messages.CommonMessage.AlreadyDeleted(user.FirstName + " " + user.LastName, "Kullanıcı"));

                    user.IsDeleted = true;
                    user.ModifiedByUserId = modifiedByUserId;
                    user.ModifiedDate = DateTime.Now;
                    await _unitOfWork.Users.UpdateAsync(user);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, Messages.CommonMessage.Delete(user.FirstName + " " + user.LastName, false, "Kullanıcı"));
                }

                return new Result(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Kullanıcı"));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Danger, Messages.ExceptionMessage.Delete("Kullanıcı"), exMessage);
            }
        }

        public async Task<IResult> HardDeleteAsync(int userId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetAsync(u => u.Id == userId);

                if (user != null)
                {
                    await _unitOfWork.Users.DeleteAsync(user);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, Messages.CommonMessage.Delete(user.FirstName + " " + user.LastName, true, "Kullanıcı"));
                }

                return new Result(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Kullanıcı"));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Danger, Messages.ExceptionMessage.HardDelete("Kullanıcı"), exMessage);
            }
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            try
            {
                var userCount = await _unitOfWork.Users.CountAsync();

                if (userCount > -1)
                {
                    return new DataResult<int>(ResultStatus.Success, userCount);
                }

                return new DataResult<int>(ResultStatus.Error, Messages.CommonMessage.Count("Kullanıcı"), -1);
            }
            catch (Exception exMessage)
            {
                return new DataResult<int>(ResultStatus.Danger, Messages.ExceptionMessage.Count("Kullanıcı"), -1, exMessage);
            }
        }
    }
}
