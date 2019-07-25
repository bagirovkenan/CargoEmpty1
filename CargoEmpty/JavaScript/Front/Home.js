//$("#CountryId").change(function () {
//    console.log($(this).val())
//})
function calculatePrice()
{
    $("input[type=number].calcInput").each(function () {
        var a = $(this).val()
        if (a != 0)
        {

            $(this).css("background-color", "white");
           
        

            var jsonObject =
            {
                CountryId: $("#CountryId").val(),
                BundelCount: $("#BundelCount").val(),
                BundleLenght: $("#BundleLenght").val(),
                BundleWidth: $("#BundleWidth").val(),
                BundleHeight: $("#BundleHeight").val(),
                BundleWeight: $("#BundleWeight").val(),

            }


            $.ajax({
                type: "POST",
                url: "/Home/Calculate",
                data: { model: jsonObject },
                success: function (response) {

                    $("#calculatorResultUSD").text(response.responseUSD);
                    $("#calculatorResultAZN").text(response.responseAZN);

                },
                error: function (response) {
                    $("#calculatorResult").text("0.00");
                    alert("Xeta bas verdi Zehmet olmasa tekrar  yoxlayin");;  // 
                }

            })
        }
       
        else
        {
            $(this).css("background-color", "rgba(255, 255, 255, 0.22)");
        }
    });
    //console.log(jsonObject);
    
}

