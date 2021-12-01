using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;

namespace yedihisse.Business.Abstract
{
    public interface IAllotmentJoinCarService
    {
        Task<IDataResult<AllotmentJoinCarDto>> Get(int allotmentJoinCarId);
        Task<IDataResult<AllotmentJoinCarListDto>> GetAll(int? carId, int? allotmentId);
        Task<IDataResult<AllotmentJoinCarListDto>> GetAllByNonDeleted(int? carId, int? allotmentId);
        Task<IDataResult<AllotmentJoinCarListDto>> GetAllByNonDeletedAndActive(int? carId, int? allotmentId);

        Task<IDataResult<AllotmentJoinCarDto>> GetByCarId(int carId);
        Task<IDataResult<AllotmentJoinCarListDto>> GetAllCarId(int carId);
        Task<IDataResult<AllotmentJoinCarListDto>> GetAllByCarIdAndNonDeleted(int carId);
        Task<IDataResult<AllotmentJoinCarListDto>> GetAllByCarIdAndNonDeletedAndActive(int carId);

        Task<IDataResult<AllotmentJoinCarDto>> GetByAllotmentId(int allotmentId);
        Task<IDataResult<AllotmentJoinCarListDto>> GetAllAllotmentId(int allotmentId);
        Task<IDataResult<AllotmentJoinCarListDto>> GetAllByAllotmentIdAndNonDeleted(int allotmentId);
        Task<IDataResult<AllotmentJoinCarListDto>> GetAllByAllotmentIdAndNonDeletedAndActive(int allotmentId);

        Task<IDataResult<AllotmentJoinCarDto>> Add(AllotmentJoinCarAddDto allotmentJoinCarAddDto, int createdUserById);
        Task<IDataResult<AllotmentJoinCarUpdateDto>> GetAllotmentJoinCarUpdateDto(int allotmentJoinCarId);
        Task<IDataResult<AllotmentJoinCarDto>> Update(AllotmentJoinCarUpdateDto allotmentJoinCarUpdateDto, int modifiedUserById);
        Task<IResult> Delete(int allotmentJoinCarId, int modifiedUserById);
        Task<IResult> HardDelete(int allotmentJoinCarId);
        Task<IDataResult<int>> Count();
        Task<IDataResult<int>> CountByCarId();
        Task<IDataResult<int>> CountByAllotmentId();
        Task<IDataResult<int>> CountByNonDeleted();
        Task<IDataResult<int>> CountByCarIdAndNonDeleted();
        Task<IDataResult<int>> CountByAllotmentIdAndNonDeleted();
    }
}
