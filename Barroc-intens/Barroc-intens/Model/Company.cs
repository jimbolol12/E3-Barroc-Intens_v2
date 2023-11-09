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
        public User Contact { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string HouseNumber {  get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public DateTime? BkrCheckedAt { get; set; } // ? is voor nullable?



    }
}
