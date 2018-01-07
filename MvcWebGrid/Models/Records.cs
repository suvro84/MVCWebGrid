using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebGrid.Models
{
    public class Records
    {
        public int id { get; set; }
        public int accountno { get; set; }
        public string record1 { get; set; }
        public string record2 { get; set; }
        public int level { get; set; }
        public int gid { get; set; }
    }
    public class OldRecord
    {
        public int id { get; set; }
        public Records oldRecord { get; set; }

    }

    public class NewRecord
    {
        public int id { get; set; }
        public Records newRecord { get; set; }

    }

    public class FinalRecord
    {

        public OldRecord oldRecord { get; set; }
        public NewRecord newRecord { get; set; }

    }
    public static class RecordsRepo
    {
        public static IEnumerable<FinalRecord> GetRecordsRepo()
        {
            List<Records> recList = new List<Records>
        {
            new Records{id=1, record1="100",record2="200",level=0,gid=1,accountno=111},
            new Records{id=2, record1="300",record2="400",level=0,gid=1,accountno=222},
            new Records{id=3, record1="500",record2="600",level=0,gid=1,accountno=333},
            new Records{id=4, record1="100.5",record2="200.5",level=1,gid=1,accountno=111},
            new Records{id=5, record1="300.5",record2="400.5",level=1,gid=1,accountno=222},
            new Records{id=3, record1="500.5",record2="600.5",level=1,gid=1,accountno=333},
             new Records{id=5, record1="10",record2="20",level=0,gid=1,accountno=777}
        };
            var newLevel = recList.Select(u => u.level).Max();
            var oldLevel = recList.Select(u => u.level).Max() - 1;
            var duplicateAccountNos = recList.GroupBy(r => r.accountno).Where(gr => gr.Count() > 1).Select(r => r.Key);
            var start = 1;
            // var oldlist = recList.Where(u => u.level == oldLevel).Select((u, index) => new OldRecord { oldRecord = u, id = index + start });
            var oldlist = recList.Where(u => u.level == oldLevel).Where(pa => duplicateAccountNos.Contains(pa.accountno)).Select((u, index) => new OldRecord { oldRecord = u, id = index + start });
            //var uniqueAccNo = recList.GroupBy(r => r.accountno).Where(gr => gr.Count() == 1).Select(r => r.Key).Single();
            // var uniqueAccNoData = recList.Where(a => a.accountno == uniqueAccNo);
            var uniqueAccNo = recList.GroupBy(r => r.accountno).Where(gr => gr.Count() == 1).Select(r => r.Key);
            var uniqueAccNoData = recList.Where(pa => uniqueAccNo.Contains(pa.accountno));


           

            //var oldlist = recList.Where(u => u.level == oldLevel);
            //var groups = oldlist.Where(pa => duplicateAccountNos.Contains(pa.accountno)).Select((u, index) => new OldRecord { oldRecord = u, id = index + start });
            //var oldlist = recList.Where(u => u.level == oldLevel).Select((u, index) => new OldRecord { oldRecord = u, id = index + start });
            var newlist = recList.Where(u => u.level == newLevel).Select((u, index) => new NewRecord { newRecord = u, id = index + start });
            var query = (from p in oldlist
                         join pa in newlist on p.id equals pa.id into tempList
                         from final in tempList.DefaultIfEmpty()
                         select new FinalRecord { oldRecord = p, newRecord = final });

            var unique = new List<FinalRecord>();
            FinalRecord finalrec = null;
            //int i = query.Count();
            int i = 0;
            foreach (var obj in uniqueAccNoData)
            {
                finalrec = new FinalRecord();
                finalrec.oldRecord = new OldRecord();
                finalrec.oldRecord.id = i;
                finalrec.oldRecord.oldRecord = new Records();
                finalrec.oldRecord.oldRecord.gid = obj.gid;
                finalrec.oldRecord.oldRecord.record1 = "NA";
                finalrec.oldRecord.oldRecord.record2 = "NA";
                finalrec.newRecord = new NewRecord();
                finalrec.newRecord.id = i;
                finalrec.newRecord.newRecord = new Records();
                finalrec.newRecord.newRecord.gid = obj.gid;
                finalrec.newRecord.newRecord.record1 = obj.record1;
                finalrec.newRecord.newRecord.record2 = obj.record2;
                unique.Add(finalrec);
                i++;
            }

            var mergedList = query.Union(unique.ToList());
            return mergedList;

        }
    }
}