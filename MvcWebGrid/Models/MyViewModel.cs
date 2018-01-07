using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebGrid.Models
{
    public enum ActionStatus
    {
        Open,
        Closed
    }

    public class MyViewModel
    {
        public ActionStatus Status { get; set; }
    }


}