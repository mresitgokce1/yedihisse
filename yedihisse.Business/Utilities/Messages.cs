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

            public static string Auth()
            {
                return "Kullanıcı doğrulaması sırasında bir hata oluştu";
            }
        }

        public static class CommonMessage
        {
            public static string NotFound(bool isPlural, string entityName)
            {
                if (isPlural)
                    return $"Hiç bir {entityName.ToLower()} bulunamadı.";
                else
                    return $"Böyle bir {entityName.ToLower()} bulunamadı.";
            }

            public static string Add(string addressName, string entityName)
            {
                return $"{addressName} adlı {entityName.ToLower()} başarıyla eklenmiştir.";
            }

            public static string Update(string addressName, string entityName)
            {
                return $"{addressName} adlı {entityName.ToLower()} başarıyla güncellenmiştir.";
            }

            public static string Delete(string addressName, bool isHard, string entityName)
            {
                if (isHard)
                    return $"{addressName} adlı {entityName} başarıyla veritabanından silinmiştir";
                else
                    return $"{addressName} adlı {entityName} başarıyla silinmiştir";
            }

            public static string AlreadyDeleted(string userName, string entityName)
            {
                return $"{userName} adlı {entityName} daha önce silinmiştir";
            }

            public static string AlreadyExists(string entityName)
            {
                return $"Eklemek istediğiniz {entityName} zaten var.";
            }

            public static string Count(string entityName)
            {
                return $"Hiç {entityName} bulunamadı.";
            }
        }

        public static class AuthMessage
        {
            public static string ErrorUserName()
            {
                return "Kullanıcı adınız hatalı";
            }

            public static string ErrorPassword()
            {
                return "Şifreniz hatalı";
            }

            public static string LoginSuccess()
            {
                return "Kullanıcı doğrulandı";
            }
        }

        public static class UserJoinTypeMessage
        {
            public static string HardDelete(string userName, string userTypeName)
            {
                return $"{userName} adlı kullanıcının {userTypeName} tipi veritabanından kaldırılmıştır.";
            }

            public static string Delete(string userName, string userTypeName)
            {
                return $"{userName} adlı kullanıcının {userTypeName} tipi kaldırılmıştır.";
            }
        }
    }
}
