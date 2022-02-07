using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
   public class Messages
    {
        public static string CarAdded = "Ürün Eklendi";
        public static string CarNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarsListed = "Ürünler Listelendi";
        public static string UsersNameInvalid = "Kullanıcı İsmi Geçersiz";
        public static string CarNoReturnDate = "Araba Teslim Edilmemeiş";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string CarCountBrandError = "Car da brand ıd 10 aşmayınız";
        public static string CarNameAlreadyExists ="Aynı isimle araba girdiniz";
        public static string BrandErrorLimetExceed="Brand id limitini aşmayınız";
    }
}
