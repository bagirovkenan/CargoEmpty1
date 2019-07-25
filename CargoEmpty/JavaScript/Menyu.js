$(document).ready(function () {
    var Array = [];
    $(".CheckBoxenMenyu input[type = checkbox]").on("click", function () {
        Array.push(ChangeActivClassFromIndex($(this)));

    });
    $("#SaveActiveMenyuBtn").click(function () {
        AjaxRequestArray("POST", "/Menyu/IsActiv", "json", Array);
        Array = [];
    })


});
/////////////////////////////////////////////////////////////////////////////
$(".MenyuDetailsBtn").on("click", function () {
    var id = $(this).attr("id");
    console.log(id);
    AjaxReturnPartialView("GET", "/Menyu/Edit", id, "#MenyuDetailsModalLong #MenyueditPartialModal")

})

/////////////////////////////////////////////////////////////////////////////
$(".MenyuDeleteBtn").on("click", function () {
    var id = $(this).attr("id");
    console.log(id);
    AjaxReturnPartialView("GET", "/Menyu/Delete", id, "#MenyuDeleteModal #MenyudeletePartialModal")

})
