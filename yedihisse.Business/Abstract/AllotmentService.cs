using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;

namespace yedihisse.Business.Abstract
{
    public interface AllotmentService
    {
        Task<IDataResult<AllotmentDto>> Get(int allotmentId);
        Task<IDataResult<AllotmentListDto>> GetAll();
        Task<IDataResult<AllotmentListDto>> GetAllByNonDeleted();
        Task<IDataResult<AllotmentListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<AllotmentDto>> Add(AllotmentAddDto allotmentAddDto, int createdByUserId);
        Task<IDataResult<AllotmentUpdateDto>> GetAllotmentDto(int allotmentId);
        Task<IDataResult<AllotmentDto>> Update(AllotmentUpdateDto allotmentUpdateDto, int modifiedByUserId);
        Task<IResult> Delete(int allotmentId, int modifiedByUserId);
        Task<IResult> HardDelete(int allotmentId);
        Task<IDataResult<int>> Count();
        Task<IDataResult<int>> CountByIsNonDeleted();
    }
}
