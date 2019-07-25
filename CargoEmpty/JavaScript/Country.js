///News create Activ DeActivBtn
$("#CountryActivBtnCreate").on("click", function () {
    ChangActivStatusFromCreateEdit($(this), "#activInput");
});
//////////////////////////////////////////////////////////

$(document).ready(function () {
    var Array = [];
    $(".CheckBoxCountry input[type = checkbox]").on("click", function () {
        Array.push(ChangeActivClassFromIndex($(this)));

    });
    $("#SaveActiveCountryBtn").click(function () {
        AjaxRequestArray("POST", "/Cauntry/IsActiv", "json", Array);
        Array = [];
    })


});
/////////////////////////////////////////////////////////////////////////////
$(".CountryDetailsBtn").on("click", function () {
    var id = $(this).attr("id");
    console.log(id);
    AjaxReturnPartialView("GET", "/Cauntry/Edit", id, "#CountryDetailsModalLong #CountryeditPartialModal")

})

/////////////////////////////////////////////////////////////////////////////
$(".CountryDeleteBtn").on("click", function () {
    var id = $(this).attr("id");
    console.log(id);
    AjaxReturnPartialView("GET", "/Cauntry/Delete", id, "#CountryDeleteModal #CountrydeletePartialModal")

})

$("#CountryeditPartialModal").on("click","#CountryActivBtnEdit" ,function () {
    ChangActivStatusFromCreateEdit($(this), "#CountryeditPartialModal #activInput");
})

