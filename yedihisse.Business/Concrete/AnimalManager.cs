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
    public class AnimalManager : IAnimalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AnimalManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<AnimalDto>> AddAsync(AnimalAddDto animalAddDto, int createdUserById)
        {
            try
            {
                var animal = _mapper.Map<Animal>(animalAddDto);
                animal.CreatedByUserId = createdUserById;
                animal.ModifiedByUserId = createdUserById;
                var addedAnimal = await _unitOfWork.Animals.AddAsync(animal);
                await _unitOfWork.SaveAsync();

                return new DataResult<AnimalDto>(ResultStatus.Success, Messages.CommonMessage.Add(addedAnimal.Code, "Hayvan"), _mapper.Map<AnimalDto>(addedAnimal));
            }
            catch (Exception exMessage)
            {
                return new DataResult<AnimalDto>(ResultStatus.Danger, Messages.ExceptionMessage.Add("Hayvan"), null, exMessage);
            }
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            try
            {
                var animalCount = await _unitOfWork.Animals.CountAsync();

                if (animalCount > -1)
                {
                    return new DataResult<int>(ResultStatus.Success, animalCount);
                }

                return new DataResult<int>(ResultStatus.Error, Messages.CommonMessage.Count("Hayvan"), -1);
            }
            catch (Exception exMessage)
            {
                return new DataResult<int>(ResultStatus.Danger, Messages.ExceptionMessage.Count("Hayvan"), -1, exMessage);
            }
        }

        public async Task<IResult> DeleteAsync(int animalId, int modifiedUserById)
        {
            try
            {
                var animal = await _unitOfWork.Animals.GetAsync(u => u.Id == animalId);

                if (animal != null)
                {
                    if (animal.IsDeleted)
                        return new Result(ResultStatus.Info, Messages.CommonMessage.AlreadyDeleted(animal.Code, "Hayvan"));

                    animal.IsDeleted = true;
                    animal.ModifiedByUserId = modifiedUserById;
                    animal.ModifiedDate = DateTime.Now;
                    await _unitOfWork.Animals.UpdateAsync(animal);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, Messages.CommonMessage.Delete(animal.Code, false, "Hayvan"));
                }

                return new Result(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Hayvan"));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Danger, Messages.ExceptionMessage.Delete("Hayvan"), exMessage);
            }
        }

        public async Task<IDataResult<AnimalListDto>> GetAllAsync()
        {
            try
            {
                var animal = await _unitOfWork.Animals.GetAllAsync();

                if (animal.Count > -1)
                {
                    return new DataResult<AnimalListDto>(ResultStatus.Success, new AnimalListDto
                    {
                        Animals = _mapper.Map<IList<AnimalDto>>(animal)
                    });
                }

                return new DataResult<AnimalListDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(true, "Hayvan"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AnimalListDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Hayvan"), null, exMessage);
            }
        }

        public async Task<IDataResult<AnimalDto>> GetAsync(int animalId)
        {
            try
            {
                var animal = await _unitOfWork.Animals.GetAsync(u => u.Id == animalId);

                if (animal != null)
                    return new DataResult<AnimalDto>(ResultStatus.Success, _mapper.Map<AnimalDto>(animal));

                return new DataResult<AnimalDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Hayvan"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AnimalDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Hayvan"), null, exMessage);
            }
        }

        public async Task<IDataResult<AnimalUpdateDto>> GetDetailAsync(int animalId)
        {
            try
            {
                var animal = await _unitOfWork.Animals.GetAsync(u => u.Id == animalId);

                if (animal != null)
                    return new DataResult<AnimalUpdateDto>(ResultStatus.Success, _mapper.Map<AnimalUpdateDto>(animal));

                return new DataResult<AnimalUpdateDto>(ResultStatus.Success, Messages.CommonMessage.NotFound(false, "Hayvan"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AnimalUpdateDto>(ResultStatus.Danger, Messages.ExceptionMessage.Update("Hayvan"), null,
                    exMessage);
            }
        }

        public async Task<IResult> HardDeleteAsync(int animalId)
        {
            try
            {
                var animal = await _unitOfWork.Animals.GetAsync(u => u.Id == animalId);

                if (animal != null)
                {
                    await _unitOfWork.Animals.DeleteAsync(animal);
                    await _unitOfWork.SaveAsync();

                    return new Result(ResultStatus.Success, Messages.CommonMessage.Delete(animal.Code, true, "Hayvan"));
                }

                return new Result(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Hayvan"));
            }
            catch (Exception exMessage)
            {
                return new Result(ResultStatus.Danger, Messages.ExceptionMessage.HardDelete("Hayvan"), exMessage);
            }
        }

        public async Task<IDataResult<AnimalDto>> UpdateAsync(AnimalUpdateDto animalUpdateDto, int modifiedByUserId)
        {
            try
            {
                var oldAnimal = await _unitOfWork.Animals.GetAsync(u => u.Id == animalUpdateDto.Id);

                if (oldAnimal != null)
                {
                    var animal = _mapper.Map<AnimalUpdateDto, Animal>(animalUpdateDto, oldAnimal);
                    animal.ModifiedByUserId = modifiedByUserId;
                    var updatedAnimal = await _unitOfWork.Animals.UpdateAsync(animal);
                    await _unitOfWork.SaveAsync();
                    return new DataResult<AnimalDto>(ResultStatus.Success, Messages.CommonMessage.Update(updatedAnimal.Code, "Hayvan"), _mapper.Map<AnimalDto>(updatedAnimal));
                }

                return new DataResult<AnimalDto>(ResultStatus.Error, Messages.CommonMessage.NotFound(false, "Hayvan"), null);
            }
            catch (Exception exMessage)
            {
                return new DataResult<AnimalDto>(ResultStatus.Danger, Messages.ExceptionMessage.Get("Hayvan"), null, exMessage);
            }
        }
    }
}
