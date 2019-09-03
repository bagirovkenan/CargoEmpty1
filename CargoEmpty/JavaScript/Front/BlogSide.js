//////////////////////////////////////////////////////
$("#CategoryMenyuButton").click(function () {
    $(".categoryTitetelColDiv").toggle(500);
})

/////////////////////////////////////////////////////
$(".CategoryTitelColDiv").click(function () {
    $(this).parent().children()[0].innerHtml
    $(".categoryTitetelColDiv").show(500);
})

////////////////////////////////////////////////////////////////
//contact page send email
$(".formSubmitBtnIndexContact").click(function () {
    var UserMessage = {
        FullName: $(".FullName").val(),
        Subject: $(".Company").val(),
        Email: $(".Email").val(),
        Phone: $(".Phone").val(),
        Message: $(".Message").val(),

    }
    console.log(UserMessage)
    $.ajax({
        type: "POST",
        url: "/Message/GuestMesage",
        data: { Message: UserMessage },
        succes: function () {
            alert("Gonderildi")
        },
        error: function () {
            alert("Gonderilmedi")
        }
    })

});
///////////////////////////////////////////////////////////////////////////////
///create btn click
$(".AddMessagebtn").click(function () {
    var id = $(this).attr("data-id");
    var Link = $(this).attr("data-link");
    AjaxReturnPartialView("GET", Link, id, ".UserMessagLeftDiv");
    $(".UserIndexMessageMenuLiClass").css({ "background-color": " #f6f6f6", "color": "#808080" });
});

///////////////////////////////////////////////////////////////////////////////

/////Message Li click
$(".UserIndexMessageMenuLiClass").click(function () {
    var id = $(this).attr("data-id");
    var Link = $(this).attr("data-link");
    $(".UserIndexMessageMenuLiClass").css({ "background-color": " #f6f6f6", "color": "#808080" });
    $(this).css({ "background-color": "#eb0028", "color": "#f6f6f6" });

    AjaxReturnPartialView("GET", Link, id, ".UserMessagLeftDiv");
    /////////////////////////////  
});
////message read

$(".UserMessagLeftDiv").on("click", ".MessageReadButton", function () {
    var id = $(this).attr("data-id");
    AjaxReturnPartialView("POST", "/Message/MessageUserRead", id, ".UserMessagLeftDiv");
    //$.ajax({
    //    url: "/Message/MsgRead",
    //    type: "GET",
    //    data: { id: id },
    //    succes: function (res) {
    //        if (res.sucssec == true) {
    //            $(".UnreadMEssageCount").text("");
    //            $(".UnreadMEssageCount").text("(" + res.UnReadCount+ ")");
    //        }          
    //    }
    //})
});

$(".UserMessagLeftDiv").on("click", ".MessageDeleteButton", function () {
    var id = $(this).attr("data-id");
    $.ajax({
        type: "POST",
        url: "/Message/MessageUserDelete",
        dataType: "json",
        data: { id: id },
        success: function (data) {
            if (data.success == true) { // if true (1)
                setTimeout(function () {// wait for 5 secs(2)
                    location.reload(); // then reload the page.(3)
                }, 500);
            }
        }

    })
});


