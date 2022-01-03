using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;

namespace yedihisse.Business.Abstract
{
    public interface IUserJoinTypeService
    {
        Task<IDataResult<UserJoinTypeDto>> GetAsync(int userJoinTypeId, bool? isActive = null, bool? isDeleted = null);
        Task<IDataResult<UserJoinTypeListDto>> GetAllAsync(bool? isActive = null, bool? isDeleted = null);
        Task<IDataResult<UserJoinTypeDto>> AddAsync(UserJoinTypeAddDto userJoinTypeAddDto, int createdByUserId);
        Task<IDataResult<UserJoinTypeUpdateDto>> GetUpdateDtoAsync(int userJoinTypeId);
        Task<IDataResult<UserJoinTypeDto>> UpdateAsync(UserJoinTypeUpdateDto userJoinTypeUpdateDto, int modifiedByUserId);
        Task<IResult> DeleteAsync(int userJoinTypeId, int modifiedByUserId);
        Task<IResult> HardDeleteAsync(int userJoinTypeId);
    }
}
