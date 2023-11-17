using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Model
{
    public class FaultyRequest
    {
        public int Id { get; set; }
        // TODO: ProductId
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User Employee { get; set; }
        public DateTime? ScheduledAt { get; set; }
        // TODO: EmployeeId | Nullable: Kan zijn dat dr nog geen medewerker aan is gewezen om hieraan te werken.
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
