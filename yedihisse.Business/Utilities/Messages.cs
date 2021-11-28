using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Business.Utilities
{
    public static class Messages
    {
        public static class Address
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir adres bulunamadı.";
                else return "Böyle bir adres bulunamadı.";
            }
            public static string NotFoundType()
            {
                return "Böyle bir adres tipi bulunamadı.";

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
        }
    }
}
