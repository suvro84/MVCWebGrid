
//$(document).ready(function () {

//    var oTable = $('#myDataTable').dataTable({
//    	"bServerSide": true,
//    	"sAjaxSource": "Home/AjaxHandler", 
//    	"bProcessing": true,
//    	"aoColumns": [
//                        {   "sName": "ID",
//                            "bSearchable": false,
//                            "bSortable": false,
//                            "fnRender": function (oObj) {
//                                return '<a href=\"Company/Details/' + oObj.aData[0] + '\">View</a>';
//                            }
//                        },
//			            { "sName": "COMPANY_NAME" },
//			            { "sName": "ADDRESS" },
//			            { "sName": "TOWN" }
//		            ]
//    });
//});



$(document).ready(function () {
    $('#ddlTitle').change(function () {
        if ($("[id$='ddlTitle']").val() == 0) {
            $("[id$='ddlTitle']").focus();
            alert("Please select");
            $('#container').html(" ");
            return false;
        }
        $('#container').html("<img src='images/loading.gif' alt='Loading!'>");

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: "{ CustomerID: '" + $('#ddlTitle').val() + "'}",
            url: "TestJqueryShowData.aspx/FetchCustomer",
            dataType: "json",
            success: function (data) {
                $('#myDataTable').html(" ");

                var Company = data.d;
                //                $('#myDataTable').append
                //                      ('<p><strong>' + Company.CompanyName + "</strong><br />" +
                //                      Company.Address + "<br />" +
                //                      Company.City + "<br />" +
                //                      Company.Region + "<br />" +
                //                      Company.PostalCode + "<br />" +
                //                      Company.Country + "<br />" +
                //                      Company.Phone + "<br />" +
                //                      Company.Fax + "</p>")
            }
        });
    });



});


     

        






   