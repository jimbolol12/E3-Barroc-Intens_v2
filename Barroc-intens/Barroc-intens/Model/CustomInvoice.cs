using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Model
{
    public class CustomInvoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime? PaidAt { get; set; }
        public Company Company { get; set; } 
    }
}
