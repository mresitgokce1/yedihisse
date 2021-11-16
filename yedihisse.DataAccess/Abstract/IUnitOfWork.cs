using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.DataAccess.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAddressRepository Addresses { get; }
        IAddressTypeRepository AddressTypes { get; }
        IAllotmentJoinCarRepository AllotmentJoinCar { get; }
        IAllotmentRepository Allotments { get; }
        IAnimalRepository Animals { get; }
        IAnimalTypeRepository AnimalTypes { get; }
        IApplicationRepository Applications { get; }
        IApplicationStatusRepository ApplicationStatuses { get; }
        IApplicationStatusTypeRepository ApplicationStatusTypes { get; }
        IBranchManagerRepository BranchManagers { get; }
        IBranchRepository Brances { get; }
        ICarManagerRepository CarManager { get; }
        ICarRepository Cars { get; }
        ICarTypeRepository CarTypes { get; }
        ICompanyManagerRepository CompanyManagers { get; }
        ICompanyRepository Companies { get; }
        IFirmManagerRepository FirmManager { get; }
        IFirmRepository Firms { get; }
        IPaymentOptionRepository PaymentOption { get; }
        IPaymentTypeRepository PaymentType { get; }
        IPaymentRepository PaymentRepository { get; }
        IPhoneNumberRepository PhoneNumbers { get; }
        IPhoneNumberTypeRepository PhoneNumberTypes { get; }
        ISlaughterhouseJoinAnimalRepository SlaughterhouseJoinAnimals { get; }
        ISlaughterhouseJoinTypeRepository SlaughterhouseJoinTypes { get; }
        ISlaughterhouseManagerRepository SlaughterhouseManagers { get; }
        ISlaughterhouseRepository Slaughterhouses { get; }
        ISlaughterhouseTypeRepository SlaughterhouseTypes { get; }
        ISupplierManagerRepository SupplierManagers { get; }
        ISupplierRepository Suppliers { get; }
        ISupplierTypeRepository SupplierTypes { get; }
        IUserJoinTypeRepository UserJoinTypes { get; }
        IUserRepository Users { get; }
        IUserTypeRepository UserTypes { get; }
        Task<int> SaveAsync();
    }
}
