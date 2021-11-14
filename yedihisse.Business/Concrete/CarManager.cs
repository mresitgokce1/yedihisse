using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Business.Abstract;
using yedihisse.DataAccess.Abstract;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.CarDto;
using yedihisse.Shared.Utilities.Results.Abstratct;
using yedihisse.Shared.Utilities.Results.Complex_Type;
using yedihisse.Shared.Utilities.Results.Concrete;

namespace yedihisse.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<Car>> Get(int carId)
        {
            var car = await _unitOfWork.Cars.GetAsync(c=>c.Id == carId);
            if (car != null)
            {
                return new DataResult<Car>(ResultStatus.Success, car);
            }
            return new DataResult<Car>(ResultStatus.Error, "Böyle bir araç bulunamadı.", null);
        }

        public async Task<IDataResult<IList<Car>>> GetAll()
        {
            var cars = await _unitOfWork.Cars.GetAllAsync();
            if (cars.Count > -1)
            {
                return new DataResult<IList<Car>> (ResultStatus.Success, cars);
            }
            return new DataResult<IList<Car>> (ResultStatus.Error, "Hiç bir araç bulunamadı.", null);
        }

        public async Task<IDataResult<IList<Car>>> GetAllByNonDeleted()
        {
            var cars = await _unitOfWork.Cars.GetAllAsync(c => !c.IsDeleted);
            if (cars.Count > -1)
            {
                return new DataResult<IList<Car>>(ResultStatus.Success, cars);
            }
            return new DataResult<IList<Car>>(ResultStatus.Error, "Hiç bir araç bulunamadı.", null);
        }

        public async Task<IResult> Add(CarAddDto carAddDto, int createdByUserId)
        {
            await _unitOfWork.Cars.AddAsync(new Car()
            {
                CarName = carAddDto.CarName,
                CarNumberPlate = carAddDto.CarNumberPlate,
                IsActive = carAddDto.IsActive,
                CarTypeId = carAddDto.CarTypeId,
                PhoneNumberId = carAddDto.PhoneNumberId,
                ShippingId = carAddDto.ShippingId,
                CreatedByUserId = createdByUserId,
                ModifiedByUserId = createdByUserId,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            }).ContinueWith(t=>_unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{carAddDto.CarName} adlı araç başarıyla eklenmiştir.");
        }

        public async Task<IResult> Update(CarUpdateDto carUpdateDto, int modifiedByUserId)
        {
            var car = await _unitOfWork.Cars.GetAsync(c => c.Id == carUpdateDto.Id);
            if (car != null)
            {
                car.CarName = carUpdateDto.CarName;
                car.CarNumberPlate = carUpdateDto.CarNumberPlate;
                car.IsDeleted = carUpdateDto.IsDeleted;
                car.IsActive = carUpdateDto.IsActive;
                car.CarTypeId = carUpdateDto.CarTypeId;
                car.PhoneNumberId = carUpdateDto.PhoneNumberId;
                car.ShippingId = carUpdateDto.ShippingId;
                car.ModifiedByUserId = modifiedByUserId;
                car.ModifiedDate = DateTime.Now;
                await _unitOfWork.Cars.UpdateAsync(car).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{carUpdateDto.CarName} adlı araç başarıyla güncellenmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir araç bulunamadı.");
        }

        public async Task<IResult> Delete(int carId, int modifiedByUserId)
        {
            var car = await _unitOfWork.Cars.GetAsync(c => c.Id == carId);
            if (car != null)
            {
                car.IsDeleted = true;
                car.ModifiedByUserId = modifiedByUserId;
                car.ModifiedDate = DateTime.Now;
                await _unitOfWork.Cars.UpdateAsync(car).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{car.CarName} adlı araç başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir araç bulunamadı.");
        }

        public async Task<IResult> HardDelete(int carId)
        {
            var car = await _unitOfWork.Cars.GetAsync(c => c.Id == carId);
            if (car != null)
            {
                await _unitOfWork.Cars.DeleteAsync(car).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{car.CarName} adlı araç başarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir araç bulunamadı.");
        }
    }
}
