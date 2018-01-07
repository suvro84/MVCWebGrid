using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebGrid.Models
{
    public class Package
    {

        public string Company { get; set; }
        public double Weight { get; set; }
        public long TrackingNumber { get; set; }
        public DateTime DateOrder { get; set; }
        public bool HasCompleted { get; set; }
    }
}