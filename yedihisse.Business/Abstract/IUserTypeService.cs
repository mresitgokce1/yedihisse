using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;

namespace yedihisse.Business.Abstract
{
    public interface IUserTypeService
    {
        Task<IDataResult<UserTypeDto>> GetAsync(int userTypeId);
        Task<IDataResult<UserTypeListDto>> GetAllAsync();
        Task<IDataResult<UserTypeDto>> AddAsync(UserTypeAddDto userTypeAddDto, int createdByUserId);
        Task<IDataResult<UserTypeUpdateDto>> GetDetailAsync(int userTypeId);
        Task<IDataResult<UserTypeDto>> UpdateAsync(UserTypeUpdateDto userTypeUpdateDto, int modifiedByUserId);
        Task<IResult> DeleteAsync(int userTypeId, int modifiedByUserId);
        Task<IResult> HardDeleteAsync(int userTypeId);
        Task<IDataResult<int>> CountAsync();
    }
}
