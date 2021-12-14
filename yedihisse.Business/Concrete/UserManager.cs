using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Business.Abstract;
using yedihisse.Business.Utilities;
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

        public UserManager(IUnitOfWork unitOfWork, IMapper mapper)
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

                return new DataResult<UserDto>(ResultStatus.Error, Messages.User.NotFound(false), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserDto>(ResultStatus.Error, Messages.ExceptionMessage.Get("User"), null, exMessage);
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

                return new DataResult<UserListDto>(ResultStatus.Error, Messages.User.NotFound(true), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserListDto>(ResultStatus.Error, Messages.ExceptionMessage.Get("User"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserListDto>> GetAllByNonDeletedAsync()
        {
            try
            {
                var users = await _unitOfWork.Users.GetAllAsync(u=>u.IsDeleted == false);

                if (users.Count > -1)
                {
                    return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto
                    {
                        Users = _mapper.Map<IList<UserDto>>(users)
                    });
                }

                return new DataResult<UserListDto>(ResultStatus.Error, Messages.User.NotFound(true), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserListDto>(ResultStatus.Error, Messages.ExceptionMessage.Get("User"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            try
            {
                var users = await _unitOfWork.Users.GetAllAsync(u => u.IsDeleted == false && u.IsActive == true);

                if (users.Count > -1)
                {
                    return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto
                    {
                        Users = _mapper.Map<IList<UserDto>>(users)
                    });
                }

                return new DataResult<UserListDto>(ResultStatus.Error, Messages.User.NotFound(true), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserListDto>(ResultStatus.Error, Messages.ExceptionMessage.Get("User"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserDto>> AddAsync(UserAddDto userAddDto, int createdByUserId)
        {
            try
            {
                var user = _mapper.Map<User>(userAddDto);
                user.CreatedByUserId = createdByUserId;
                user.ModifiedByUserId = createdByUserId;
                user.PasswordHash = Cryptolog.CreateHashPassword(userAddDto.PasswordHash);

                var addedUser = await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveAsync();

                return new DataResult<UserDto>(ResultStatus.Success, Messages.User.Add(addedUser.FirstName + " " + addedUser.LastName), _mapper.Map<UserDto>(addedUser));
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserDto>(ResultStatus.Success, Messages.ExceptionMessage.Add("User"), null, exMessage);
            }
        }

        public async Task<IDataResult<UserUpdateDto>> GetUserUpdateDtoAsync(int userId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetAsync(u => u.Id == userId);

                if (user != null)
                    return new DataResult<UserUpdateDto>(ResultStatus.Success, _mapper.Map<UserUpdateDto>(user));
                return new DataResult<UserUpdateDto>(ResultStatus.Success, Messages.User.NotFound(false), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserUpdateDto>(ResultStatus.Error, Messages.ExceptionMessage.Update("User"), null,
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
                    var updatedUser = await _unitOfWork.Users.UpdateAsync(user);
                    await _unitOfWork.SaveAsync();
                    return new DataResult<UserDto>(ResultStatus.Success, Messages.User.Update(updatedUser.FirstName + " " + updatedUser.LastName), _mapper.Map<UserDto>(updatedUser));
                }

                return new DataResult<UserDto>(ResultStatus.Error, Messages.User.NotFound(false), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<UserDto>(ResultStatus.Error, Messages.ExceptionMessage.Get("User"), null, exMessage);
            }
            
        }

        public async Task<IResult> DeleteAsync(int userId, int modifiedByUserId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetAsync(u => u.Id == userId);

                if (user != null)
                {
                    user.IsDeleted = true;
                    user.ModifiedByUserId = modifiedByUserId;
                    user.ModifiedDate = DateTime.Now;
                    await _unitOfWork.Users.UpdateAsync(user);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, Messages.Address.Delete(user.FirstName + " " + user.LastName, false));
                }

                return new Result(ResultStatus.Error, Messages.User.NotFound(false));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Error, Messages.ExceptionMessage.Delete("User"), exMessage);
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

                    return new Result(ResultStatus.Success, Messages.User.Delete(user.FirstName + " " + user.LastName, true));
                }

                return new Result(ResultStatus.Error, Messages.User.NotFound(false));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Error, Messages.ExceptionMessage.HardDelete("User"), exMessage);
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

                return new DataResult<int>(ResultStatus.Error, Messages.User.Count("User"), -1);
            }
            catch (Exception exMessage)
            {
                return new DataResult<int>(ResultStatus.Error, Messages.ExceptionMessage.Count("User"), -1, exMessage);
            }
        }

        public async Task<IDataResult<int>> CountByIsNonDeletedAsync()
        {
            try
            {
                var userCount = await _unitOfWork.Users.CountAsync(a => !a.IsDeleted);

                if (userCount > -1)
                {
                    return new DataResult<int>(ResultStatus.Success, userCount);
                }

                return new DataResult<int>(ResultStatus.Error, Messages.User.Count("User"), -1);
            }
            catch (Exception exMessage)
            {
                return new DataResult<int>(ResultStatus.Error, Messages.ExceptionMessage.Count("User"), -1, exMessage);
            }
        }
    }
}
