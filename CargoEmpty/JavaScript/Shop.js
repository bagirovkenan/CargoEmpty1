$("#img").click(function () {
    $("#fl").trigger("click");
})
////////////////////////////////////////////////////////////////////////////////
$("#ShopActivBtnEdite").click(function () {
    ChangActivStatusFromCreateEdit($(this), "#activInputEdite");
});
////////////////////////////////////////////////////////////////////////////////
$("#ShopActivBtnCreate").click(function () {
    ChangActivStatusFromCreateEdit($(this), "#activInputCreate");
});
////////////////////////////////////////////////////////////////////////////////
$(document).ready(function () {
    var Array = [];
    $(".CheckBoxShops input[type=checkbox").on("click", function () {
        Array.push(ChangeActivClassFromIndex($(this)));
        console.log(Array);
    })

    $("#SaveActiveShopBtn").click(function () {
        AjaxRequestArray("POST", "/Shops/IsActiv", "json", Array);
        Array = [];
    })
});

/////////////////// show delete partial view
$(".ShopDeleteBtn").on("click", function () {
    var id = $(this).attr("id");
    AjaxReturnPartialView("GET", "/Shops/Delete", id, "#ShopDeleteModal #ShopDeletePartialModal")
});
//////////////////////////////change and save activ status from index