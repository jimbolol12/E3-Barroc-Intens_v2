using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Model
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }
        public string Period { get; set; }
        public Company Company { get; set; }
        
    }
}
