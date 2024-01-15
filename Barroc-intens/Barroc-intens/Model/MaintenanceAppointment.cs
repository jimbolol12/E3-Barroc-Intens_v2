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
        public string Remark { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string Location { get; set; }
        public int? EmployeeId { get; set; }
        public User Employee { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string Description { get; set; }
    }
}
