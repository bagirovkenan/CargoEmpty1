
$(".DecIndexTableBody").on("click", ".DecEditBtn" ,function () {
    var id = $(this).attr("data-id");
    AjaxReturnPartialView("GET", "/Declerations/Edite", id, ".AdminDecIndexModalBody")
    $("#DecIndexModalBtn").click();
});
////////
$(".decStatusIdBtn").click(function () {
    $(".decStatusIdInput").val($(this).attr("data-id"))
});

$(".DecIndexCountrySelect").change(function () {
    var link = $(this).attr("data-action");
    var countryId = $(this).val();
    var Stid = $(".decStatusIdInput").val();
    var id = {
        CountryId: countryId,
        StatusId: Stid,
    }

    AjaxReturnPartialView("POST", link, id, ".DecIndexTableBody")

});
////////////////
$(".decStatusIdBtn").click(function () {
    var link = "/Declerations/SelectStatuse";
    var countryId = $(".DecIndexCountrySelect").val();
    var Stid = $(this).attr("data-id");

    var id = {
        CountryId: countryId,
        StatusId: Stid,
    }
    $(".decStatusIdBtn").css({ "background-color": "#FFC107", "color": "black" });
    $(this).css({ "background-color": "#ff0000", "color": "white" });
    AjaxReturnPartialView("POST", link, id, ".DecIndexTableBody")
});