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
        public bool Sex { get; set; }
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
        public ICollection<CarManager> CarManagers { get; set; }
        public ICollection<Application> Applications { get; set; }

        public ICollection<Address> AddressCreatedByUserIds { get; set; }
        public ICollection<Address> AddressModifiedByUserIds { get; set; }

        public ICollection<AddressType> AddressTypeCreatedByUserIds { get; set; }
        public ICollection<AddressType> AddressTypeModifiedByUserIds { get; set; }

        public ICollection<Allotment> AllotmentCreatedByUserIds { get; set; }
        public ICollection<Allotment> AllotmentModifiedByUserIds { get; set; }

        public ICollection<Animal> AnimalCreatedByUserIds { get; set; }
        public ICollection<Animal> AnimalModifiedByUserIds { get; set; }

        public ICollection<AnimalType> AnimalTypeCreatedByUserIds { get; set; }
        public ICollection<AnimalType> AnimalTypeModifiedByUserIds { get; set; }

        public ICollection<Application> ApplicationCreatedByUserIds { get; set; }
        public ICollection<Application> ApplicationModifiedByUserIds { get; set; }

        public ICollection<ApplicationStatus> ApplicationStatusCreatedByUserIds { get; set; }
        public ICollection<ApplicationStatus> ApplicationStatusModifiedByUserIds { get; set; }

        public ICollection<ApplicationStatusType> ApplicationStatusTypeCreatedByUserIds { get; set; }
        public ICollection<ApplicationStatusType> ApplicationStatusTypeModifiedByUserIds { get; set; }

        public ICollection<Branch> BranchCreatedByUserIds { get; set; }
        public ICollection<Branch> BranchModifiedByUserIds { get; set; }

        public ICollection<BranchManager> BranchManagerCreatedByUserIds { get; set; }
        public ICollection<BranchManager> BranchManagerModifiedByUserIds { get; set; }

        public ICollection<Car> CarCreatedByUserIds { get; set; }
        public ICollection<Car> CarModifiedByUserIds { get; set; }

        public ICollection<CarType> CarTypeCreatedByUserIds { get; set; }
        public ICollection<CarType> CarTypeModifiedByUserIds { get; set; }

        public ICollection<Company> CompanyCreatedByUserIds { get; set; }
        public ICollection<Company> CompanyModifiedByUserIds { get; set; }

        public ICollection<CompanyManager> CompanyManagerCreatedByUserIds { get; set; }
        public ICollection<CompanyManager> CompanyManagerModifiedByUserIds { get; set; }

        public ICollection<Firm> FirmCreatedByUserIds { get; set; }
        public ICollection<Firm> FirmModifiedByUserIds { get; set; }

        public ICollection<FirmManager> FirmManagerCreatedByUserIds { get; set; }
        public ICollection<FirmManager> FirmManagerModifiedByUserIds { get; set; }

        public ICollection<PhoneNumber> PhoneNumberCreatedByUserIds { get; set; }
        public ICollection<PhoneNumber> PhoneNumberModifiedByUserIds { get; set; }

        public ICollection<PhoneNumberType> PhoneNumberTypeCreatedByUserIds { get; set; }
        public ICollection<PhoneNumberType> PhoneNumberTypeModifiedByUserIds { get; set; }

        public ICollection<Slaughterhouse> SlaughterhouseCreatedByUserIds { get; set; }
        public ICollection<Slaughterhouse> SlaughterhouseModifiedByUserIds { get; set; }

        public ICollection<SlaughterhouseJoinAnimal> SlaughterhouseJoinAnimalCreatedByUserIds { get; set; }
        public ICollection<SlaughterhouseJoinAnimal> SlaughterhouseJoinAnimalModifiedByUserIds { get; set; }

        public ICollection<SlaughterhouseJoinType> SlaughterhouseJoinTypeCreatedByUserIds { get; set; }
        public ICollection<SlaughterhouseJoinType> SlaughterhouseJoinTypeModifiedByUserIds { get; set; }

        public ICollection<SlaughterhouseManager> SlaughterhouseManagerCreatedByUserIds { get; set; }
        public ICollection<SlaughterhouseManager> SlaughterhouseManagerModifiedByUserIds { get; set; }

        public ICollection<SlaughterhouseType> SlaughterhouseTypeCreatedByUserIds { get; set; }
        public ICollection<SlaughterhouseType> SlaughterhouseTypeModifiedByUserIds { get; set; }

        public ICollection<Supplier> SupplierCreatedByUserIds { get; set; }
        public ICollection<Supplier> SupplierModifiedByUserIds { get; set; }

        public ICollection<SupplierManager> SupplierManagerCreatedByUserIds { get; set; }
        public ICollection<SupplierManager> SupplierManagerModifiedByUserIds { get; set; }

        public ICollection<SupplierType> SupplierTypeCreatedByUserIds { get; set; }
        public ICollection<SupplierType> SupplierTypeModifiedByUserIds { get; set; }

        public ICollection<UserJoinType> UserJoinTypeCreatedByUserIds { get; set; }
        public ICollection<UserJoinType> UserJoinTypeModifiedByUserIds { get; set; }

        public ICollection<UserType> UserTypeCreatedByUserIds { get; set; }
        public ICollection<UserType> UserTypeModifiedByUserIds { get; set; }

        public ICollection<User> UserCreatedByUserIds { get; set; }
        public ICollection<User> UserModifiedByUserIds { get; set; }

        public ICollection<Payment> PaymentCreatedByUserIds { get; set; }
        public ICollection<Payment> PaymentModifiedByUserIds { get; set; }

        public ICollection<PaymentType> PaymentTypeCreatedByUserIds { get; set; }
        public ICollection<PaymentType> PaymentTypeModifiedByUserIds { get; set; }

        public ICollection<PaymentOption> PaymentOptionCreatedByUserIds { get; set; }
        public ICollection<PaymentOption> PaymentOptionModifiedByUserIds { get; set; }

        public ICollection<CarManager> CarManagerCreatedByUserIds { get; set; }
        public ICollection<CarManager> CarManagerModifiedByUserIds { get; set; }

        public ICollection<AllotmentJoinCar> AllotmentJoinCarCreatedByUserIds { get; set; }
        public ICollection<AllotmentJoinCar> AllotmentJoinCarModifiedByUserIds { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }

    }
}
