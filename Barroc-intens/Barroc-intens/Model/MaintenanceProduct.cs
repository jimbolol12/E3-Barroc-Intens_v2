using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Model
{
    public class MaintenanceProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PriceFormatted => string.Format("{0:N2}", Price);
        public decimal Storage { get; set; }
        public string StorageFormatted => string.Format("{0:F2}", Storage);
    }
}
