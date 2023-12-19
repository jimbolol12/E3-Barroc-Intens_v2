using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Model
{
    public class MaintenanceAppointment
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }  // Corrected property name
        public Company Company { get; set; }
       /* public string Location { get; set; }*/
        /*public string CustomerName { get; set; }*/
        public string ProductId { get; set; }

        public Product Product { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
