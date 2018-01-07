using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebGrid.Models
{
    public class tbl1
    {

        public string accountno { get; set; }
        public int classNo { get; set; }
        public string shippingno { get; set; }
        public string record1 { get; set; }
        public string record2 { get; set; }

    }

    public class tbl2
    {

        public string accountno { get; set; }
        public int classNo { get; set; }
        public string shippingno { get; set; }
        public string address { get; set; }


    }
    public static class tblRepo
    {
        public static IEnumerable<tbl1> GetRecRepo()
        {
            List<tbl1> lsttbl1 = new List<tbl1>
        {
            new tbl1{accountno="111", classNo=1,shippingno="200",record1="test1",record2="test2"},
           
        };

            List<tbl2> lsttbl2 = new List<tbl2>
        {
            new tbl2{accountno="111", classNo=1,shippingno="200",address="Kolkata"},
           
        };
            var query = from p in lsttbl1

                        join w in lsttbl2

                        on new { p.accountno, p.classNo, p.shippingno }
                        equals new { w.accountno, w.classNo, w.shippingno }

                        where w.address == "Kolkata"
                        select new { p.record1, p.record2, w.address };

            //var query = from t1 in lsttbl1
            //join t2 in lsttbl2
            //on
            //new { t1.accountno, t1.shippingno, t1.classNo,"kolkata" }
            //equals
            // new { t2.accountno, t2.shippingno, t2.classNo, t2.address }
            //select t1;


            //var query =     from t1 in lsttbl1
            //           join t2 in lsttbl2  
            //                on t1.accountno equals t2.accountno && t1.classNo equals t2.classNo
            //           && t1.shippingno equals t2.shippingno
            //           && t1.address equals "kolkata"
            //           select t1
            //          ).ToList();
            //var query1 = from t1 in lsttbl1
            //join t2 in lsttbl2
            //on t1.accountno.Equals(t2.accountno) && t1.shippingno.Equals(t2.shippingno) &&
            //   t1.classNo.Equals(t2.classNo) && t2..address.Equals("kolkata")
            //select t1;



             var query2 =     (from t1 in lsttbl1
                       join t2 in lsttbl2
                       on new { t1.accountno, t1.classNo, t1.shippingno } 
                               equals new { t2.accountno, t2.classNo, t2.shippingno }
                               where t2.address == "Kolkata"
                               select new { t1, t2 }
                       ).ToList();







            return lsttbl1;

        }
    }
}