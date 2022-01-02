using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Business.Utilities.Security.Token;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;

namespace yedihisse.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserDto>> GetAsync(int userId, bool? isActive = null, bool? isDeleted = null);
        Task<IDataResult<UserListDto>> GetAllAsync(bool? isActive = null, bool? isDeleted = null);
        Task<IDataResult<UserDto>> AddAsync(UserAddDto userAddDto, int createdByUserId);
        Task<IDataResult<UserUpdateDto>> GetUpdateDtoAsync(int userId);
        Task<IDataResult<UserDto>> UpdateAsync(UserUpdateDto userUpdateDto, int modifiedByUserId);
        Task<IResult> DeleteAsync(int userId, int modifiedByUserId);
        Task<IResult> HardDeleteAsync(int userId);
        Task<IDataResult<int>> CountAsync(bool? isActive = null, bool? isDeleted = null);
        Task<IDataResult<string>> Authenticate(UserLoginDto userLoginDto);
    }
}
