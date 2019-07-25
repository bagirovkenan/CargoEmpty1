///News create Activ DeActivBtn
$("#TarifActivBtnCreate").on("click", function () {
    ChangActivStatusFromCreateEdit($(this), "#activInput");
});
//////////////////////////////////////////////////////////
///News create Activ DeActivBtn
//$("#TarifActivBtnEdit").on("click", function () {
//    ChangActivStatusFromCreateEdit($(this), "#activInput");
//});
//////////////////////////////////////////////////////////

$(document).ready(function () {
    var Array = [];
    $(".CheckBoxTarif input[type = checkbox]").on("click", function () {
        Array.push(ChangeActivClassFromIndex($(this)));

    });
    $("#SaveActiveTarifBtn").click(function () {
        AjaxRequestArray("POST", "/Tarif/IsActiv", "json", Array);
        Array = [];
    })


});
/////////////////////////////////////////////////////////////////////////////
$(".TarifDetailsBtn").on("click", function () {
    var id = $(this).attr("id");
    console.log(id);
    AjaxReturnPartialView("GET", "/Tarif/Edit", id, "#TarifDetailsModalLong #TarifeditPartialModal")

})

/////////////////////////////////////////////////////////////////////////////
$(".TarifDeleteBtn").on("click", function () {
    var id = $(this).attr("id");
    console.log(id);
    AjaxReturnPartialView("GET", "/Tarif/Delete", id, "#TarifDeleteModal #TarifdeletePartialModal")

})
