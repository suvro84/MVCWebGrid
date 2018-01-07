<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestJqueryShowData.aspx.cs"
    Inherits="TestJqueryShowData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" src="script/jquery-1.3.2.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $('#ddlService').change(function() {
                if ($("[id$='ddlService']").val() == 0) {
                    $("[id$='ddlService']").focus();
                    alert("Please select");
                    $('#CustomerDetails').html(" ");
                    return false;
                }
                $('#CustomerDetails').html("<img src='Pictures/loading.gif' alt='Loading!'>");
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: "{ CustomerID: '" + $('#ddlService').val() + "'}",
                    url: "TestJqueryShowData.aspx/FetchCustomer",
                    dataType: "json",
                    success: function(data) {
                        $('#CustomerDetails').html(" ");

                        var Company = data.d;
                        $('#CustomerDetails').append
              ('<p><strong>' + Company.CompanyName + "</strong><br />" +
              Company.Address + "<br />" +
              Company.City + "<br />" +
              Company.Region + "<br />" +
              Company.PostalCode + "<br />" +
              Company.Country + "<br />" +
              Company.Phone + "<br />" +
              Company.Fax + "</p>")
                    }
                });
            });
        });
    </script>

    <%--<script type="text/javascript">
        $(document).ready(function() {
            // $("#tbUsername").blur(function(event) {
            $("#btnClick").click(function() {

                if ($("[id$='txtName']").val().length == 0) {
                    $("[id$='txtName']").focus();
                    alert("Please enter  name first.");
                    return false;
                }
                if ($("[id$='txtEmail']").val().length == 0) {
                    $("[id$='txtEmail']").focus();
                    alert("Please enter Email first.");
                    return false;
                }


                $.ajax({
                    type: "POST",
                    url: "testJqueryInsert.aspx/IsUserAvailable",
                    // data: "{'username': '" + $('#txtName').val() + "'}",
                    data: "{ 'username':'" + $('#txtName').val() + "', 'EmailID': '" + $('#txtEmail').val() + "'}",

                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        $('#valid').html("<img src='images/loading.gif' alt='Loading!'>");
                      
                        AjaxSucceeded(msg);
                       
                    },
                    error: AjaxFailed
                });
            });
        });
        function AjaxSucceeded(result) {
            alert(result)
            // if (result == true)
            alert(result[0]);
            if (result != null) {
                // $('#valid').html("<img src='images/available.gif' alt='Username available!'>");
                alert('success');
            }
            else {
                // $('#valid').html("<img src='images/taken.gif' alt='Username taken!'>");
                alert('Failure');
            }
        }
        function AjaxFailed(result) {
            alert(result.status + ' ' + result.statusText);
        }    
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    
      <input id="hdcurrentRowId" type="hidden" value="0" runat="server" />
    <div>
        <label>
            Name</label>
        <asp:DropDownList ID="ddlService" runat="server" Style="height: 22px">
        </asp:DropDownList>
        <div id="CustomerDetails">
        </div>
        <asp:GridView ID="gridTest" DataKeyNames="service_id" ShowFooter="true" runat="server"
            AutoGenerateColumns="false" >
            <Columns>
                <asp:TemplateField HeaderText="service_id">
                    <ItemTemplate>
                        <asp:Literal ID="ltservice_id" Text='<%#Eval("service_id")%>' runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
              
                 <asp:TemplateField HeaderText="emp_id">
                    <ItemTemplate>
                        <asp:Literal ID="ltservice_name" Text='<%#Eval("service_name")%>' runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
        
        <asp:Button ID="btn_UP" runat="server" Text="UP" />
        <asp:Button ID="btn_dwn" runat="server" Text="DOWN" onclick="btn_dwn_Click" />
    </div>
    </form>
</body>
</html>
