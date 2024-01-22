using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //******** CRUD *********//
        public static string SuccesfullyAdded = "Ekleme İşlemi Başarılı";
        public static string SuccesfullyUpdated = "Güncelleme İşlemi Başarılı";
        public static string SuccesfullyDeleted = "Silme İşlemi Başarılı";



        //******** USER *********//
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre Yanlış";
        public static string SuccessfulLogin = "Giriş Başrılı";
        public static string UserAlreadyExists = "Kullanıcı Zaten Mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";

        public static string EmailInvalid = "E-Posta Geçersiz";

        public static string AuthorizationDenied =  "Yetkiniz Yok";

        public static string PasswordNotMatch = "Eski Sifreniz Dogru Degil";
        public static string EMailNotMatch = "Email Eslesmedi";
        public static string PasswordchangeSuccessful = "Sifre Basariyla Degistirildi";
    }
}
