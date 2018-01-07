using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebGrid.Models
{
    public class MergedRecords
    {
        public int id { get; set; }
        public int accountno { get; set; }
        public string scCode { get; set; }
      
        public int level { get; set; }
        public string vdt { get; set; }
    }
    public class MergedCelGridModel
    {
        public List<MergedRecords> mergedRecordsGrid { get; set; }
        public List<Calculations> calcList { get; set; }

    }

    public class Calculations
    {
        public int id { get; set; }
        public string calcName { get; set; }

    }
    public static class CalculationsRepo
    {
        public static List<Calculations> GetCalculationsRepo()
        {
            List<Calculations> calculationsList = new List<Calculations>
        {
            new Calculations{id=1, calcName="x1"},
            new Calculations{id=1, calcName="y1"},
            new Calculations{id=1, calcName="z1"},
             new Calculations{id=2, calcName="x1"},
            new Calculations{id=2, calcName="y1"},
            new Calculations{id=2, calcName="z1"},
           
        };
            return calculationsList;

        }
    }
    public static class MergedRecordsRepo
    {
        public static List<MergedRecords> GetMergedRecordsRepo()
        {
            List<MergedRecords> recList = new List<MergedRecords>
        {
            new MergedRecords{id=1, scCode="A1",level=0,vdt="1",accountno=111},
            new MergedRecords{id=2, scCode="B1",level=0,vdt="1",accountno=222},
            new MergedRecords{id=3, scCode="C1",level=0,vdt="1",accountno=333},
            new MergedRecords{id=4, scCode="D1",level=1,vdt="1",accountno=111},
            new MergedRecords{id=5, scCode="E1",level=1,vdt="1",accountno=222},
            new MergedRecords{id=3, scCode="F1",level=1,vdt="1",accountno=333},
             new MergedRecords{id=5, scCode="G1",level=0,vdt="1",accountno=777}
        };
            return recList;

        }
    }
}