///News create Activ DeActivBtn
$("#NewsActivBtnCreate").on("click", function () {
    ChangActivStatusFromCreateEdit($(this), "#activInput");
})
//////////////////////////////////////////////////////////
///News edit Activ DeActivBtn
////
$("#NewsActivBtnEdite").on("click", function () {

    ChangActivStatusFromCreateEdit($(this), "#activInput");
})
//////////////////////////////////////////////////////////

$(document).ready(function () {
    var Array = [];
    $(".ChecxBoxNews input[type = checkbox]").on("click", function () {
        Array.push(ChangeActivClassFromIndex($(this)));
      
    });
    $("#SaveActiveNewsBtn").click(function ()
    {
        AjaxRequestArray("POST", "/News/IsActive", "json", Array);
        Array = [];
    })
 

});
////////////////////////////////////////////////////////
$(".NewsDeleteBtn").on("click", function ()
{
    var id = $(this).attr("id");
    console.log(id);
    AjaxReturnPartialView("GET", "/News/Delete", id, "#NewsDeleteModal #deletePartialModal")

})



