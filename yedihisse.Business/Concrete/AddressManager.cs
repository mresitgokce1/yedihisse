using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Business.Abstract;
using yedihisse.Business.Utilities;
using yedihisse.DataAccess.Abstract;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos;
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
            try
            {
                var address = await _unitOfWork.Addresses.GetAsync(a => a.Id == addressId, a=>a.AddressType);

                if (address != null)
                {
                    return new DataResult<AddressDto>(ResultStatus.Success, _mapper.Map<AddressDto>(address));
                }

                return new DataResult<AddressDto>(ResultStatus.Error, Messages.Address.NotFound(false), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AddressDto>(ResultStatus.Error, Messages.ExceptionMessage.Get("Adres"), null, exMessage);
            }
        }

        public async Task<IDataResult<AddressUpdateDto>> GetAddressUpdateDto(int addressId)
        {
            try
            {
                var address = await _unitOfWork.Addresses.GetAsync(a => a.Id == addressId);

                if (address != null)
                    return new DataResult<AddressUpdateDto>(ResultStatus.Success, _mapper.Map<AddressUpdateDto>(address));

                return new DataResult<AddressUpdateDto>(ResultStatus.Error,Messages.Address.NotFound(false) ,null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AddressUpdateDto>(ResultStatus.Error, Messages.ExceptionMessage.Get("Adres"), null, exMessage);
            }
        }

        public async Task<IDataResult<AddressListDto>> GetAll()
        {
            try
            {
                var addresses = await _unitOfWork.Addresses.GetAllAsync();

                if (addresses.Count > -1)
                {
                    return new DataResult<AddressListDto>(ResultStatus.Success, new AddressListDto
                    {
                        Addresses = _mapper.Map<IList<AddressDto>>(addresses)
                });
                }

                return new DataResult<AddressListDto>(ResultStatus.Error, Messages.Address.NotFound(true), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AddressListDto>(ResultStatus.Error, Messages.ExceptionMessage.List("Adres"), null, exMessage);
            }
        }

        public async Task<IDataResult<AddressListDto>> GetAllByNonDeleted()
        {
            try
            {
                var addresses = await _unitOfWork.Addresses.GetAllAsync(a => !a.IsDeleted);

                if (addresses.Count > -1)
                {
                    return new DataResult<AddressListDto>(ResultStatus.Success, new AddressListDto
                    {
                        Addresses = _mapper.Map<IList<AddressDto>>(addresses)
                    });
                }

                return new DataResult<AddressListDto>(ResultStatus.Error, Messages.Address.NotFound(true), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AddressListDto>(ResultStatus.Error, Messages.ExceptionMessage.List("Adres"), null, exMessage);
            }
        }

        public async Task<IDataResult<AddressListDto>> GetAllByNonDeletedAndActive()
        {
            try
            {
                var addresses = await _unitOfWork.Addresses.GetAllAsync(a => !a.IsDeleted && a.IsActive == true);

                if (addresses.Count > -1)
                {
                    return new DataResult<AddressListDto>(ResultStatus.Success, new AddressListDto
                    {
                        Addresses = _mapper.Map<IList<AddressDto>>(addresses)
                    });
                }

                return new DataResult<AddressListDto>(ResultStatus.Error, Messages.Address.NotFound(true), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AddressListDto>(ResultStatus.Error, Messages.ExceptionMessage.List("Adres"), null, exMessage);
            }
        }

        public async Task<IDataResult<AddressListDto>> GetAllByType(int addressTypeId)
        {
            try
            {
                var addressType = await _unitOfWork.AddressTypes.AnyAsync(a => a.Id == addressTypeId);

                if (addressType)
                {
                    var addresses = await _unitOfWork.Addresses.GetAllAsync(a => !a.IsDeleted && a.IsActive == true && a.AddressTypeId == addressTypeId);

                    if (addresses.Count > -1)
                    {
                        return new DataResult<AddressListDto>(ResultStatus.Success, new AddressListDto
                        {
                            Addresses = _mapper.Map<IList<AddressDto>>(addresses)
                        });
                    }

                    return new DataResult<AddressListDto>(ResultStatus.Error, Messages.Address.NotFound(true), null);
                }

                return new DataResult<AddressListDto>(ResultStatus.Error, Messages.Address.NotFoundType(), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AddressListDto>(ResultStatus.Error, Messages.ExceptionMessage.List("Adres"), null, exMessage);
            }
        }

        public async Task<IDataResult<AddressDto>> Add(AddressAddDto addressAddDto, int createdByUserId)
        {
            try
            {
                var address = _mapper.Map<Address>(addressAddDto);
                address.CreatedByUserId = createdByUserId;

                var addedAddress = await _unitOfWork.Addresses.AddAsync(address);
                await _unitOfWork.SaveAsync();

                return new DataResult<AddressDto>(ResultStatus.Success, Messages.Address.Add(addedAddress.AddressName),_mapper.Map<AddressDto>(addedAddress));
            }
            catch (Exception exMessage)
            {
                return new DataResult<AddressDto>(ResultStatus.Success, Messages.ExceptionMessage.Add("Adres"), null, exMessage);
            }
        }

        public async Task<IDataResult<AddressDto>> Update(AddressUpdateDto addressUpdateDto, int modifiedByUserId)
        {
            try
            {
                var oldAddress = await _unitOfWork.Addresses.GetAsync(a => a.Id == addressUpdateDto.Id);

                if (oldAddress != null)
                {
                    var address = _mapper.Map<AddressUpdateDto, Address>(addressUpdateDto, oldAddress);
                    address.ModifiedByUserId = modifiedByUserId;
                    var updatedAddress = await _unitOfWork.Addresses.UpdateAsync(address);
                    await _unitOfWork.SaveAsync();

                    return new DataResult<AddressDto>(ResultStatus.Success, Messages.Address.Update(updatedAddress.AddressName), _mapper.Map<AddressDto>(address));
                }

                return new DataResult<AddressDto>(ResultStatus.Success, Messages.Address.NotFound(false), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AddressDto>(ResultStatus.Success, Messages.ExceptionMessage.Update("Adres"), null, exMessage);
            }
        }

        public async Task<IResult> Delete(int addressId, int modifiedByUserId)
        {
            try
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
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Error, Messages.ExceptionMessage.Delete("Adres"), exMessage);
            }
        }

        public async Task<IResult> HardDelete(int addressId)
        {
            try
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
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Error, Messages.ExceptionMessage.HardDelete("Adres"), exMessage);
            }
        }

        public async Task<IDataResult<int>> Count()
        {
            try
            {
                var addressCount = await _unitOfWork.Addresses.CountAsync();

                if (addressCount > -1)
                {
                    return new DataResult<int>(ResultStatus.Success, addressCount);
                }

                return new DataResult<int>(ResultStatus.Error, Messages.Address.Count("Adres"), -1);
            }
            catch (Exception exMessage)
            {
                return new DataResult<int>(ResultStatus.Error, Messages.ExceptionMessage.Count("Adres"), -1, exMessage);
            }
        }

        public async Task<IDataResult<int>> CountByIsNonDeleted()
        {
            try
            {
                var addressCount = await _unitOfWork.Addresses.CountAsync(a => !a.IsDeleted);

                if (addressCount > -1)
                {
                    return new DataResult<int>(ResultStatus.Success, addressCount);
                }

                return new DataResult<int>(ResultStatus.Error, Messages.Address.Count("Adres"), -1);
            }
            catch (Exception exMessage)
            {
                return new DataResult<int>(ResultStatus.Error, Messages.ExceptionMessage.Count("Adres"), -1, exMessage);
            }
        }
    }
}
