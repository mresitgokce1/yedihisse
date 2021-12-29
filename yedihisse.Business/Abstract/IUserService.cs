using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;
using yedihisse.Shared.Utilities.Security.Token;

namespace yedihisse.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserDto>> GetAsync(int userId);
        Task<IDataResult<UserListDto>> GetAllAsync();
        Task<IDataResult<UserListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<UserListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IDataResult<UserDto>> AddAsync(UserAddDto userAddDto, int createdByUserId);
        Task<IDataResult<UserUpdateDto>> GetUserUpdateDtoAsync(int userId);
        Task<IDataResult<UserDto>> UpdateAsync(UserUpdateDto userUpdateDto, int modifiedByUserId);
        Task<IResult> DeleteAsync(int userId, int modifiedByUserId);
        Task<IResult> HardDeleteAsync(int userId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByIsNonDeletedAsync();
        Task<IDataResult<AccessToken>> Authenticate(UserLoginDto userLoginDto);
    }
}
