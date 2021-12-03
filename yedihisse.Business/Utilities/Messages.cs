using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Business.Utilities
{
    public static class Messages
    {
        public static class ExceptionMessage
        {
            public static string Get(string entityName)
            {
                return $"{entityName} alınırken bir hata oluştu.";
            }
            public static string List(string entityName)
            {
                return $"{entityName} listelenirken bir hata oluştu.";
            }
            public static string Add(string entityName)
            {
                return $"{entityName} eklenirken bir hata oluştu.";
            }
            public static string Update(string entityName)
            {
                return $"{entityName} güncellenirken bir hata oluştu.";
            }
            public static string Delete(string entityName)
            {
                return $"{entityName} silinirken bir hata oluştu.";
            }
            public static string HardDelete(string entityName)
            {
                return $"{entityName} veritabanından silinirken bir hata oluştu.";
            }
            public static string Count(string entityName)
            {
                return $"{entityName} sayısı çekilirken bir hata oluştu.";
            }
        }

        public static class Address
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir adres bulunamadı.";
                else return "Böyle bir adres bulunamadı.";
            }
            public static string Add(string addressName)
            {
                return $"{addressName} adlı adres başarıyla eklenmiştir.";
            }
            public static string Update(string addressName)
            {
                return $"{addressName} adlı adres başarıyla güncellenmiştir.";
            }
            public static string Delete(string addressName ,bool isHard)
            {
                if (isHard)
                    return $"{addressName} adlı adres başarıyla veritabanından silinmiştir";
                else
                    return $"{addressName} adlı adres başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
            public static string NotFoundType()
            {
                return "Böyle bir adres tipi bulunamadı.";
            }
        }

        public static class AddressType
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir adres tipi bulunamadı.";
                else return "Böyle bir adres tipi bulunamadı.";
            }
            public static string Add(string addressTypeName)
            {
                return $"{addressTypeName} adlı adres tipi başarıyla eklenmiştir.";
            }
            public static string Update(string addressTypeName)
            {
                return $"{addressTypeName} adlı adres tipi başarıyla güncellenmiştir.";
            }
            public static string Delete(string addressTypeName, bool isHard)
            {
                if (isHard)
                    return $"{addressTypeName} adlı adres tipi başarıyla veritabanından silinmiştir";
                else
                    return $"{addressTypeName} adlı adres tipi başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class Allotment
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir hisse bulunamadı.";
                else return "Böyle bir hisse bulunamadı.";
            }
            public static string Add(string allotmentNo)
            {
                return $"{allotmentNo} nolu hisse başarıyla eklenmiştir.";
            }
            public static string Update(string allotmentNo)
            {
                return $"{allotmentNo} nolu hisse başarıyla güncellenmiştir.";
            }
            public static string Delete(string allotmentNo, bool isHard)
            {
                if (isHard)
                    return $"{allotmentNo} nolu hisse başarıyla veritabanından silinmiştir";
                else
                    return $"{allotmentNo} nolu hisse başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class Animal
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir hayvan bulunamadı.";
                else return "Böyle bir hayvan bulunamadı.";
            }
            public static string Add(string animalCode)
            {
                return $"{animalCode} kodlu hayvan başarıyla eklenmiştir.";
            }
            public static string Update(string animalCode)
            {
                return $"{animalCode} kodlu hayvan başarıyla güncellenmiştir.";
            }
            public static string Delete(string animalCode, bool isHard)
            {
                if (isHard)
                    return $"{animalCode} kodlu hayvan başarıyla veritabanından silinmiştir";
                else
                    return $"{animalCode} kodlu hayvan başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class AnimalType
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir hayvan tipi bulunamadı.";
                else return "Böyle bir hayvan tipi bulunamadı.";
            }
            public static string Add(string animalTypeName)
            {
                return $"{animalTypeName} adlı hayvan tipi başarıyla eklenmiştir.";
            }
            public static string Update(string animalTypeName)
            {
                return $"{animalTypeName} adlı hayvan tipi başarıyla güncellenmiştir.";
            }
            public static string Delete(string animalTypeName, bool isHard)
            {
                if (isHard)
                    return $"{animalTypeName} adlı hayvan tipi başarıyla veritabanından silinmiştir";
                else
                    return $"{animalTypeName} adlı hayvan tipi başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class Application
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir başvuru bulunamadı.";
                else return "Böyle bir başvuru bulunamadı.";
            }
            public static string Add(string applicationNo)
            {
                return $"{applicationNo} nolu başvuru başarıyla eklenmiştir.";
            }
            public static string Update(string applicationNo)
            {
                return $"{applicationNo} nolu başvuru başarıyla güncellenmiştir.";
            }
            public static string Delete(string applicationNo, bool isHard)
            {
                if (isHard)
                    return $"{applicationNo} nolu başvuru başarıyla veritabanından silinmiştir";
                else
                    return $"{applicationNo} nolu başvuru başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class ApplicationStatus
        {
            
        }

        public static class ApplicationStatusType
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir başvuru statü tipi bulunamadı.";
                else return "Böyle bir başvuru statü tipi bulunamadı.";
            }
            public static string Add(string applicationStatusTypeName)
            {
                return $"{applicationStatusTypeName} adlı başvuru statü tipi başarıyla eklenmiştir.";
            }
            public static string Update(string applicationStatusTypeName)
            {
                return $"{applicationStatusTypeName} adlı başvuru statü tipi başarıyla güncellenmiştir.";
            }
            public static string Delete(string applicationStatusTypeName, bool isHard)
            {
                if (isHard)
                    return $"{applicationStatusTypeName} adlı başvuru statü tipi başarıyla veritabanından silinmiştir";
                else
                    return $"{applicationStatusTypeName} adlı başvuru statü tipi başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class Branch
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir şube bulunamadı.";
                else return "Böyle bir şube bulunamadı.";
            }
            public static string Add(string branchName)
            {
                return $"{branchName} adlı şube başarıyla eklenmiştir.";
            }
            public static string Update(string branchName)
            {
                return $"{branchName} adlı şube başarıyla güncellenmiştir.";
            }
            public static string Delete(string branchName, bool isHard)
            {
                if (isHard)
                    return $"{branchName} adlı şube başarıyla veritabanından silinmiştir";
                else
                    return $"{branchName} adlı şube başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class BranchManager
        {
        }

        public static class Car
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir araç bulunamadı.";
                else return "Böyle bir araç bulunamadı.";
            }
            public static string Add(string carName)
            {
                return $"{carName} adlı araç başarıyla eklenmiştir.";
            }
            public static string Update(string carName)
            {
                return $"{carName} adlı araç başarıyla güncellenmiştir.";
            }
            public static string Delete(string carName, bool isHard)
            {
                if (isHard)
                    return $"{carName} adlı araç başarıyla veritabanından silinmiştir";
                else
                    return $"{carName} adlı araç başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class CarManager
        {
        }

        public static class CarMissionType
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir araç görev tipi bulunamadı.";
                else return "Böyle bir araç görev tipi bulunamadı.";
            }
            public static string Add(string carMissionTypeName)
            {
                return $"{carMissionTypeName} adlı araç görev tipi başarıyla eklenmiştir.";
            }
            public static string Update(string carMissionTypeName)
            {
                return $"{carMissionTypeName} adlı araç görev tipi başarıyla güncellenmiştir.";
            }
            public static string Delete(string carMissionTypeName, bool isHard)
            {
                if (isHard)
                    return $"{carMissionTypeName} adlı araç görev tipi başarıyla veritabanından silinmiştir";
                else
                    return $"{carMissionTypeName} adlı araç görev tipi başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class CarType
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir araç tipi bulunamadı.";
                else return "Böyle bir araç tipi bulunamadı.";
            }
            public static string Add(string carTypeName)
            {
                return $"{carTypeName} adlı araç tipi başarıyla eklenmiştir.";
            }
            public static string Update(string carTypeName)
            {
                return $"{carTypeName} adlı araç tipi başarıyla güncellenmiştir.";
            }
            public static string Delete(string carTypeName, bool isHard)
            {
                if (isHard)
                    return $"{carTypeName} adlı araç tipi başarıyla veritabanından silinmiştir";
                else
                    return $"{carTypeName} adlı araç tipi başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class Company
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir şirket bulunamadı.";
                else return "Böyle bir şirket bulunamadı.";
            }
            public static string Add(string companyName)
            {
                return $"{companyName} adlı şirket başarıyla eklenmiştir.";
            }
            public static string Update(string companyName)
            {
                return $"{companyName} adlı şirket başarıyla güncellenmiştir.";
            }
            public static string Delete(string companyName, bool isHard)
            {
                if (isHard)
                    return $"{companyName} adlı şirket başarıyla veritabanından silinmiştir";
                else
                    return $"{companyName} adlı şirket başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class CompanyManager
        {

        }

        public static class Firm
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir firma bulunamadı.";
                else return "Böyle bir firma bulunamadı.";
            }
            public static string Add(string firmName)
            {
                return $"{firmName} adlı firma başarıyla eklenmiştir.";
            }
            public static string Update(string firmName)
            {
                return $"{firmName} adlı firma başarıyla güncellenmiştir.";
            }
            public static string Delete(string firmName, bool isHard)
            {
                if (isHard)
                    return $"{firmName} adlı firma başarıyla veritabanından silinmiştir";
                else
                    return $"{firmName} adlı firma başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class FirmManager
        {

        }

        public static class Payment
        {
            
        }

        public static class PaymentOption
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir ödeme türü bulunamadı.";
                else return "Böyle bir ödeme türü bulunamadı.";
            }
            public static string Add(string paymentOptionName)
            {
                return $"{paymentOptionName} adlı ödeme türü başarıyla eklenmiştir.";
            }
            public static string Update(string paymentOptionName)
            {
                return $"{paymentOptionName} adlı ödeme türü başarıyla güncellenmiştir.";
            }
            public static string Delete(string paymentOptionName, bool isHard)
            {
                if (isHard)
                    return $"{paymentOptionName} adlı ödeme türü başarıyla veritabanından silinmiştir";
                else
                    return $"{paymentOptionName} adlı ödeme türü başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class PaymentType
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir ödeme tipi bulunamadı.";
                else return "Böyle bir ödeme tipi bulunamadı.";
            }
            public static string Add(string paymentTypeName)
            {
                return $"{paymentTypeName} adlı ödeme tipi başarıyla eklenmiştir.";
            }
            public static string Update(string paymentTypeName)
            {
                return $"{paymentTypeName} adlı ödeme tipi başarıyla güncellenmiştir.";
            }
            public static string Delete(string paymentTypeName, bool isHard)
            {
                if (isHard)
                    return $"{paymentTypeName} adlı ödeme tipi başarıyla veritabanından silinmiştir";
                else
                    return $"{paymentTypeName} adlı ödeme tipi başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class PhoneNumber
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir telefon numarası bulunamadı.";
                else return "Böyle bir telefon numarası bulunamadı.";
            }
            public static string Add(string phoneNumber)
            {
                return $"{phoneNumber} nolu telefon başarıyla eklenmiştir.";
            }
            public static string Update(string phoneNumber)
            {
                return $"{phoneNumber} nolu telefon başarıyla güncellenmiştir.";
            }
            public static string Delete(string phoneNumber, bool isHard)
            {
                if (isHard)
                    return $"{phoneNumber} nolu telefon başarıyla veritabanından silinmiştir";
                else
                    return $"{phoneNumber} nolu telefon başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class PhoneNumberType
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir telefon numarası tipi bulunamadı.";
                else return "Böyle bir telefon numarası tipi bulunamadı.";
            }
            public static string Add(string phoneNumberTypeName)
            {
                return $"{phoneNumberTypeName} adlı telefon numarası tipi başarıyla eklenmiştir.";
            }
            public static string Update(string phoneNumberTypeName)
            {
                return $"{phoneNumberTypeName} adlı telefon numarası tipi başarıyla güncellenmiştir.";
            }
            public static string Delete(string phoneNumberTypeName, bool isHard)
            {
                if (isHard)
                    return $"{phoneNumberTypeName} adlı telefon numarası tipi başarıyla veritabanından silinmiştir";
                else
                    return $"{phoneNumberTypeName} adlı telefon numarası tipi başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class Slaughterhouse
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kesimhane bulunamadı.";
                else return "Böyle bir kesimhane bulunamadı.";
            }
            public static string Add(string slaughterhouseName)
            {
                return $"{slaughterhouseName} adlı kesimhane başarıyla eklenmiştir.";
            }
            public static string Update(string slaughterhouseName)
            {
                return $"{slaughterhouseName} adlı kesimhane başarıyla güncellenmiştir.";
            }
            public static string Delete(string slaughterhouseName, bool isHard)
            {
                if (isHard)
                    return $"{slaughterhouseName} adlı kesimhane başarıyla veritabanından silinmiştir";
                else
                    return $"{slaughterhouseName} adlı kesimhane başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class SlaughterhouseJoinAnimal
        {
        }

        public static class SlaughterhouseJoinType
        {
        }

        public static class SlaughterhouseManager
        {
        }

        public static class SlaughterhouseType
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kesimhane tipi bulunamadı.";
                else return "Böyle bir kesimhane tipi bulunamadı.";
            }
            public static string Add(string slaughterhouseTypeName)
            {
                return $"{slaughterhouseTypeName} adlı kesimhane tipi başarıyla eklenmiştir.";
            }
            public static string Update(string slaughterhouseTypeName)
            {
                return $"{slaughterhouseTypeName} adlı kesimhane tipi başarıyla güncellenmiştir.";
            }
            public static string Delete(string slaughterhouseTypeName, bool isHard)
            {
                if (isHard)
                    return $"{slaughterhouseTypeName} adlı kesimhane tipi başarıyla veritabanından silinmiştir";
                else
                    return $"{slaughterhouseTypeName} adlı kesimhane tipi başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class User
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kullanıcı bulunamadı.";
                else return "Böyle bir kullanıcı bulunamadı.";
            }
            public static string Add(string userName)
            {
                return $"{userName} adlı kullanıcı başarıyla eklenmiştir.";
            }
            public static string Update(string userName)
            {
                return $"{userName} adlı kullanıcı başarıyla güncellenmiştir.";
            }
            public static string Delete(string userName, bool isHard)
            {
                if (isHard)
                    return $"{userName} adlı kullanıcı başarıyla veritabanından silinmiştir";
                else
                    return $"{userName} adlı kullanıcı başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class UserJoinType
        {
        }

        public static class UserType
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kullanıcı tipi bulunamadı.";
                else return "Böyle bir kullanıcı tipi bulunamadı.";
            }
            public static string Add(string userTypeName)
            {
                return $"{userTypeName} adlı kullanıcı tipi başarıyla eklenmiştir.";
            }
            public static string Update(string userTypeName)
            {
                return $"{userTypeName} adlı kullanıcı tipi başarıyla güncellenmiştir.";
            }
            public static string Delete(string userTypeName, bool isHard)
            {
                if (isHard)
                    return $"{userTypeName} adlı kullanıcı tipi başarıyla veritabanından silinmiştir";
                else
                    return $"{userTypeName} adlı kullanıcı tipi başarıyla silinmiştir";
            }
            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }
    }
}
