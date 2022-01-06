using System.Threading.Tasks;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;

namespace yedihisse.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserDto>> GetAsync(int userId);
        Task<IDataResult<UserListDto>> GetAllAsync();
        Task<IDataResult<UserDto>> AddAsync(UserAddDto userAddDto, int createdByUserId);
        Task<IDataResult<UserUpdateDto>> GetUpdateDtoAsync(int userId);
        Task<IDataResult<UserDto>> UpdateAsync(UserUpdateDto userUpdateDto, int modifiedByUserId);
        Task<IResult> DeleteAsync(int userId, int modifiedByUserId);
        Task<IResult> HardDeleteAsync(int userId);
        Task<IDataResult<int>> CountAsync();
    }
}
