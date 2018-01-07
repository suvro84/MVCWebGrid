using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MvcWebGrid.Models;
using MvcWebGrid.Models.Repository;
using MvcWebGrid.Utility;

namespace MvcWebGrid.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DBOperations objDBOperations = new DBOperations();
        public ActionResult Index()
        {
            var albums = AlbumRepo.GetAlbums();
            HttpCookie _userInfoCookies = Request.Cookies["UserInfo"];
            if (_userInfoCookies != null)
            {
                string UserName = _userInfoCookies["UserName"].ToString();

            }
            return View(albums);
        }

        public ActionResult PopUp()
        {

            return View();
        }
        public ActionResult ModalPopUp()
        {

            return View();
        }
        public ActionResult NewAccordian()
        {

            return View();
        }
        public ActionResult testTable()
        {

            return View();
        }
        public ActionResult AjaxGrid()
        {

            return View();
        }
        public ActionResult RadioButton()
        {
            var books = BookOrderRepo.GetBookOrderRepo().Select(r => r.book).ToList();
            ViewBag.RadioButtonValues = BookOrderRepo.GetBookOrderRepo().Select(r => r.book).ToList();

            List<Employee> lstemp = new List<Employee>();
            Employee objemp = new Employee();
            IEnumerable<Employee> ietemp = EmployeeRepo.GetEmployees();
            lstemp = (List<Employee>)ietemp;
            //StringBuilder sbHTML = new StringBuilder();

            //PropertyInfo[] propertyInfos;
            //propertyInfos = typeof(Employee).GetProperties(BindingFlags.Public |
            //                                              BindingFlags.Static);

            //foreach (var prop in lstemp.GetType().GetProperties())
            //{
            //    sbHTML.Append(prop.Name);
            //    sbHTML.Append("<br>");
            //}
            //for (int i = 0; i < lstemp.Count; i++)
            //{
            //    foreach (PropertyInfo Property in lstemp[i].GetType().GetProperties())
            //    {
            //        sbHTML.Append(Property.GetValue(lstemp[i], null));
            //    }
            //}
            //string str = sbHTML.ToString();
            // var employeeValues = GetPropertyValues(lstemp);
            return View(lstemp);
        }
        public ActionResult JsonGrid()
        {
            var books = BookOrderRepo.GetBookOrderRepo().Select(r => r.book).ToList();
            ViewBag.RadioButtonValues = BookOrderRepo.GetBookOrderRepo().Select(r => r.book).ToList();

            List<Employee> lstemp = new List<Employee>();
            Employee objemp = new Employee();
            IEnumerable<Employee> ietemp = EmployeeRepo.GetEmployees();
            lstemp = (List<Employee>)ietemp;
            //StringBuilder sbHTML = new StringBuilder();

            //PropertyInfo[] propertyInfos;
            //propertyInfos = typeof(Employee).GetProperties(BindingFlags.Public |
            //                                              BindingFlags.Static);

            //foreach (var prop in lstemp.GetType().GetProperties())
            //{
            //    sbHTML.Append(prop.Name);
            //    sbHTML.Append("<br>");
            //}
            //for (int i = 0; i < lstemp.Count; i++)
            //{
            //    foreach (PropertyInfo Property in lstemp[i].GetType().GetProperties())
            //    {
            //        sbHTML.Append(Property.GetValue(lstemp[i], null));
            //    }
            //}
            //string str = sbHTML.ToString();
            // var employeeValues = GetPropertyValues(lstemp);
            return View(lstemp);
        }


        public ActionResult MergedCellGrid()
        {
            var mergedCelGridModel = new MergedCelGridModel();
            mergedCelGridModel.mergedRecordsGrid = MergedRecordsRepo.GetMergedRecordsRepo();
            mergedCelGridModel.calcList = CalculationsRepo.GetCalculationsRepo();
            return View(mergedCelGridModel);
        }

        public ActionResult PassJsonData(string updatedObjects)
        {
          //  [{"employeeId":"1", "employeeName":"test1", "address":"Kolkata"},{"employeeId":"2", "employeeName":"test2", "address":"Kolkata"}]         
            var jsonString = JsonHelper.JsonDeserialize<List<Employee>>(updatedObjects);
            return Json("1", JsonRequestBehavior.AllowGet);
            //return View();
        }

        private Dictionary<object, object> GetPropertyValues(object className)
        {
            // this dictionary will hold the PropertyName and its Value.
            var values = new Dictionary<object, object>();

            var type = className.GetType();
            var propertyInfos = type.GetProperties();
            StringBuilder sbHTML = new StringBuilder();
            //foreach (var prop in className[0].GetType().GetProperties())
            //{
            //    sbHTML.Append(prop.Name);
            //    sbHTML.Append("<br>");
            //}
            //for (int i = 0; i < className.Count; i++)
            //{
            //    foreach (PropertyInfo Property in lstemp[i].GetType().GetProperties())
            //    {
            //        sbHTML.Append(Property.GetValue(lstemp[i], null));
            //    }
            //}
            propertyInfos.All(propertyInfo =>
            {
                values.Add(propertyInfo.Name, propertyInfo.GetValue(className, null));
                return true;
            });

            return values;
        }

        public DataTable GenericListToDataTable(object list)
        {
            DataTable dt = null;

            Type listType = list.GetType();
            if (listType.IsGenericType)
            {
                //determine the underlying type the List<> contains
                Type elementType = listType.GetGenericArguments()[0];

                //create empty table -- give it a name in case
                //it needs to be serialized
                dt = new DataTable(elementType.Name + "List");

                //define the table -- add a column for each public
                //property or field
                MemberInfo[] miArray = elementType.GetMembers(
                    BindingFlags.Public | BindingFlags.Instance);
                foreach (MemberInfo mi in miArray)
                {
                    if (mi.MemberType == MemberTypes.Property)
                    {
                        PropertyInfo pi = mi as PropertyInfo;
                        dt.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    else if (mi.MemberType == MemberTypes.Field)
                    {
                        FieldInfo fi = mi as FieldInfo;
                        dt.Columns.Add(fi.Name, fi.FieldType);
                    }
                }
                // dt.Columns.Add("bflag", typeof(Boolean));
                //populate the table
                IList il = list as IList;
                foreach (object record in il)
                {
                    int i = 0;
                    object[] fieldValues = new object[dt.Columns.Count];
                    foreach (DataColumn c in dt.Columns)
                    {
                        MemberInfo mi = elementType.GetMember(c.ColumnName)[0];
                        if (mi.MemberType == MemberTypes.Property)
                        {
                            PropertyInfo pi = mi as PropertyInfo;
                            fieldValues[i] = pi.GetValue(record, null);
                        }
                        else if (mi.MemberType == MemberTypes.Field)
                        {
                            FieldInfo fi = mi as FieldInfo;
                            fieldValues[i] = fi.GetValue(record);
                        }
                        i++;
                    }
                    dt.Rows.Add(fieldValues);
                }
            }
            return dt;
        }
        public ActionResult Accordion()
        {
            List<Employee> lstemp = new List<Employee>();
            Employee objemp = new Employee();
            IEnumerable<Employee> ietemp = EmployeeRepo.GetEmployees();
            lstemp = (List<Employee>)ietemp;


            objemp.employeeId = 0;
            objemp.employeeName = "Please Select";
            lstemp.Insert(0, objemp);
            ViewData["empList"] = lstemp;
            HttpCookie _userInfoCookies = Request.Cookies["UserInfo"];
            if (_userInfoCookies != null)
            {
                string UserName = _userInfoCookies["UserName"].ToString();

            }

            MvcWebGrid.Models.User obj = new MvcWebGrid.Models.User();
            if (Session["User"] != null)
            {
                obj = (MvcWebGrid.Models.User)Session["User"];
                foreach (var item in obj.Previleges)
                {

                    switch (item)
                    {

                        case "Add":
                            ViewData["Add"] = true;
                            break;
                        case "Edit":
                            ViewData["Edit"] = true;
                            break;
                        case "Del":
                            ViewData["Del"] = false;
                            break;
                        case "View":
                            ViewData["View"] = true;
                            break;

                    }
                }


                if (Request.Form["btnAdd"] != null)
                {
                }
                if (Request.Form["btnDel"] != null)
                {
                }
                if (Request.Form["btnView"] != null)
                {
                }
            }

            return View();
        }
        public ActionResult ScrollDataTableGrid()
        {

            var albums = EmployeeRepo.GetEmployees();
            return PartialView("PartialScrollGrid", albums);
        }

        public ActionResult DataTableGrid()
        {

            var albums = EmployeeRepo.GetEmployees();
            return View(albums);
        }
        public ActionResult FixedWidthGrid()
        {
            var rec = tblRepo.GetRecRepo();
            var bookOrderRepo = BookOrderRepo.GetBookOrderRepo();
            StringBuilder sb = new StringBuilder();

            //IList<PropertyInfo> propertyInfos = typeof(Employee).GetProperties();
            //Employee em =new Employee();

            //    //add header line.
            //    foreach (PropertyInfo propertyInfo in propertyInfos)
            //    {
            //        sb.Append(propertyInfo.Name).Append(",");
            //        sb.Append(propertyInfo.GetValue(em, null)).Append(",");
            //    }
            //   // sb.Remove(sb.Length - 1, 1).AppendLine();

            //    string str = sb.ToString();
            ////add value for each property.
            var emp = EmployeeRepo.GetEmployees();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(Employee));
            foreach (PropertyDescriptor prop in props)
            {
                sb.Append(prop.DisplayName); // header
                sb.Append("\t");
            }
            // sb.Append();
            foreach (Employee item in emp)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    sb.Append(prop.Converter.ConvertToString(
                         prop.GetValue(item)));
                    sb.Append("\t");
                }
                sb.Append("");
            }

            string str = sb.ToString();



            return View(bookOrderRepo);
        }


        public ActionResult AdjustHeightFixedGrid()
        {





            return View(EmployeeRepo.GetEmployees());
        }

        public ActionResult OldNewRecord()
        {

            var recordsRepo = RecordsRepo.GetRecordsRepo();
            return View(recordsRepo);
        }
        public ActionResult GetData(string address)
        {
            var bookOrderRepo = BookOrderRepo.GetBookOrderRepo();

            return Json(bookOrderRepo, JsonRequestBehavior.AllowGet);
            //return View(albums);
        }
        public ActionResult GetBookDetails(int id)
        {
            var bookslist = BookOrderRepo.GetBooks();

            var bookdetails = bookslist.Where(b => b.BookID.Equals(id)).ToList();
            string html = RenderRazorViewToString("PartialPopUp", bookdetails);

            System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();

            sbHtml.Append("Condition 1 Grid");
            sbHtml.Append(RenderRazorViewToString("PartialPopUp", bookdetails).Replace("grid", "grid1"));
            sbHtml.Append("~");
            sbHtml.Append("Condition2");
            sbHtml.Append(RenderRazorViewToString("PartialPopUp", bookdetails).Replace("grid", "grid2"));
            sbHtml.Append("~");
            sbHtml.Append("Condition3  grid");
            sbHtml.Append(RenderRazorViewToString("PartialPopUp", bookdetails).Replace("grid", "grid3"));
            sbHtml.Append("~");
            string str = sbHtml.ToString();
            return Json(sbHtml.ToString(), JsonRequestBehavior.AllowGet);
            //return View(albums);
        }

        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
        public ActionResult GridViewData()
        {

            //var albums = EmployeeRepo.GetEmployees();
            //return View(albums);


            objDBOperations.HandleRequestObjects();
            return View(objDBOperations.BindMyGrid());
            //objDBOperations.BindMyGrid();

        }
        public ActionResult HandleRequestObjects()
        {
            //  var std = objDBOperations.BindMyGrid();
            objDBOperations.HandleRequestObjects();
            return Json(objDBOperations.BindMyGrid(), JsonRequestBehavior.AllowGet);
            //return View();
        }
        // [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public ActionResult FetchData()
        {
            var albums = AlbumRepo.GetAlbums();
            return Json(albums, JsonRequestBehavior.AllowGet);
            //return View(albums);
        }
        [HttpPost]
        public ActionResult Index(int? albumId, string albumName)
        {
            var albums = AlbumRepo.GetAlbums();
            if (Request.Form["btnSubmit"] != null)
            {
                if (!string.IsNullOrEmpty(albumName))
                    albums = albums.Where(a => a.Title.Contains(albumName)).ToList();

                if (albumId.HasValue)
                    albums = albums.Where(a => a.AlbumId == albumId).ToList();

                return PartialView("_grid", albums);
            }
            else if (Request.Form["btnDelete"] != null)
            {

            }
            return PartialView("_grid", albums);
        }


        public ActionResult deleteData(string dataToBeDeleted)
        {
            var albums = AlbumRepo.GetAlbums();
            //if (Request.Form["btnSubmit"] != null)
            //{
            //    if (!string.IsNullOrEmpty(albumName))
            //        albums = albums.Where(a => a.Title.Contains(albumName)).ToList();

            //    if (albumId.HasValue)
            //        albums = albums.Where(a => a.AlbumId == albumId).ToList();

            //    return PartialView("_grid", albums);
            //}
            if (Request.Form["data"] != null)
            {
                String[] dids = Request.Form["data"].Split(new char[] { ',' });
            }
            if (dataToBeDeleted != null)
            {
                String[] dids = dataToBeDeleted.Split(new char[] { ',' });
            }
            return PartialView("_grid", albums);
        }

        public static SelectList PageSizeSelectList()
        {
            var pageSizes = new List<string> { "2", "5", "10", "20", "50", "100" };
            return new SelectList(pageSizes, "Value");
        }
        public ActionResult DDlChangeGrid()
        {
            List<Employee> lstemp = new List<Employee>();
            Employee objemp = new Employee();
            IEnumerable<Employee> ietemp = EmployeeRepo.GetEmployees();
            lstemp = (List<Employee>)ietemp;
            objemp.employeeId = 0;
            objemp.employeeName = "Please Select";
            lstemp.Insert(0, objemp);
            ViewData["empList"] = lstemp;

            return View();
        }
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string id)
        {
            var allCompanies = DataRepository.GetCompanies();
            IEnumerable<Company> filteredCompanies;
            //Check whether the companies should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var nameFilter = Convert.ToString(Request["sSearch_1"]);
                var addressFilter = Convert.ToString(Request["sSearch_2"]);
                var townFilter = Convert.ToString(Request["sSearch_3"]);

                //Optionally check whether the columns are searchable at all 
                var isNameSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isAddressSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isTownSearchable = Convert.ToBoolean(Request["bSearchable_3"]);

                filteredCompanies = DataRepository.GetCompanies()
                   .Where(c => isNameSearchable && c.Name.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isAddressSearchable && c.Address.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isTownSearchable && c.Town.ToLower().Contains(param.sSearch.ToLower()));
            }
            else
            {
                filteredCompanies = allCompanies;
            }

            var isNameSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isAddressSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isTownSortable = Convert.ToBoolean(Request["bSortable_3"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Company, string> orderingFunction = (c => sortColumnIndex == 1 && isNameSortable ? c.Name :
                                                           sortColumnIndex == 2 && isAddressSortable ? c.Address :
                                                           sortColumnIndex == 3 && isTownSortable ? c.Town :
                                                           "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredCompanies = filteredCompanies.OrderBy(orderingFunction);
            else
                filteredCompanies = filteredCompanies.OrderByDescending(orderingFunction);

            var displayedCompanies = filteredCompanies.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedCompanies select new[] { Convert.ToString(c.ID), c.Name, c.Address, c.Town };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allCompanies.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                        JsonRequestBehavior.AllowGet);

        }

        public ActionResult Menu()
        {
            var albums = MenuRepo.GetMenus();
            //ViewData["ParentIds"] = albums.Where(m => m.parentId == 0);
            ViewData["rootMenuIds"] = "3,4";
            HttpCookie _userInfoCookies = new HttpCookie("UserInfo");

            //Setting values inside it
            _userInfoCookies["UserName"] = "Abhijit";
            _userInfoCookies["UserColor"] = "Red";
            _userInfoCookies["Expire"] = "5 Days";
            Response.Cookies.Add(_userInfoCookies);
            return View(albums);
        }

        public ActionResult FilterData(string address)
        {
            address = "Kolkata";
            var emp = EmployeeRepo.GetEmployees();
            var pa = emp.Where(r => r.address == "Kolkata" && r.designation == "PA");
            var a = emp.Where(r => r.address == "Kolkata" && r.designation == "A");
            var sa = emp.Where(r => r.address == "Kolkata" && r.designation == "SA");

            System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
            foreach (Employee item in pa)
            {
                sbHtml.Append("employeeId " + item.employeeId);
                sbHtml.Append(" | employeeName " + item.employeeName);
                sbHtml.Append(" | address " + item.address);
                sbHtml.Append(" | age " + item.age);
                sbHtml.Append("<br/>");
            }
            sbHtml.Append("~");
            foreach (Employee item in a)
            {
                sbHtml.Append("employeeId " + item.employeeId);
                sbHtml.Append(" | employeeName " + item.employeeName);
                sbHtml.Append(" | address " + item.address);
                sbHtml.Append(" | age " + item.age);
                sbHtml.Append("<br/>");
            }
            sbHtml.Append("~");
            foreach (Employee item in sa)
            {
                sbHtml.Append("employeeId " + item.employeeId);
                sbHtml.Append(" | employeeName " + item.employeeName);
                sbHtml.Append(" | address " + item.address);
                sbHtml.Append(" | age " + item.age);
                sbHtml.Append("<br/>");
            }
            sbHtml.Append("~");
            var strhtml = sbHtml.ToString();
            var em = pa + "~" + a + "~" + sa;
            // return List(sbHtml.ToString());
            return Json(strhtml, JsonRequestBehavior.AllowGet);
            //return View();
        }
        public ActionResult ExportToExcel()
        {
            //Export();
            //ExportListToExcel();
            // ExportToExcelx();
            ExportToExcelx();
            return View();
        }
        private void Export()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Number");
            dt.Columns.Add("Text");
            dt.Columns.Add("Currency");
            dt.Columns.Add("Date");
            dt.Columns.Add("Percentage");
            dt.Rows.Add("546", "This is Text", "546", "16/8/2011", "25");
            dt.Rows.Add("5461", "This is again Text", "5462", "20/9/2011", "35");

            //Double dimensional array to keep style name and style
            string[,] styles = { { "number", "0\\.00;" }, { "text", "\\@;" }, { "currency", "\\[\\$\\$\\-\\409\\]\\#\\,\\#\\#0\\.00;" }, { "date", "mm\\-dd\\-yy\\;\\@;" }, { "percent", "0\\.00\\%;" } };

            //Dummy GridView to hold data to be exported in excel
            System.Web.UI.WebControls.GridView gvExport = new System.Web.UI.WebControls.GridView();
            gvExport.AllowPaging = false;
            gvExport.DataSource = dt;
            gvExport.DataBind();

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            int cnt = styles.Length / 2;

            for (int i = 0; i < gvExport.Rows.Count; i++)
            {
                for (int j = 0; j < cnt; j++)
                {
                    //Apply style to each cell
                    gvExport.Rows[i].Cells[j].Attributes.Add("class", styles[j, 0]);
                }
            }

            gvExport.RenderControl(hw);
            StringBuilder style = new StringBuilder();
            style.Append("<style>");
            for (int j = 0; j < cnt; j++)
            {
                style.Append("." + styles[j, 0] + " { mso-number-format:" + styles[j, 1] + " }");
            }

            style.Append("</style>");
            //Response.Clear();
            //Response.Buffer = true;
            ////Response.AddHeader("content-disposition", "attachment;filename=Export.xls"); Response.Charset = "";
            ////Response.AddHeader("Content-Disposition", "attachment; filename=test.xlsx");
            //Response.AddHeader("Content-Disposition", "attachment; filename=report.xls");
            //Response.ContentType = "application/vnd.ms-excel";




            //Response.Write(style.ToString());
            //Response.Output.Write(sw.ToString());
            //Response.Flush();
            //Response.End();







            Response.Clear();
            string attachment = "attachment; filename=Test.xlsx";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.openxmlformats- officedocument.spreadsheetml.sheet";
            // StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            //gridview.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

        }
        public void ExportListToExcel()
        {
            string filename = @"C:\Employees.xlsx";
            List<Employee> listOfEmployees = new List<Employee>();

            listOfEmployees = EmployeeRepo.GetEmployeesList();
            if (CreateExcelFile.CreateExcelDocument(listOfEmployees, filename))
            {
                // We successfully managed to export to an Excel file.
                // Now, get the ASP.Net application to open this Excel file, ready for the user to view.
                Response.ClearContent();
                FileStream fs1 = new FileStream(filename, FileMode.Open, FileAccess.Read);
                byte[] data1 = new byte[fs1.Length];
                fs1.Read(data1, 0, data1.Length);

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", filename));
                Response.BinaryWrite(data1);
                Response.End();
            }
        }

        public void ExportToExcelx()
        {
            //DataSet ds = new DataSet();
            //List<Employee> listOfEmployees = new List<Employee>();

            //listOfEmployees = EmployeeRepo.GetEmployeesList();
            //ds.Tables.Add(CreateExcelFile.ListToDataTable(listOfEmployees));
            //ConvertToExcel(ds);

            string filename = "Employees.xlsx";
            List<Package> packages =
                   new List<Package>
                        { new Package { Company = "Coho Vineyard", Weight = 25.2, 
                              TrackingNumber = 89453312L, 
                              DateOrder = DateTime.Today, HasCompleted = false },
                          new Package { Company = "Lucerne Publishing", Weight = 18.7, 
                              TrackingNumber = 89112755L, 
                              DateOrder = DateTime.Today, HasCompleted = false },
                          new Package { Company = "Wingtip Toys", Weight = 6.0, 
                              TrackingNumber = 299456122L, 
                              DateOrder = DateTime.Today, HasCompleted = false },
                          new Package { Company = "Adventure Works", Weight = 33.8, 
                              TrackingNumber = 4665518773L, 
                              DateOrder =  DateTime.Today.AddDays(-4), 
                              HasCompleted = true },
                          new Package { Company = "Test Works", Weight = 35.8, 
                              TrackingNumber = 4665518774L, 
                              DateOrder =  DateTime.Today.AddDays(-2), 
                              HasCompleted = true },
                          new Package { Company = "Good Works", Weight = 48.8, 
                              TrackingNumber = 4665518775L, 
                              DateOrder =  DateTime.Today.AddDays(-1), HasCompleted = true },

                        };

            List<string> headerNames =
               new List<string> { "Company", 
                   "Weight", "Tracking Number", 
                   "Date Order", "Completed" };

            ExcelFacade excelFacade = new ExcelFacade();
            excelFacade.Create<Package>(filename,
                        packages, "Packages", headerNames);
            Response.ClearContent();
            FileStream fs1 = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] data1 = new byte[fs1.Length];
            fs1.Read(data1, 0, data1.Length);

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", filename));
            Response.BinaryWrite(data1);
            Response.End();


        }
        public void ConvertToExcel(DataSet ds)
        {

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();

            ExcelApp.Application.Workbooks.Add(Type.Missing);

            System.Data.DataTable dt = ds.Tables[0];
            //System.Data.DataTable dt1 = ds.Tables[1];

            Microsoft.Office.Interop.Excel.Worksheet Sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)ExcelApp.Sheets[1];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                Sheet1.Cells[1, i + 1] = dt.Columns[i].ColumnName;
            }
            Sheet1.Cells[dt.Rows.Count + 1, dt.Rows.Count + 1] = "Summary";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Sheet1.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                }
            }
            Sheet1.Cells[dt.Rows.Count + 2, 1] = "Summary";

            Microsoft.Office.Interop.Excel.Range chartRange;
            chartRange = Sheet1.get_Range("a1", "e1");
            chartRange.Font.Bold = true;



            // Microsoft.Office.Interop.Excel.Worksheet Sheet2 = (Microsoft.Office.Interop.Excel.Worksheet)ExcelApp.Sheets[2];
            //for (int i = 0; i < dt1.Columns.Count; i++)
            //{
            //    Sheet2.Cells[1, i + 1] = dt1.Columns[i].ColumnName;
            //}

            //for (int i = 0; i < dt1.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dt1.Columns.Count; j++)
            //    {
            //        Sheet2.Cells[i + 2, j + 1] = dt1.Rows[i][j].ToString();
            //    }
            //}

            //FilePath = "d:\\" + Guid.NewGuid() + ".xlsx";
            //var filename = "Export.xlsx";
            string filename = "Employees.xlsx";
            //string filename = "d:\\" + Guid.NewGuid() + ".xlsx";
            if (filename != string.Empty)
            {
                // ExcelApp.ActiveWorkbook.SaveAs(FilePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel5, null, null, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
                ExcelApp.ActiveWorkbook.SaveAs(filename, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Missing.Value,
    Missing.Value, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
    Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true,
    Missing.Value, Missing.Value, Missing.Value);
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();
                Response.ClearContent();
                FileStream fs1 = new FileStream(filename, FileMode.Open, FileAccess.Read);
                byte[] data1 = new byte[fs1.Length];
                fs1.Read(data1, 0, data1.Length);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", filename));
                Response.BinaryWrite(data1);
                Response.End();
            }

        }



    }
}
