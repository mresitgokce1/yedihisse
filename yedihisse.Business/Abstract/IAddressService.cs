using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.AddressDto;
using yedihisse.Shared.Utilities.Results.Abstratct;

namespace yedihisse.Business.Abstract
{
    public interface IAddressService
    {
        Task<IDataResult<AddressDto>> Get(int addressId);
        Task<IDataResult<AddressUpdateDto>> GetAddressUpdateDto(int addressId);
        Task<IDataResult<AddressListDto>> GetAll();
        Task<IDataResult<AddressListDto>> GetAllByNonDeleted();
        Task<IDataResult<AddressListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<AddressListDto>> GetAllByType(int addressTypeId);
        Task<IDataResult<AddressDto>> Add(AddressAddDto addressAddDto, int createdByUserId);
        Task<IDataResult<AddressDto>> Update(AddressUpdateDto addressUpdateDto, int modifiedByUserId);
        Task<IResult> Delete(int addressId, int modifiedByUserId);
        Task<IResult> HardDelete(int addressId);
        Task<IDataResult<int>> Count();
        Task<IDataResult<int>> CountByIsNonDeleted();
    }
}
