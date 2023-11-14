using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEmployeeOnly { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
