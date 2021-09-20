using PersonelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelMVCUI.ViewModels
{
    public class AddressFormViewModel
    {
        public IEnumerable<Personel> Personeller { get; set; }
        public ADDRESS  Address { get; set; }
    }
}