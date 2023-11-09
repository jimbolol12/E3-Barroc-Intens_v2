using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Model
{
    public class CustomInvoiceProduct
    {
        // Koppel tabel voor facturen en producten
        public int Id { get; set; }
        public decimal PricePerProduct { get; set; }
        public Product Product { get; set; }  
        public CustomInvoice CustomInvoice { get; set; }  

    }
}
