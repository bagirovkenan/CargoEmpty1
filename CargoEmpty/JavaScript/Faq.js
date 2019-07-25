///////////////////creaet change activ status
$("#FaqActivBtnCreate").on("click", function () {
    ChangActivStatusFromCreateEdit($(this), "#activInput")
});
/////////////////// etite change activ status
$("#FaqActivBtnEdite").on("click", function () {
    ChangActivStatusFromCreateEdit($(this), "#activInputEdite")
})
/////////////////// show delete partial view
$(".FaqDeleteBtn").on("click", function () {
    var id = $(this).attr("id");
    AjaxReturnPartialView("GET", "/Faq/Delete", id, "#FaqDeleteModal #deletePartialModal")
});
//////////////////////////////change and save activ status from index
$(document).ready(function () {
    var Array = [];
    $(".CheckBoxFaqs input[type=checkbox]").on("click", function () {
        Array.push(ChangeActivClassFromIndex($(this)));
    });

    $("#SaveActiveFaqBtn").click(function () {
        AjaxRequestArray("POST", "/Faq/IsActiv", "json", Array);
        Array = [];
    });
    

});