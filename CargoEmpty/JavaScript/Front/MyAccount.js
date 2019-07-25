
//$("li").each(function (index) {
//    console.log(index + ": " + $(this).text());
//});

$(document).ready(function () {
    $(".BottomMainDiv .CountryHeaderUl li:first").children(".countryLink").css({ "background-color": "red", "color": "white" });


    $(".ActivHeader").on("click", function () {
        $(this).children(".countryLink").css("background-color", "red");
        $(".BottomMainDiv .countryLink").each(function () {
            $(this).css({ "background-color": "#f6f6f6", "color": "black" });

        });

        $(this).children(".countryLink").css({ "background-color": "red", "color": "white" });
        var dataIdClicked = $(this).attr("data-id");

        $(".BottomMainDiv .LeftBlogContentDiv").each(function () {
            var changeElementDataId = $(this).attr("data-id")
            if (dataIdClicked == changeElementDataId) {
                $(this).attr("id", "ActivContent")
            }
            else {
                $(this).attr("id", "DeActivContent")
            }
        });
    });


    $("#accauntsettingUl").on("click", ".PassivAccountLink", function () {
        $(".activeAccountLink").addClass("PassivAccountLink");
        $(".activeAccountLink").removeClass("activeAccountLink");
        $(this).removeClass("PassivAccountLink");
        $(this).addClass("activeAccountLink");

        $("#MyAccountAdress").css("display", "none");
        $("#myAccountActionsHiddenDiv").css("display", "block");
    })


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////Decleration Js

    ////////////////when checked checkbox enable disable order name in my account decleration modal
    //$(".DeclerationFromMainDiv #OrdesName").attr("disabled", "disabled");  
    //$(".DeclerationFromMainDiv").on("click", "#declerationCheckedInput", function () {
     
    //    var status = $(".DeclerationFromMainDiv #OrdesName").attr("disabled");
    //    if (status == "disabled") {
    //        $(".DeclerationFromMainDiv #OrdesName").attr("disabled", false);
    //        $(".DeclerationFromMainDiv #isSelected").val("true");
    //    }
    //    else {
    //        $(".DeclerationFromMainDiv #OrdesName").attr("disabled", "disabled");
    //        $(".DeclerationFromMainDiv #isSelected").val("false");
    //        $("#reset").click();
    //        $("#DeclerationOrderDateDiv #DeclerationOrderDateInput").attr("type","datetime-local")
           
    //    }
    //})
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////change currency when selecting to country name
    $(".DeclerationFromMainDiv").on("change", "#DeclerationCountrySelect", function () {

        var CurrencyName = $("#DeclerationCountrySelect  option:selected").attr("data-id");
        $("#DeclerationValyutaDiv #DeclerationOrderOrderValyuta").text(CurrencyName);


        //var a = $(this).find(':selected').attr('data-id');
        //console.log('Clicked option value => ' + $(this).val());
        //console.log(':select & $(this) => ' + $(':selected', this).data('id'));
        //console.log(':select & this => ' + $(':selected', this).data('id'));
        //console.log('option:select & this => ' + $('option:selected', this).data('id'));
    })

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////add order list when selecting to country name in my account decleration modal
   // $(".DeclerationFromMainDiv").on("change", "#DeclerationCountrySelect", function () {
   //     var status = $(".DeclerationFromMainDiv #isSelected").val();
   //     var id = $(this).val();
   //     if (status == "true") {
   //         $.ajax({
   //             type: "POST",
   //             url: "/Declerations/CountryOrders",
   //             dataType: "json",
   //             data: { id:id },
   //             success: function (response) {
   //                 if (response != null && response.length > 0)
   //                 {
   //                     $(".DeclerationFromMainDiv #DeclerationOrdersDiv #OrdesName").html(" ");
   //                     for (var i = 0; i < response.length; i++)
   //                     {                           
   //                         var option = '<option class="OrderNameClasse" value="' + response[i].Id + '">' + response[i].OrderName + '</option>'
   //                         $(".DeclerationFromMainDiv #DeclerationOrdersDiv #OrdesName").append(option);
   //                         if (response.length == 1)
   //                         {
   //                             $(".DeclerationFromMainDiv #DeclerationOrdersDiv #OrdesName").change();
                               
   //                         }
   //                     }
   //                 }
   //                 else
   //                 {
   //                     $(".DeclerationFromMainDiv #DeclerationOrdersDiv #OrdesName").html(" ");
   //                     alert("Bu Olkeden Tesdiqlenmeyen Sifarisiniz Yoxdur")
   //                 }

                  

   //             }
   //         })                
   //     }       
   //})
    ///////show order information   when selecting ordername in my account decleration modal
    //$(".DeclerationFromMainDiv").on("change", "#OrdesName", function () {

    //    var id = $(this).val();
    //    console.log(id);
    //    $.ajax({
    //        type: "POST",
    //        url: "/Declerations/OrderInformation",
    //        dataType: "json",
    //        data: { id: id },
    //        success: function (response) {
    //            if (response.success) {

                    
    //                var Date = '<input type="text" name="DecDate"  class="form-control" id = "DeclerationOrderDateInput" value="' + response.OrderDate + '"  required/>'
                    
    //                $("#DeclerationOrderDateDiv").html(" ");
    //                $("#DeclerationOrderDateDiv").append(Date);

    //                $("#DeclerationOrderCountDiv #DeclerationOrderCountInput").val(response.OrderCount);
    //                $("#DeclerationOrderDateDiv #DeclerationOrderDateInput").val(response.OrderDate);
    //                $("#DeclerationOrderPriceDiv #DeclerationOrderPriceInput").val(response.OrderPrice);
    //                $("#DeclerationComentDiv #DeclerationComentTextArea").text(response.OrderComent);
                   
    //                //$("#DeclerationValyutaDiv #DeclerationOrderOrderValyuta").text(response.OrderCurrency);
                    
    //                console.log(now.getMonth() + 1)

                    
    //            }
    //            else {
    //                alert(response.responseText);
    //            }
    //        },
    //        error: function (){
    //            alert("Bilinmeyen Xeta ");
    //        }
    //    })
    //})


   
})