using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class User : EntityBase, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Sex { get; set; }
        public byte[] PasswordHash { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public ICollection<UserJoinType> UserJoinTypes { get; set; }
        public ICollection<SlaughterhouseManager> SlaughterhouseManagers { get; set; }
        public ICollection<SupplierManager> SupplierManagers { get; set; }
        public ICollection<CompanyManager> CompanyManagers { get; set; }
        public ICollection<FirmManager> FirmManagers { get; set; }
        public ICollection<BranchManager> BranchManagers { get; set; }
        public ICollection<ShippingManager> ShippingManagers { get; set; }
        public ICollection<Application> Applications { get; set; }

        public ICollection<Address> AddressCreatedByIds { get; set; }
        public ICollection<Address> AddressModifiedByIds { get; set; }

        public ICollection<AddressType> AddressTypeCreatedByIds { get; set; }
        public ICollection<AddressType> AddressTypeModifiedByIds { get; set; }

        public ICollection<Allotment> AllotmentCreatedByIds { get; set; }
        public ICollection<Allotment> AllotmentModifiedByIds { get; set; }

        public ICollection<Animal> AnimalCreatedByIds { get; set; }
        public ICollection<Animal> AnimalModifiedByIds { get; set; }

        public ICollection<AnimalType> AnimalTypeCreatedByIds { get; set; }
        public ICollection<AnimalType> AnimalTypeModifiedByIds { get; set; }

        public ICollection<Application> ApplicationCreatedByIds { get; set; }
        public ICollection<Application> ApplicationModifiedByIds { get; set; }

        public ICollection<ApplicationStatus> ApplicationStatusCreatedByIds { get; set; }
        public ICollection<ApplicationStatus> ApplicationStatusModifiedByIds { get; set; }

        public ICollection<ApplicationStatusType> ApplicationStatusTypeCreatedByIds { get; set; }
        public ICollection<ApplicationStatusType> ApplicationStatusTypeModifiedByIds { get; set; }

        public ICollection<Branch> BranchCreatedByIds { get; set; }
        public ICollection<Branch> BranchModifiedByIds { get; set; }

        public ICollection<BranchManager> BranchManagerCreatedByIds { get; set; }
        public ICollection<BranchManager> BranchManagerModifiedByIds { get; set; }

        public ICollection<Car> CarCreatedByIds { get; set; }
        public ICollection<Car> CarModifiedByIds { get; set; }

        public ICollection<CarType> CarTypeCreatedByIds { get; set; }
        public ICollection<CarType> CarTypeModifiedByIds { get; set; }

        public ICollection<Company> CompanyCreatedByIds { get; set; }
        public ICollection<Company> CompanyModifiedByIds { get; set; }

        public ICollection<CompanyManager> CompanyManagerCreatedByIds { get; set; }
        public ICollection<CompanyManager> CompanyManagerModifiedByIds { get; set; }

        public ICollection<Firm> FirmCreatedByIds { get; set; }
        public ICollection<Firm> FirmModifiedByIds { get; set; }

        public ICollection<FirmManager> FirmManagerCreatedByIds { get; set; }
        public ICollection<FirmManager> FirmManagerModifiedByIds { get; set; }

        public ICollection<PhoneNumber> PhoneNumberCreatedByIds { get; set; }
        public ICollection<PhoneNumber> PhoneNumberModifiedByIds { get; set; }

        public ICollection<PhoneNumberType> PhoneNumberTypeCreatedByIds { get; set; }
        public ICollection<PhoneNumberType> PhoneNumberTypeModifiedByIds { get; set; }

        public ICollection<Shipping> ShippingCreatedByIds { get; set; }
        public ICollection<Shipping> ShippingModifiedByIds { get; set; }

        public ICollection<ShippingManager> ShippingManagerCreatedByIds { get; set; }
        public ICollection<ShippingManager> ShippingManagerModifiedByIds { get; set; }

        public ICollection<Slaughterhouse> SlaughterhouseCreatedByIds { get; set; }
        public ICollection<Slaughterhouse> SlaughterhouseModifiedByIds { get; set; }

        public ICollection<SlaughterhouseJoinAnimal> SlaughterhouseJoinAnimalCreatedByIds { get; set; }
        public ICollection<SlaughterhouseJoinAnimal> SlaughterhouseJoinAnimalModifiedByIds { get; set; }

        public ICollection<SlaughterhouseJoinType> SlaughterhouseJoinTypeCreatedByIds { get; set; }
        public ICollection<SlaughterhouseJoinType> SlaughterhouseJoinTypeModifiedByIds { get; set; }

        public ICollection<SlaughterhouseManager> SlaughterhouseManagerCreatedByIds { get; set; }
        public ICollection<SlaughterhouseManager> SlaughterhouseManagerModifiedByIds { get; set; }

        public ICollection<SlaughterhouseType> SlaughterhouseTypeCreatedByIds { get; set; }
        public ICollection<SlaughterhouseType> SlaughterhouseTypeModifiedByIds { get; set; }

        public ICollection<Supplier> SupplierCreatedByIds { get; set; }
        public ICollection<Supplier> SupplierModifiedByIds { get; set; }

        public ICollection<SupplierManager> SupplierManagerCreatedByIds { get; set; }
        public ICollection<SupplierManager> SupplierManagerModifiedByIds { get; set; }

        public ICollection<SupplierType> SupplierTypeCreatedByIds { get; set; }
        public ICollection<SupplierType> SupplierTypeModifiedByIds { get; set; }

        public ICollection<UserJoinType> UserJoinTypeCreatedByIds { get; set; }
        public ICollection<UserJoinType> UserJoinTypeModifiedByIds { get; set; }

        public ICollection<UserType> UserTypeCreatedByIds { get; set; }
        public ICollection<UserType> UserTypeModifiedByIds { get; set; }

        public ICollection<User> UserCreatedByIds { get; set; }
        public ICollection<User> UserModifiedByIds { get; set; }

        public int UserCreatedByIdId { get; set; }
        public User UserCreatedById { get; set; }

        public int UserModifiedByIdId { get; set; }
        public User UserModifiedById { get; set; }

    }
}
