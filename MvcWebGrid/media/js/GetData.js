
//function () {
//    $("#btnFetchData").click(function () {
//        alert('hi');
//        $.ajax({
//            type: "POST",
//            url: "Home/GetData",
//            data: "{ 'address':'" + $('#txtAddress').val() + "'}",
//            beforeSend: function () {
//                // Show your spinner
//                $("#dvAjax").css('display', 'block');
//                loadingImg();
//            },
//            complete: function () {
//                // Hide your spinner
//                $("#dvAjax").css('display', 'none');
//            },
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            success: function (response) {
//                alert(response);
//                for (var i = 0; i < response.length; i++) {
//                    alert(response[i].book.BookID);
//                    alert(response[i].order.PaymentMode);
//                }
//            },
//            failure: function (errMsg) {
//                $('#errorMessage').text(errMsg); //errorMessage is id of the div
//            }
//        });
//    });
//}
//function loadingImg() {
//    if (document.getElementById) {
//        var progress = document.getElementById('progress');
//        var blur = document.getElementById('blur');
//        progress.style.width = '300px';
//        progress.style.height = '30px';
//        blur.style.height = document.documentElement.clientHeight;
//        progress.style.top = document.documentElement.clientHeight / 3 - progress.style.height.replace('px', '') / 2 + 'px';
//        progress.style.left = document.body.offsetWidth / 2 - progress.style.width.replace('px', '') / 2 + 'px';
//    }
//}