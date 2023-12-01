using Microsoft.WindowsAppSDK.Runtime.Packages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace Barroc_intens.Model
{
    public class Company
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public User Contact { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Street { get; set; }
        public int HouseNumber {  get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public DateOnly? BkrCheckedAt { get; set; } // ? is voor nullable?
        public bool BkrChecked => BkrCheckedAt != null;


    }
}
