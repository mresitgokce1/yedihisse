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
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;
using yedihisse.Shared.Utilities.Results.Complex_Type;
using yedihisse.Shared.Utilities.Results.Concrete;

namespace yedihisse.Business.Concrete
{
    public class AnimalTypeManager : IAnimalTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AnimalTypeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<AnimalTypeDto>> AddAsync(AnimalTypeAddDto animalTypeAddDto, int createdUserById)
        {
            try
            {
                var animalType = _mapper.Map<AnimalType>(animalTypeAddDto);
                animalType.CreatedByUserId = createdUserById;
                animalType.ModifiedByUserId = createdUserById;
                var addedAnimalType = await _unitOfWork.AnimalTypes.AddAsync(animalType);
                await _unitOfWork.SaveAsync();

                return new DataResult<AnimalTypeDto>(ResultStatus.Success, Messages.CommonMessage.Add(addedAnimalType.AnimalTypeName, "Hayvan Tipi"), _mapper.Map<AnimalTypeDto>(addedAnimalType));
            }
            catch (Exception exMessage)
            {
                return new DataResult<AnimalTypeDto>(ResultStatus.Danger, Messages.ExceptionMessage.Add("Hayvan Tipi"), null, exMessage);
            }
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            try
            {
                var animalTypeCount = await _unitOfWork.AnimalTypes.CountAsync();

                if (animalTypeCount > -1)
                {
                    return new DataResult<int>(ResultStatus.Success, animalTypeCount);
                }

                return new DataResult<int>(ResultStatus.Error, Messages.CommonMessage.Count("Hayvan Tipi"), -1);
            }
            catch (Exception exMessage)
            {
                return new DataResult<int>(ResultStatus.Danger, Messages.ExceptionMessage.Count("Hayvan Tipi"), -1, exMessage);
            }
        }

        public async Task<IResult> DeleteAsync(int animalTypeId, int modifiedByUserId)
        {
            try
            {
                var animalType = await _unitOfWork.AnimalTypes.GetAsync(u => u.Id == animalTypeId);

                if (animalType != null)
                {
                    if (animalType.IsDeleted)
                        return new Result(ResultStatus.Info, Messages.CommonMessage.AlreadyDeleted(animalType.AnimalTypeName, "Hayvan Tipi"));

                    animalType.IsDeleted = true;
                    animalType.ModifiedByUserId = modifiedByUserId;
                    animalType.ModifiedDate = DateTime.Now;
                    await _unitOfWork.AnimalTypes.UpdateAsync(animalType);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, Messages.CommonMessage.Delete(animalType.AnimalTypeName, false, "Hayvan Tipi"));
                }

                return new Result(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Hayvan Tipi"));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Danger, Messages.ExceptionMessage.Delete("Hayvan Tipi"), exMessage);
            }
        }

        public async Task<IDataResult<AnimalTypeListDto>> GetAllAsync()
        {
            try
            {
                var animalType = await _unitOfWork.AnimalTypes.GetAllAsync();

                if (animalType.Count > -1)
                {
                    return new DataResult<AnimalTypeListDto>(ResultStatus.Success, new AnimalTypeListDto
                    {
                        AnimalTypes = _mapper.Map<IList<AnimalTypeDto>>(animalType)
                    });
                }

                return new DataResult<AnimalTypeListDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(true, "Hayvan Tipi"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AnimalTypeListDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Hayvan Tipi"), null, exMessage);
            }
        }

        public async Task<IDataResult<AnimalTypeDto>> GetAsync(int animalTypeId)
        {
            try
            {
                var animalType = await _unitOfWork.AnimalTypes.GetAsync(u => u.Id == animalTypeId);

                if (animalType != null)
                    return new DataResult<AnimalTypeDto>(ResultStatus.Success, _mapper.Map<AnimalTypeDto>(animalType));

                return new DataResult<AnimalTypeDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Hayvan Tipi"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AnimalTypeDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Hayvan Tipi"), null, exMessage);
            }
        }

        public async Task<IDataResult<AnimalTypeUpdateDto>> GetDetailAsync(int animalTypeId)
        {
            try
            {
                var animalType = await _unitOfWork.AnimalTypes.GetAsync(u => u.Id == animalTypeId);

                if (animalType != null)
                    return new DataResult<AnimalTypeUpdateDto>(ResultStatus.Success, _mapper.Map<AnimalTypeUpdateDto>(animalType));

                return new DataResult<AnimalTypeUpdateDto>(ResultStatus.Success, Messages.CommonMessage.NotFound(false, "Hayvan Tipi"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AnimalTypeUpdateDto>(ResultStatus.Danger, Messages.ExceptionMessage.Update("Hayvan Tipi"), null,
                    exMessage);
            }
        }

        public async Task<IResult> HardDeleteAsync(int animalTypeId)
        {
            try
            {
                var animalType = await _unitOfWork.AnimalTypes.GetAsync(u => u.Id == animalTypeId);

                if (animalType != null)
                {
                    await _unitOfWork.AnimalTypes.DeleteAsync(animalType);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, Messages.CommonMessage.Delete(animalType.AnimalTypeName, true, "Hayvan Tipi"));
                }

                return new Result(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Hayvan Tipi"));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Danger, Messages.ExceptionMessage.HardDelete("Hayvan Tipi"), exMessage);
            }
        }

        public async Task<IDataResult<AnimalTypeDto>> UpdateAsync(AnimalTypeUpdateDto animalTypeUpdateDto, int modifiedByUserId)
        {
            try
            {
                var oldAnimalType = await _unitOfWork.AnimalTypes.GetAsync(u => u.Id == animalTypeUpdateDto.Id);

                if (oldAnimalType != null)
                {
                    var animalType = _mapper.Map<AnimalTypeUpdateDto, AnimalType>(animalTypeUpdateDto, oldAnimalType);
                    animalType.ModifiedByUserId = modifiedByUserId;
                    var updatedAnimalType = await _unitOfWork.AnimalTypes.UpdateAsync(animalType);
                    await _unitOfWork.SaveAsync();
                    return new DataResult<AnimalTypeDto>(ResultStatus.Success, Messages.CommonMessage.Update(updatedAnimalType.AnimalTypeName, "Hayvan Tipi"), _mapper.Map<AnimalTypeDto>(updatedAnimalType));
                }

                return new DataResult<AnimalTypeDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Hayvan Tipi"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AnimalTypeDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Hayvan Tipi"), null, exMessage);
            }
        }
    }
}
