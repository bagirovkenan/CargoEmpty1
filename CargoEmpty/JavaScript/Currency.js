///News create Activ DeActivBtn
$("#CurrencyActivBtnCreate").on("click", function () {
    ChangActivStatusFromCreateEdit($(this), "#activInput");
});
//////////////////////////////////////////////////////////

$(document).ready(function () {
    var Array = [];
    $(".CheckBoxCurrency input[type = checkbox]").on("click", function () {
        Array.push(ChangeActivClassFromIndex($(this)));

    });
    $("#SaveActiveCurrencyBtn").click(function () {
        AjaxRequestArray("POST", "/Currency/IsActiv", "json", Array);
        Array = [];
    })


});
/////////////////////////////////////////////////////////////////////////////
$(".CurrencyDetailsBtn").on("click", function () {
    var id = $(this).attr("id");
    console.log(id);
    AjaxReturnPartialView("GET", "/Currency/Edit", id, "#CurrencyDetailsModalLong #CurrencyeditPartialModal")

})

/////////////////////////////////////////////////////////////////////////////
$(".CurrencyDeleteBtn").on("click", function () {
    var id = $(this).attr("id");
    console.log(id);
    AjaxReturnPartialView("GET", "/Currency/Delete", id, "#CurrencyDeleteModal #CurrencydeletePartialModal")

})

$("#CurrencyeditPartialModal").on("click", "#CurrencyActivBtnEdit", function () {
    ChangActivStatusFromCreateEdit($(this), "#CurrencyeditPartialModal #activInput");
})