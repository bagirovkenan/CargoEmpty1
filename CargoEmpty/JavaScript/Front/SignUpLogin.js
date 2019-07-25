/////////////////////////////////Sign Up//////////////////////////////////////////////////////////////////////////
$("#SignUpSubmitButton").click(function () {
    var a = $(this).prop('type');
    var b = $("#ConditionInput").val();

    if (a == "button")
    {
        $("#ConditionModalBtn").click();
    }
    else
    {
        $(this).prop('type', "submit");
    }
    $("#CondtionSucces").click(function () {

        $("#ConditionInput").val("true");
        $("#close").click();
        $("#SignUpSubmitButton").prop("type", "submit");
        $("#SignUpSubmitButton").trigger("click");
        $("#SignUpSubmitButton").prop("type", "button");


    });

});

////////////////////////Edit USer///////////////////////////////////////////////////////////////////////////////////
$("#ChangePassword").on("click", function () {
    var display = $(".chsngePAswwordHiddendiv").css("display");
    if (display == "none")
    {
        $(".chsngePAswwordHiddendiv").css("display", "block");
        $(this).text("Parolu Deyisme")
    }
    else
    {
        $(".chsngePAswwordHiddendiv").css("display", "none");
        $(this).text("Parolu Deyis")
    }
});

//animate({
//    height: 'toggle'