
using System.Threading.Tasks;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;

namespace yedihisse.Business.Abstract
{
    public interface IAnimalService
    {
        Task<IDataResult<AnimalDto>> GetAsync(int animalId);
        Task<IDataResult<AnimalListDto>> GetAllAsync();
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<AnimalDto>> AddAsync(AnimalAddDto animalAddDto, int createdByUserId);
        Task<IDataResult<AnimalUpdateDto>> GetDetailAsync(int animalId);
        Task<IDataResult<AnimalDto>> UpdateAsync(AnimalUpdateDto animalUpdateDto, int modifiedByUserId);
        Task<IResult> DeleteAsync(int animalId, int modifiedByUserId);
        Task<IResult> HardDeleteAsync(int animalId);
    }
}
