﻿using System;
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
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Location { get; set; }
        public int EmployeeId { get; set; }
        public User Employee { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
