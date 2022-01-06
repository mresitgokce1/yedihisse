using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;

namespace yedihisse.Business.Abstract
{
    public interface IAnimalTypeService
    {
        Task<IDataResult<AnimalTypeDto>> GetAsync(int animalTypeId);
        Task<IDataResult<AnimalTypeListDto>> GetAllAsync();
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<AnimalTypeDto>> AddAsync(AnimalTypeAddDto animalTypeAddDto, int createdByUserId);
        Task<IDataResult<AnimalTypeUpdateDto>> GetUpdateDtoAsync(int animalTypeId);
        Task<IDataResult<AnimalTypeDto>> UpdateAsync(AnimalTypeUpdateDto animalTypeUpdateDto, int modifiedByUserId);
        Task<IResult> DeleteAsync(int animalTypeId, int modifiedByUserId);
        Task<IResult> HardDeleteAsync(int animalTypeId);
    }
}
