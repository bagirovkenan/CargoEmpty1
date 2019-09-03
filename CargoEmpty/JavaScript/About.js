///////////////////creaet change activ status
$("#AboutActivBtnCreate").on("click", function () {
    ChangActivStatusFromCreateEdit($(this), "#activInput")
});
/////////////////// etite change activ status
$("#AboutActivBtnEdite").on("click", function () {
    ChangActivStatusFromCreateEdit($(this), "#activInputEdite")
})
/////////////////// show delete partial view
$(".AboutDeleteBtn").on("click", function () {
    var id = $(this).attr("id");
    console.log(id);
    AjaxReturnPartialView("GET", "/About/Delete", id, "#AboutDeleteModal #AboutDeletePartialModal")
});
//////////////////////////////change and save activ status from index
$(document).ready(function () {
    var Array = [];
    $(".ChecxBoxAbout input[type=checkbox]").on("click", function () {
        Array.push(ChangeActivClassFromIndex($(this)));
    });

    $("#SaveActiveAboutBtn").click(function () {
        AjaxRequestArray("POST", "/About/IsActiv", "json", Array);
        Array = [];
    });


});

////////////////////////////////////////////////////////////////
//messaje java script 
///create btn click
$(".AddMessagebtn").click(function () {
    var Link = $(this).attr("data-link");
    var id = $(this).attr("data-id");
    $(".IndexMessageMenuLiClass").css({ "background-color": " #f6f6f6", "color": "#808080" });
    AjaxReturnPartialView("GET", Link, id, ".MessagLeftDiv");   
});

///////////////////////////////////////////////////////////////////////////////

/////Message Li click
$(".IndexMessageMenuLiClass").click(function () {
    var id = $(this).attr("data-id");
    var Link = $(this).attr("data-link");
    $(".IndexMessageMenuLiClass").css({ "background-color": " #f6f6f6", "color": "#808080" });
    $(this).css({ "background-color": "#eb0028", "color": "#f6f6f6" });

    AjaxReturnPartialView("GET", Link, id, ".MessagLeftDiv");
    /////////////////////////////  
});
////message read

$(".MessagLeftDiv").on("click", ".MessageReadButton", function () {
    var id = $(this).attr("data-id");
    AjaxReturnPartialView("POST", "/Message/MessageAdminRead", id, ".MessagLeftDiv");
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
///////////////////////////////Search User
$(".MessagLeftDiv").on("keyup", "#AdminCreateMessageToInputId", function () {
    $(".MessgeToDinamikChengeUser").html("");
    var id = $(this).val();
    
    $.ajax({
        type: "POST",
        url: "/Search/JsonUserSearch",
        dataType: "json",
        data: { id: id },
        success: function (data) {
            if (data != null && data.length > 0) { // if true (1)\

                for (var i = 0; i < data.length; i++) {
                    var btn = '<button type="button" style="display:block;" data-id="' + data[i].Id + '" class="btn btn-success" id="CreateMessageUserNameBtnId">' + data[i].FirstName + " " + data[i].LastName + '</button>'                  
                    $(".MessgeToDinamikChengeUser").append(btn)
                }

            }
        },
        error: function () {
            alert("Xeta Bas Verdi")
        }

    })
});

$(".MessagLeftDiv").on("click", "#CreateMessageUserNameBtnId", function () {
    var id = $(this).attr("data-id");
    var text = $(this).text(); 
    $("#AdminCreateMessageToInputId").val(text);
    var input = '<input type="text" name="ToMesssageUserDbId" value="' + id + '" />' 
    $(".MessgeToDinamikChengeUser").html("");
    $(".MessgeToDinamikChengeUser").append(input);
});
///////////////////////////////
$(".MessagLeftDiv").on("click", ".MessageDeleteButton", function () {
    var id = $(this).attr("data-id");
    $.ajax({
        type: "POST",
        url: "/Message/MessageAdminDelete",
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