$(document).ready(function () {

    $("#MyOrdersBtn").click(function () {

        $(this).css("background-color", "#dc3545");
        $("#MyDecsBtn").css("background-color", "#007bff");

        $("#MyOrdersIndexTabelDiv").css("display", "block");
        $("#MyDecTabelMainDiv").css("display", "none");
    });

    $("#MyDecsBtn").click(function () {

        $(this).css("background-color", "#dc3545");
        $("#MyOrdersBtn").css("background-color", "#007bff");

        $("#MyOrdersIndexTabelDiv").css("display", "none");
        $("#MyDecTabelMainDiv").css("display", "block");
    })

    /////////////
    $("#MyOrdersStatuse").change(function () {
        var id = $(this).val();
        console.log(id);

        AjaxReturnPartialView("GET", "/Orders/StatuseOrder", id, ".MyOrdersOrderTableBody")
        AjaxReturnPartialView("GET", "/Declerations/StatuseDec", id, ".MyOrdersDecsTableBody")
    })

    var linkCount = 0;
    $("#AddLink").click(function () {


        if (linkCount <= 5) {
            linkCount++;
            var newFormInput = $(".orderFormInputMainDiv").children()[0].outerHTML;
            var DeleteBtn = '<button type=button id="removform" class="btn btn-danger">Sil</button>';
            $(".orderFormInputMainDiv").append(newFormInput);
            $(".orderFormInputMainDiv").append(DeleteBtn);
        }
        else {
            alert("Bir yerde en cox 5 sifaris vere bilersiz")
        }
    })
    /////////////////////////////////////////////////////////////////////////////////////////////////
    // Delete link
    $(".orderFormInputMainDiv").on("click", "#removform", function () {
        linkCount--;
        var DeleteBtn = $(this);
        var DeleteDiv = DeleteBtn.parent().children()[DeleteBtn.index() - 1];
        DeleteDiv.remove();
        DeleteBtn.remove()
    })
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    $(".CountryDiv .OrderCounrtryHeader:first").css({ "background-color": "#f8a700", "color": "white" })
    var countryataId = $(".CountryDiv .OrderCounrtryHeader:first").attr("data-id");
    var InputCountry = '<input type="hidden" class="CountryIdInput" name="CountryId" value="' + countryataId + '"/>'

    $(".FormHiddenDiv").append(InputCountry);

    $(".OrderCounrtryHeader").on("click", function () {
        var CurrencyId = $(this).attr("data-CurrencyId")

        if (linkCount > 0) {
            alert(" Bir nece sifarisi bir yerde yalniz eyni olkeden sifaris etmek  olar");
        }
        else {
            $(".OrderCounrtryHeader").each(function () {
                $(this).css({ "background-color": "#f6f6f6", "color": "black" })
            })
            $(this).css({ "background-color": "#f8a700", "color": "white" })
            $(".CountryIdInput").remove();
            var ClickedCountryataDataText = $(this).attr("data-text");
            var ClickedcountryataId = $(this).attr("data-id");
            var clickedInputCountry = '<input type="hidden" class="CountryIdInput" name="CountryId" value="' + ClickedcountryataId + '"/>'
            $(".OrderCounrtryCurrencyText").text(ClickedCountryataDataText)
            $(".FormHiddenDiv").append(clickedInputCountry);
            $("#CountrCurrencyId").val(CurrencyId);
            $(".LinkInputDiv .price").val("");
            $(".LinkInputDiv #producCount").val("1");

            
            console.log(CurrencyId);
        }
    })

    $(".orderFormInputMainDiv").on("click", ".CreateIsUrgentCheckBox", function () {
        var value = $(this).parent().children(".CreateIsUrgentHiddenInput").val();
        if (value == "true") {

            $(this).parent().children(".CreateIsUrgentHiddenInput").val("false");
            $("#indexIsUrgentModal").click();
        }
        else {

            $(this).parent().children(".CreateIsUrgentHiddenInput").val("true");
            $("#indexIsUrgentModal").click();
        }

    })

    /////////////////////orders price calculate in create orders///////////////////////////////////////////////////////////////////////////////////////////////////////

    $(".orderFormInputMainDiv").on("keyup", "#ProductPrice", function () {
        var productprice = $(this).val();
        var CurrencyId = $(this).parent().children("#CountrCurrencyId").val();
        var keyupElement = $(this);

        var countProduct = $(this).parent().parent().parent().children()[0].lastElementChild.firstElementChild.value;

        $.ajax({
            type: "POST",
            url: "/Orders/CalculateOrderPrice",
            dataType: "json",
            data: { price: productprice, CurrencyId: CurrencyId, count: countProduct },
            success: function (response) {
                if (response.success) {

                    keyupElement.parent().parent().parent().children()[3].lastElementChild.firstElementChild.value = response.total;
                    keyupElement.parent().parent().parent().children()[5].lastElementChild.firstElementChild.value = response.AZN;
                }
                else {

                    keyupElement.parent().parent().parent().children()[3].lastElementChild.firstElementChild.value = "";
                    keyupElement.parent().parent().parent().children()[5].lastElementChild.firstElementChild.value = "";
                }
            },
            error: function () {
                keyupElement.parent().parent().parent().children()[3].lastElementChild.firstElementChild.value = "";
                keyupElement.parent().parent().parent().children()[5].lastElementChild.firstElementChild.value = "";
            }

        })

    })

    /////////////////////////////////////
    $(".orderFormInputMainDiv").on("keyup", "#producCount", function () {
        var keyupElementCount = $(this);
        var countProduct = $(this).val();
        var CurrencyId = $(this).parent().parent().parent().children()[1].lastElementChild.lastElementChild.value;;           
        var productprice = $(this).parent().parent().parent().children()[1].lastElementChild.firstElementChild.value;

        if (productprice != "")
        {
            $.ajax({
                type: "POST",
                url: "/Orders/CalculateOrderPrice",
                dataType: "json",
                data: { price: productprice, CurrencyId: CurrencyId, count: countProduct },
                success: function (response) {
                    if (response.success) {

                        keyupElementCount.parent().parent().parent().children()[3].lastElementChild.firstElementChild.value = response.total;
                        keyupElementCount.parent().parent().parent().children()[5].lastElementChild.firstElementChild.value = response.AZN;
                    }
                    else {

                        keyupElementCount.parent().parent().parent().children()[3].lastElementChild.firstElementChild.value = "";
                        keyupElementCount.parent().parent().parent().children()[5].lastElementChild.firstElementChild.value = "";
                    }
                },
                error: function () {
                    keyupElementCount.parent().parent().parent().children()[3].lastElementChild.firstElementChild.value = "";
                    keyupElementCount.parent().parent().parent().children()[5].lastElementChild.firstElementChild.value = "";
                }

            })
           
        }
        else {
          
        }
        
    })
    
    /////////////////menyu dropdown in myorders ////////////////////////////////////////////////////////////////

    var width = $("#divMenu").css("height");
    $("#divMenu").css("height", "0px");
    $("#menyuOrdersLink").on("click", function () {
        if ($("#divMenu").css("height") == "0px") {
            $("#divMenu").animate({ height: width });

        }
        else {
            $("#divMenu").animate({ height: '0px' });
        }
    });

    $("#orderMyOrdersStatus li").on("click", function () {
        $(".OrderHyiddenDiv").html("");
        var StatusId = $(this).attr("data-statusId");

        $("#orderMyOrdersStatus .MyOrderStatusActiveLi").removeClass("MyOrderStatusActiveLi");
        var clicedelement = $(this)

        $.ajax({
            type: "POST",
            url: "/Orders/MyOrdersActions",
            data: { id: StatusId },
        }).done(function (res) {

            $("#orderMyOrdersStatus .MyOrderStatusActiveLi").removeClass("MyOrderStatusActiveLi");
            clicedelement.addClass("MyOrderStatusActiveLi");
            $("#MyOrdersDecTableMainDiv").html(res);

        });
    });

    /////////////////edit delete orders in my orders////////////////////////////////////////////////////////////////
    $("#MyOrdersIndexTabelDiv").on("click", ".OrderEditBtn", function () {

        var StatusId = $(this).attr("data-id");

        $.ajax({
            type: "GET",
            url: "/Orders/Edit",
            data: { id: StatusId },
        }).done(function (res) {

            $("#EditMoalMainDiv").html(res);
            console.log("salam--" + StatusId);
        });
        $("#editModalShowBtn").click();
    });



    $("#MyOrdersIndexTabelDiv").on("click", ".OrderDelete", function () {

        var StatusId = $(this).attr("data-id");

        $.ajax({
            type: "GET",
            url: "/Orders/Delete",
            data: { id: StatusId },
        }).done(function (res) {

            $("#CountrydeletePartialModal").html(res);

        });
        $("#OrderDeleteButton").click();
        console.log(StatusId)
    });
    /////////////////////selected checkbox with delete and paid///////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////checbox when clicked add input///////////////////////////////////////////////////////////////////////////////////////////////////////
    $("#MyOrdersIndexTabelDiv").on("click", ".CheckedOrder", function () {
        var DataId = $(this).attr("id");
        if ($(this).prop('checked')) {


            var input = '<input class="SelectedOrder" id="SelectedOrder-' + DataId + '" name = "id" type ="hidden" value = "' + DataId + '" /> '
            $(".OrderHyiddenDiv").append(input);
        }
        else {

            $("#SelectedOrder-" + DataId).remove();
        }
    })
    ///////////////////All selected/////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    $("#MyOrdersIndexTabelDiv").on("click", "#OrderAllSelect", function (i) {

        var r = document.querySelectorAll(".CheckedOrder");//////////////////////////////////////////////////////////burani mellimnen sorus
        var  v = r.length;
        var c = 0

        $("#MyOrdersIndexTabelDiv input[type = 'checkbox']:checked").each(function () {
            c++
        })

        if (c == v) {
            $("#MyOrdersIndexTabelDiv input[type = 'checkbox']:checked").each(function () {
                $(this).click();
                c = 0;
            })
        }
        else {
            $("#MyOrdersIndexTabelDiv input:checkbox:not(:checked)").each(function () {
                $(this).click();
                c = 0;

            })
        }
       
    });

    $("#MyOrdersIndexTabelDiv").on("click", "#OrderAllDelete", function () {
        var slectedLenght = document.querySelectorAll(".SelectedOrder");
        $("#AllDeleteModalBtn").click();
        var SpanText;
        if (slectedLenght.length==0)
        {
            SpanText = 'Secilmis element Yoxdur'
            $("#AllDeleteText").text(SpanText);
            $("#AllDeleteModalSubmitBtn").css("display", "none");
        }
        else
        {
            SpanText = "Diqqet Secdiyiniz Elementler Silinecek Geri Qaytarmaq Mumkun Deyil";
            $("#AllDeleteText").text(SpanText);
            $("#AllDeleteModalSubmitBtn").css("display", "block");

        }
        

    })

})
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//$("li").each(function (index) {
//    console.log(index + ": " + $(this).text());
//});
  //$("input:checkbox:not(:checked)")
 //$(input[type = 'checkbox']:checked")
