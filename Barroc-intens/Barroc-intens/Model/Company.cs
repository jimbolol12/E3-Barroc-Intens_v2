using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Model
{
    public class Company
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int phone { get; set; }
        public string street { get; set; }
        public int houseNumber { get; set; }
        public string city { get; set; }
        public int countryCode { get; set; }
        public DateTime bkrCheckedAt { get; set; }
    }
}
