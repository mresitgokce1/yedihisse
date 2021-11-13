using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos;
using yedihisse.Shared.Utilities.Results.Abstratct;

namespace yedihisse.Business.Abstract
{
    public interface ICarService
    {
        Task<IDataResult<Car>> Get(int carId);
        Task<IDataResult<IList<Car>>> GetAll();
        Task<IDataResult<IList<Car>>> GetAllByNonDeleted();
        Task<IResult> Add(CarAddDto carAddDto, int createdByUserId);
        Task<IResult> Update(CarUpdateDto carUpdateDto, int modifiedByUserId);
        Task<IResult> Delete(int carId, int modifiedByUserId);
        Task<IResult> HardDelete(int carId);
    }
}
