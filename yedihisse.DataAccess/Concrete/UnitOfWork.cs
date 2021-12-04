using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.DataAccess.Abstract;
using yedihisse.DataAccess.Concrete.EntityFramework.Contexts;
using yedihisse.DataAccess.Concrete.EntityFramework.Repositories;

namespace yedihisse.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly YediHisseContext _context;

        private EfAddressRepository _addressRepository;
        private EfAddressTypeRepository _addressTypeRepository;
        private EfAllotmentRepository _allotmentRepository;
        private EfAnimalRepository _animalRepository;
        private EfAnimalTypeRepository _animalTypeRepository;
        private EfApplicationRepository _applicationRepository;
        private EfApplicationStatusRepository _applicationStatusRepository;
        private EfApplicationStatusTypeRepository _applicationStatusTypeRepository;
        private EfBranchManagerRepository _branchManagerRepository;
        private EfBranchRepository _branchRepository;
        private EfCarManagerRepository _carManagerRepository;
        private EfCarRepository _carRepository;
        private EfCarTypeRepository _carTypeRepository;
        private EfCarMissionTypeRepository _carMissionTypeRepository;
        private EfCompanyManagerRepository _companyManagerRepository;
        private EfCompanyRepository _companyRepository;
        private EfFirmManagerRepository _firmManagerRepository;
        private EfFirmRepository _firmRepository;
        private EfPaymentOptionRepository _paymentOptionRepository;
        private EfPaymentRepository _paymentRepository;
        private EfPaymentTypeRepository _paymentTypeRepository;
        private EfPhoneNumberRepository _phoneNumberRepository;
        private EfPhoneNumberTypeRepository _phoneNumberTypeRepository;
        private EfKillingGroupRepository _killingGroupRepository;
        private EfKillingGroupTypeRepository _efKillingGroupTypeRepository;
        private EfKillingJoinAnimalRepository _killingJoinAnimalRepository;
        private EfSlaughterhouseJoinTypeRepository _slaughterhouseJoinTypeRepository;
        private EfSlaughterhouseManagerRepository _slaughterhouseManagerRepository;
        private EfSlaughterhouseRepository _slaughterhouseRepository;
        private EfSlaughterhouseTypeRepository _slaughterhouseTypeRepository;
        private EfUserJoinTypeRepository _userJoinTypeRepository;
        private EfUserRepository _userRepository;
        private EfUserTypeRepository _userTypeRepository;

        public UnitOfWork(YediHisseContext context)
        {
            _context = context;
        }

        public IAddressRepository Addresses => _addressRepository ?? new EfAddressRepository(_context);
        public IAddressTypeRepository AddressTypes => _addressTypeRepository ?? new EfAddressTypeRepository(_context);
        public IAllotmentRepository Allotments => _allotmentRepository ?? new EfAllotmentRepository(_context);
        public IAnimalRepository Animals => _animalRepository ?? new EfAnimalRepository(_context);
        public IAnimalTypeRepository AnimalTypes => _animalTypeRepository ?? new EfAnimalTypeRepository(_context);
        public IApplicationRepository Applications => _applicationRepository ?? new EfApplicationRepository(_context);
        public IApplicationStatusRepository ApplicationStatuses => _applicationStatusRepository ?? new EfApplicationStatusRepository(_context);
        public IApplicationStatusTypeRepository ApplicationStatusTypes => _applicationStatusTypeRepository ?? new EfApplicationStatusTypeRepository(_context);
        public IBranchManagerRepository BranchManagers => _branchManagerRepository ?? new EfBranchManagerRepository(_context);
        public IBranchRepository Brances => _branchRepository ?? new EfBranchRepository(_context);
        public ICarManagerRepository CarManager => _carManagerRepository ?? new EfCarManagerRepository(_context);
        public ICarRepository Cars => _carRepository ?? new EfCarRepository(_context);
        public ICarTypeRepository CarTypes => _carTypeRepository ?? new EfCarTypeRepository(_context);
        public ICarMissionTypeRepository CarMissionTypes => _carMissionTypeRepository ?? new EfCarMissionTypeRepository(_context);
        public ICompanyManagerRepository CompanyManagers => _companyManagerRepository ?? new EfCompanyManagerRepository(_context);
        public ICompanyRepository Companies => _companyRepository ?? new EfCompanyRepository(_context);
        public IFirmManagerRepository FirmManager => _firmManagerRepository ?? new EfFirmManagerRepository(_context);
        public IFirmRepository Firms => _firmRepository ?? new EfFirmRepository(_context);
        public IPaymentOptionRepository PaymentOption => _paymentOptionRepository ?? new EfPaymentOptionRepository(_context);
        public IPaymentTypeRepository PaymentType => _paymentTypeRepository ?? new EfPaymentTypeRepository(_context);
        public IPaymentRepository PaymentRepository => _paymentRepository ?? new EfPaymentRepository(_context);
        public IPhoneNumberRepository PhoneNumbers => _phoneNumberRepository ?? new EfPhoneNumberRepository(_context);
        public IPhoneNumberTypeRepository PhoneNumberTypes => _phoneNumberTypeRepository ?? new EfPhoneNumberTypeRepository(_context);
        public IKillingJoinAnimalRepository KillingJoinAnimals => _killingJoinAnimalRepository ?? new EfKillingJoinAnimalRepository(_context);
        public ISlaughterhouseJoinTypeRepository SlaughterhouseJoinTypes => _slaughterhouseJoinTypeRepository ?? new EfSlaughterhouseJoinTypeRepository(_context);
        public ISlaughterhouseManagerRepository SlaughterhouseManagers => _slaughterhouseManagerRepository ?? new EfSlaughterhouseManagerRepository(_context);
        public ISlaughterhouseRepository Slaughterhouses => _slaughterhouseRepository ?? new EfSlaughterhouseRepository(_context);
        public ISlaughterhouseTypeRepository SlaughterhouseTypes => _slaughterhouseTypeRepository ?? new EfSlaughterhouseTypeRepository(_context);
        public IUserJoinTypeRepository UserJoinTypes => _userJoinTypeRepository ?? new EfUserJoinTypeRepository(_context);
        public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);
        public IUserTypeRepository UserTypes => _userTypeRepository ?? new EfUserTypeRepository(_context);
        public IKillingGroupRepository KillingGroupRepository => _killingGroupRepository ?? new EfKillingGroupRepository(_context);
        public IKillingGroupTypeRepository KillingGroupTypeRepository => _efKillingGroupTypeRepository ?? new EfKillingGroupTypeRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
