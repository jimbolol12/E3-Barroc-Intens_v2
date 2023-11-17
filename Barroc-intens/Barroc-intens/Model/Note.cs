using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Model
{
    public class Note
    {
        public int Id { get; set; }
        public string Description { get; set; } // Wat genoteerd moet worden
        public DateTime Date { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        
        public int AuthorId {  get; set; }
        public User Author{ get; set; } // User die het invult

    }
}
