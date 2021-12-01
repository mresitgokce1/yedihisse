using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;

namespace yedihisse.Business.Abstract
{
    public interface IAddressTypeService
    {
        Task<IDataResult<AddressTypeDto>> Get(int addressTypeId);
        Task<IDataResult<AddressTypeListDto>> GetAll();
        Task<IDataResult<AddressTypeListDto>> GetAllByNonDeleted();
        Task<IDataResult<AddressTypeListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<AddressTypeDto>> Add(AddressTypeAddDto addressTypeAddDto, int createdByUserId);
        Task<IDataResult<AddressTypeUpdateDto>> GetAddressTypeDto(int addressTypeId);
        Task<IDataResult<AddressTypeDto>> Update(AddressTypeUpdateDto addressTypeUpdateDto, int modifiedByUserId);
        Task<IResult> Delete(int addressTypeId, int modifiedByUserId);
        Task<IResult> HardDelete(int addressTypeId);
        Task<IDataResult<int>> Count();
        Task<IDataResult<int>> CountByIsNonDeleted();
    }
}
