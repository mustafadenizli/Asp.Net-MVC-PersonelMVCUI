using PersonelMVCUI.Models.EntityFramework;
using PersonelMVCUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelMVCUI.Controllers
{
    [Authorize(Roles = "A,B")]
 
    public class DepartmanController : Controller
    {
        PersonelDbEntities1 db = new PersonelDbEntities1();
        // GET: Home
       public ActionResult Test()
        {
            return View();
        }
        //ELMAH: HATALARI VERİTABANINA LOGLAMA İŞLEMİ
        //[HandleError]
        public ActionResult Index()
        {
            var model = db.Departman.ToList();
            //int a = 30, b = 0;
            //int c = a / b;
            return View(model);
        }
        [HttpGet]
        public ActionResult Yeni()
        {

            return View("DepartmanForm",new Departman());
        }
        //HttpPost yerine antiforgeryToken kullandık. saldırıların önüne geçmek için.
        //CSRF saldırılarının önüne geçmek için.
        [ValidateAntiForgeryToken]
        //kaydet ile hem güncelleme hem kayıt yapılmış oldu.
        public ActionResult Kaydet(Departman departman)
        {
            if(!ModelState.IsValid)
            {
                return View("DepartmanForm");
            }
            MesajViewModel model = new MesajViewModel();

            if(departman.Id==0)
            {
                db.Departman.Add(departman);
                model.Mesaj = departman.Ad + " başarıyla eklendi...";
            }
            else
            {
                var guncellenecekDepartman = db.Departman.Find(departman.Id);
                if(guncellenecekDepartman==null)
                {
                    return HttpNotFound();
                }
                guncellenecekDepartman.Ad = departman.Ad;
                model.Mesaj = departman.Ad + " başarıyla güncellendi...";
            }
            
            db.SaveChanges();
            model.Status = true;
            model.LinkTest = "Departman Listesi";
            model.Url = "/Departman";
            return View("_Mesaj",model);
        }
        //model içerisinde bulduysa textbox'a o stringi getirecek ona göre güncelleme yapılacak.
        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("DepartmanForm",model); 
        }  
        public ActionResult Sil(int id)
        {
            var silinecekDepartman = db.Departman.Find(id);
            if (silinecekDepartman == null)
                return HttpNotFound();
            db.Departman.Remove(silinecekDepartman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}