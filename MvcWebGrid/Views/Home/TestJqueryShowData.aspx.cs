using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Collections;
using System.Data;
using System.Reflection;

public partial class TestJqueryShowData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populateServiceddl();
            if (ViewState["Icount"] == null)
            {
                ViewState["Icount"] = 0;
            }
        }
    }

    public void populateServiceddl()
    {


        //GCommon<Service> obj = new DataManipulationClass().populateService();
        List<Service> obj = new DataManipulationClass().populateService_list();
        DataTable dt = GenericListToDataTable(obj);
        ViewState["dtdata1"] = dt;
        Session["list"] = obj;
        // this.gridTest.DataSource = dt;
        this.gridTest.DataSource = obj;
        this.gridTest.DataBind();



        if (obj.Count > 0)
        {
            IEnumerator<Service> ie = obj.GetEnumerator();

            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "Please Select";
            ddlService.Items.Insert(0, li);

            while (ie.MoveNext())
            {
                li = new ListItem();
                li.Text = ie.Current.service_name.ToString();
                li.Value = ie.Current.service_id.ToString();
                ddlService.Items.Add(li);

            }
        }


    }
    #region GenericListToDataTable
    /// <summary>
    /// Converts a generic List<> into a DataTable.
    /// </summary>
    /// <param name="list"></param>
    /// <returns>DataTable</returns>
    public static DataTable GenericListToDataTable(object list)
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
    #endregion

    private void Swap(int index1, int index2, string opt)
    {
        //If the indexes are equal or one of them is illegal, return.
        //if (index1 == index2 || index1 < 0 || index2 < 0
        //    || index1 >= _bindSrc.Count || index2 >= _bindSrc.Count)
        //    return;

        //Make sure index1 <= index2
        if (index1 > index2)
        {
            int index = index1;
            index1 = index2;
            index2 = index;
        }
        //Create two rows with the same values.
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["dtdata1"];
        DataRow row1 = dt.NewRow();
        DataRow row2 = dt.NewRow();
        row1.ItemArray = dt.Rows[index1].ItemArray;
        row2.ItemArray = dt.Rows[index2].ItemArray;

        //Remove the old rows.
        dt.Rows.RemoveAt(index2);
        dt.Rows.RemoveAt(index1);

        //Add the new rows.
        dt.Rows.InsertAt(row2, index1);
        dt.Rows.InsertAt(row1, index2);
        gridTest.DataSource = dt;
        gridTest.DataBind();
        if (opt == "dwn")
        {
            //gridTest.SelectedRow(index2);
            //gridTest.SelectedRow = index2;
            //gridTest.Selection.UnselectRow(index1);
        }
        else
        {
            //gridTest.Selection.SelectRow(index1);
            //gridTest.Selection.UnselectRow(index2);
        }



    }

    protected void btn_dwn_Click(object sender, EventArgs e)
    {
        //Swap(Convert.ToInt32(ViewState["Icount"]), Convert.ToInt32(ViewState["Icount"]) + 1, "dwn");
        //ViewState["Icount"] = Convert.ToInt32(ViewState["Icount"]) + 1;
        List<Service> obj = (List<Service>)HttpContext.Current.Session["list"];
       // Swap(Convert.ToInt32(Convert.ToInt32(hdcurrentRowId.Value)), Convert.ToInt32(hdcurrentRowId.Value) + 1, "dwn");
        Move1(obj, Convert.ToInt32(hdcurrentRowId.Value), Convert.ToInt32(hdcurrentRowId.Value) + 1);


    }

    public void Move<T>(List<T> list, int oldIndex, int newIndex)
    {
        // List<Service> obj = new List<Service>();
        List<Service> obj = (List<Service>)HttpContext.Current.Session["list"];

        //Service aux = list[newIndex];
        //list[newIndex] = list[oldIndex];
        //list[oldIndex] = aux;

        T item = list[oldIndex];
        list.RemoveAt(oldIndex);
        list.Insert(newIndex, item);

    }
    public void Move1(List<Service> list, int oldIndex, int newIndex)
    {
        // List<Service> obj = new List<Service>();


        //Service aux = list[newIndex];
        //list[newIndex] = list[oldIndex];
        //list[oldIndex] = aux;

        Service item = list[oldIndex];
        list.RemoveAt(oldIndex);
        list.Insert(newIndex, item);

        this.gridTest.DataSource = list;
        this.gridTest.DataBind();


    }


    //protected void GridLookup_ValueChanged(object sender, EventArgs e)
    //{
    //    Response.Write("hi");

    //}

    //protected void GridLookup_ButtonClick(object source, DevExpress.Web.ASPxEditors.ButtonEditClickEventArgs e)
    //{
    //    Response.Write("hoo");
    //}
    //protected void GridLookup_CustomJSProperties(object sender, DevExpress.Web.ASPxClasses.CustomJSPropertiesEventArgs e)
    //{
    //    Response.Write("hkkkk");
    //}
    //protected void lkpCurrency_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string s = lkpCurrency.SelectedItem.GetValue("TagName").ToString();
    //}
    //protected void btn_dwn_Click(object sender, EventArgs e)
    //{
    //    //Swap(Convert.ToInt32(ViewState["Icount"]), Convert.ToInt32(ViewState["Icount"]) + 1, "dwn");
    //    ViewState["Icount"] = Convert.ToInt32(ViewState["Icount"]) + 1;
    //}

    //public static Company FetchCustomer(string CustomerID)
    //{
    //    Company c = new Company();
    //    string connect = "Server=MyServer;Database=Northwind;Trusted_Connection=True";
    //    string query = "SELECT CompanyName, Address, City, Region, PostalCode," +
    //              "Country, Phone, Fax FROM Customers WHERE CustomerID = @CustomerID";
    //    if (CustomerID != null && CustomerID.Length == 5)
    //    {
    //        using (SqlConnection conn = new SqlConnection(connect))
    //        {
    //            using (SqlCommand cmd = new SqlCommand(query, conn))
    //            {
    //                cmd.Parameters.AddWithValue("CustomerID", CustomerID);
    //                conn.Open();
    //                SqlDataReader rdr = cmd.ExecuteReader();
    //                if (rdr.HasRows)
    //                {
    //                    while (rdr.Read())
    //                    {
    //                        c.CompanyName = rdr["CompanyName"].ToString();
    //                        c.Address = rdr["Address"].ToString();
    //                        c.City = rdr["City"].ToString();
    //                        c.Region = rdr["Region"].ToString();
    //                        c.PostalCode = rdr["PostalCode"].ToString();
    //                        c.Country = rdr["Country"].ToString();
    //                        c.Phone = rdr["Phone"].ToString();
    //                        c.Fax = rdr["Fax"].ToString();
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    return c;
    //}
    [WebMethod]

    //public static Company FetchCustomer(string CustomerID)
    //{
    //    Company c = new Company();
    //    //System.Collections.Hashtable c = new System.Collections.Hashtable();
    //    if (CustomerID != null)
    //    {

    //        c.CompanyName = "xyz";
    //        c.Address = "address";
    //        c.City = "City";
    //        c.Region = "Region";
    //        c.PostalCode = "PostalCode";
    //        c.Country = "Country";
    //        c.Phone = "Phone";
    //        c.Fax = "Fax";
    //    }




    //    return c;
    // }

    public static Hashtable FetchCustomer(string CustomerID)
    {
        //Company c = new Company();
        System.Collections.Hashtable c = new System.Collections.Hashtable();
        if (CustomerID != null)
        {
            c.Add("CompanyName", "xyz");
            c.Add("Address", "Address");
            c.Add("City", "City");
            c.Add("Region", "Region");
            c.Add("PostalCode", "PostalCode");
            c.Add("Country", "Country");
            c.Add("Phone", "Phone");
            c.Add("Fax", "Fax");


        }




        return c;
    }

}
