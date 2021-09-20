using PersonelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonelMVCUI.ViewModels;

namespace PersonelMVCUI.Controllers
{
    [Authorize(Roles = "A,B")]
    public class AddressController : Controller
    {
        PersonelDbEntities1 db = new PersonelDbEntities1();
        // GET: Address
        public ActionResult Index()
        {
            var model = db.ADDRESS.Include(x => x.Personel).ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {
            var model = new AddressFormViewModel()
            {
                Personeller = db.Personel.ToList(),
                Address = new ADDRESS()
            };

            return View("AddressForm",model);
        }
        public ActionResult Kaydet(ADDRESS address)
        {
            if (!ModelState.IsValid)
            {
                var model = new AddressFormViewModel()
                {
                    Personeller=db.Personel.ToList(),
                    Address=address
                };
                return View("AddressForm", model);
            }
            if(address.ID==0) //ekleme
            {
                db.ADDRESS.Add(address);
            }
            else  //güncelleme
            {
                db.Entry(address).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var model = new AddressFormViewModel()
            {
                Personeller = db.Personel.ToList(),
                Address = db.ADDRESS.Find(id)
            };
            return View("AddressForm", model); 
        }
        public ActionResult Sil(int id)
        {
            var silinecekAddress = db.ADDRESS.Find(id);
            if (silinecekAddress == null)
            {
                return HttpNotFound();
            }
            db.ADDRESS.Remove(silinecekAddress);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdresleriListele(int id)
        {
            var model = db.ADDRESS.Where(x => x.PERSONELID == id).ToList();
            return PartialView(model);
        }
    }
}