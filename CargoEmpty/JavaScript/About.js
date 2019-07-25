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