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
using yedihisse.Entities.Dtos.AddressDto;
using yedihisse.Shared.Utilities.Results.Abstratct;
using yedihisse.Shared.Utilities.Results.Complex_Type;
using yedihisse.Shared.Utilities.Results.Concrete;

namespace yedihisse.Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<AddressDto>> Get(int addressId)
        {
            var address = await _unitOfWork.Addresses.GetAsync(a => a.Id == addressId);

            if (address != null)
            {
                return new DataResult<AddressDto>(ResultStatus.Success, new AddressDto
                {
                    Address = address,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<AddressDto>(ResultStatus.Error, Messages.Address.NotFound(false), null);
        }

        public async Task<IDataResult<AddressUpdateDto>> GetAddressUpdateDto(int addressId)
        {
            var address = await _unitOfWork.Addresses.GetAsync(a => a.Id == addressId);

            if (address != null)
            {
                var addressUpdateDto = _mapper.Map<AddressUpdateDto>(address);

                return new DataResult<AddressUpdateDto>(ResultStatus.Success, addressUpdateDto);
            }

            return new DataResult<AddressUpdateDto>(ResultStatus.Error,Messages.Address.NotFound(false) ,null);
        }

        public async Task<IDataResult<AddressListDto>> GetAll()
        {
            var addresses = await _unitOfWork.Addresses.GetAllAsync();

            if (addresses.Count > -1)
            {
                return new DataResult<AddressListDto>(ResultStatus.Success, new AddressListDto
                {
                    Addresses = addresses,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<AddressListDto>(ResultStatus.Error, Messages.Address.NotFound(true), null);
        }

        public async Task<IDataResult<AddressListDto>> GetAllByNonDeleted()
        {
            var addresses = await _unitOfWork.Addresses.GetAllAsync(a => !a.IsDeleted);

            if (addresses.Count > -1)
            {
                return new DataResult<AddressListDto>(ResultStatus.Success, new AddressListDto
                {
                    Addresses = addresses,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<AddressListDto>(ResultStatus.Error, Messages.Address.NotFound(true), null);
        }

        public async Task<IDataResult<AddressListDto>> GetAllByNonDeletedAndActive()
        {
            var addresses = await _unitOfWork.Addresses.GetAllAsync(a => !a.IsDeleted && a.IsActive == true);

            if (addresses.Count > -1)
            {
                return new DataResult<AddressListDto>(ResultStatus.Success, new AddressListDto
                {
                    Addresses = addresses,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<AddressListDto>(ResultStatus.Error, Messages.Address.NotFound(true), null);
        }

        public async Task<IDataResult<AddressListDto>> GetAllByType(int addressTypeId)
        {
            var addressType = await _unitOfWork.AddressTypes.AnyAsync(a => a.Id == addressTypeId);

            if (addressType)
            {
                var addresses = await _unitOfWork.Addresses.GetAllAsync(a => !a.IsDeleted && a.IsActive == true && a.AddressTypeId == addressTypeId);

                if (addresses.Count > -1)
                {
                    return new DataResult<AddressListDto>(ResultStatus.Success, new AddressListDto
                    {
                        Addresses = addresses,
                        ResultStatus = ResultStatus.Success
                    });
                }

                return new DataResult<AddressListDto>(ResultStatus.Error, Messages.Address.NotFound(true), null);
            }

            return new DataResult<AddressListDto>(ResultStatus.Error, Messages.Address.NotFoundType(), null);
        }

        public async Task<IDataResult<AddressDto>> Add(AddressAddDto addressAddDto, int createdByUserId)
        {
            var address = _mapper.Map<Address>(addressAddDto);
            address.CreatedByUserId = createdByUserId;

            var addedAddress = await _unitOfWork.Addresses.AddAsync(address);
            await _unitOfWork.SaveAsync();

            return new DataResult<AddressDto>(ResultStatus.Success, Messages.Address.Add(addedAddress.AddressName), new AddressDto
            {
                Address = addedAddress,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Address.Add(addedAddress.AddressName)
            });
        }

        public async Task<IDataResult<AddressDto>> Update(AddressUpdateDto addressUpdateDto, int modifiedByUserId)
        {
            var oldAddress = await _unitOfWork.Addresses.GetAsync(a => a.Id == addressUpdateDto.Id);

            if (oldAddress != null)
            {
                var address = _mapper.Map<AddressUpdateDto, Address>(addressUpdateDto, oldAddress);
                address.ModifiedByUserId = modifiedByUserId;
                var updatedAddress = await _unitOfWork.Addresses.UpdateAsync(address);
                await _unitOfWork.SaveAsync();

                return new DataResult<AddressDto>(ResultStatus.Success, Messages.Address.Update(updatedAddress.AddressName), new AddressDto
                {
                    Address = updatedAddress,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Address.Update(updatedAddress.AddressName)
                });
            }

            return new DataResult<AddressDto>(ResultStatus.Success, Messages.Address.NotFound(false), null);
        }

        public async Task<IResult> Delete(int addressId, int modifiedByUserId)
        {
            var address = await _unitOfWork.Addresses.GetAsync(a => a.Id == addressId);

            if (address != null)
            {
                address.IsDeleted = true;
                address.ModifiedByUserId = modifiedByUserId;
                address.ModifiedDate = DateTime.Now;

                await _unitOfWork.Addresses.UpdateAsync(address);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, Messages.Address.Delete(address.AddressName, false));
            }
            return new Result(ResultStatus.Error, Messages.Address.NotFound(false));
        }

        public async Task<IResult> HardDelete(int addressId)
        {
            var address = await _unitOfWork.Addresses.GetAsync(a => a.Id == addressId);

            if (address != null)
            {
                await _unitOfWork.Addresses.DeleteAsync(address);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, Messages.Address.Delete(address.AddressName, true));
            }
            return new Result(ResultStatus.Error, Messages.Address.NotFound(false));
        }

        public async Task<IDataResult<int>> Count()
        {
            var addressCount = await _unitOfWork.Addresses.CountAsync();

            if (addressCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, addressCount);
            }
            
            return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
        }

        public async Task<IDataResult<int>> CountByIsNonDeleted()
        {
            var addressCount = await _unitOfWork.Addresses.CountAsync(a => !a.IsDeleted);

            if (addressCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, addressCount);
            }

            return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
        }
    }
}
