using PersonelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonelMVCUI.Controllers
{
    public class SecurityController : Controller
    {
        PersonelDbEntities1 db = new PersonelDbEntities1();
        // GET: Security
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Kullanici kullanici)
        {
            var kullaniciInDb = db.Kullanici.FirstOrDefault(x => x.Ad == kullanici.Ad && x.Soyad == kullanici.Soyad);
            if(kullaniciInDb!=null)
            {
                //giriş yaparken artık otantike oldu.
                FormsAuthentication.SetAuthCookie(kullaniciInDb.Ad, false);
                return RedirectToAction("Index", "Departman");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanıcı adı veya şifre";
                return View();
            }
            
        }
        public ActionResult LogOut()
        {
            //çıkış yaparkende artık authentication işleminden çıkmış oldu. artık giriş yapana dek sayfalarda gezemez login olmadan.
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}