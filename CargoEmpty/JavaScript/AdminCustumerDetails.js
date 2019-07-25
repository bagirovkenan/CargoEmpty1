$(document).ready(function () {
    $(".activeAccountLink").click();

    $(".CustumersDetailsMenyMainDiv #accauntsettingUl .CustumerInfoActions").on("click", function () {
        var Link = $(this).attr("data-action");
        var id = $(this).attr("data-id");

        AjaxReturnPartialView("POST", Link, id, "#CustumersDinamikChangeInfo")

        $(".activeAccountLink").removeClass("activeAccountLink");
        $(this).addClass("activeAccountLink");
    })

    $("#CustumersDinamikChangeInfo").on("click", ".custumersOrdersActionBtn", function () {
        var Link = $(this).attr("data-action");
        var id = $(this).attr("data-id");
        var changeHtml = $("#CustumersDinamikChangeInfo #OrdersJsonTabelMainDiv");
        AjaxReturnPartialView("POST", Link, id, changeHtml)
    })

    /////////////////////////////////////////

    /////////////////////selected checkbox with delete and paid///////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////checbox when clicked add input///////////////////////////////////////////////////////////////////////////////////////////////////////
    //$("#MyOrdersIndexTabelDiv").on("click", ".CheckedOrder", function () {
    //    var DataId = $(this).attr("id");
    //    if ($(this).prop('checked')) {


    //        var input = '<input class="SelectedOrder" id="SelectedOrder-' + DataId + '" name = "id" type ="hidden" value = "' + DataId + '" /> '
    //        $(".OrderHyiddenDiv").append(input);
    //    }
    //    else {

    //       $("#SelectedOrder-" + DataId).remove();
    //    }
    //})
       ///details order
    $("#CustumersDinamikChangeInfo").on("click", ".OrderEditBtn", function () {

        var Link = "/Orders/AdminDetailsOrder";;
        var id = $(this).attr("data-id")
        $("#CustumersDetailsFormParentDiv form").attr("action", "");
        $(".AdminCutumersDetailsModalBody").html("");
        AjaxReturnPartialView("GET", Link, id, ".AdminCutumersDetailsModalBody")
        $(".modalParentDiv #CustumerDetailsModalBtn").click();
    })



    ///Delete order
    $("#CustumersDinamikChangeInfo").on("click", ".OrderDelete", function () {

        var orderId = $(this).attr("data-id");
        var userId = $(".CustumersDetailsActionsMainDiv #CustumerId").val();
        var Action = "/Orders/AdminDeleteOrder";
        var text = '<span>Secdiyiniz Sifaris <span style="color:red">Silinecek!!!</span> Eminsiniz?</span>';

        $("#CustumersDetailsFormParentDiv form").attr("action", Action);

        var User = '<input type="hidden" class="AdminDeletedUser" name="UserId" value="' + userId + '"/>'
        var Order = '<input type="hidden" class="AdminSelectedOrder" name="OrderId" value="' + orderId + '"/>'


        $("input[type='checkbox']:checked").click();
        $(".modalParentDiv .AdminCutumersDetailsModalBody").html("");
        $(".modalParentDiv .AdminCutumersDetailsModalBodyUserID").html("");
        $(".modalParentDiv .AdminCutumersDetailsModalBodyUserID").append(User);
        $(".modalParentDiv .AdminCutumersDetailsModalBody").append(Order);
        $(".modalParentDiv .AdminCutumersDetailsModalBody").append(text);

        $(".modalParentDiv #CustumerDetailsModalBtn").click();


    })

    ///////all delet in user details in admin panel 
    $("#CustumersDinamikChangeInfo").on("click", ".CheckedOrder", function () {
        var orderId = $(this).attr("id");
        if ($(this).prop('checked')) {

            var input = '<input class="AdminSelectedAllOrder" id="SelectedOrder-' + orderId + '" name = "id" type ="hidden" value = "' + orderId + '" /> '
            $(".modalParentDiv .AdminCutumersDetailsModalBody").append(input);
        }
        else {

            $("#SelectedOrder-" + orderId).remove().remove();
        }

    });
    $("#CustumersDinamikChangeInfo").on("click", "#OrderAllSelect", function () {
        AllSelect("#CustumersDinamikChangeInfo", ".CheckedOrder");
    });
    ///////////////////All selected /////////////////////////////////////////////////////////////////////////////////////////////////////////
    $("#CustumersDinamikChangeInfo").on("click", "#OrderAllDelete", function () {
        var userId = $(".CustumersDetailsActionsMainDiv #CustumerId").val();
        var Action = "/Orders/AdminAllDeleteOrder";
        var text = '<span>Secdiyiniz Sifarisler Silinecek!!! Eminsiniz?</span>';
        var User = '<input type="hidden" class="AdminDeletedUserId" name="UserId" value="' + userId + '"/>'
        var slectedLenght = document.querySelectorAll(".AdminSelectedAllOrder");

        if (slectedLenght.length > 0) {

            $(".modalParentDiv .AdminCutumersDetailsModalBodyUserID").html("");
            $(".modalParentDiv .AdminCutumersDetailsModalBody span").text("");
            text = '<span>Secdiyiniz Sifarisler Silinecek!!! Eminsiniz?</span>';
            $("#CustumersDetailsFormParentDiv form").attr("action", Action);
            $(".modalParentDiv .AdminCutumersDetailsModalBodyUserID").append(User);
            $(".modalParentDiv .AdminCutumersDetailsModalBody").append(text);
            $(".modalParentDiv #CustumerDetailsModalBtn").click();

        }
        else {

            $(".modalParentDiv .AdminCutumersDetailsModalBodyUserID").html("");
            $(".modalParentDiv .AdminCutumersDetailsModalBody").html("");
            text = '<span>Secilmis Element Yoxdur</span>';
            $(".modalParentDiv .AdminCutumersDetailsModalBody").append(text);
            $(".modalParentDiv #CustumerDetailsModalBtn").click();
        }
    });

    ////// //For an Admin to create  a decleration for the custumer on the custumer details page 

    $("#AdminCustumerDeclerationBtn").on("click", function () {
        var userId = $(".CustumersDetailsActionsMainDiv #CustumerId").val();
        var Link = "/Declerations/CreateOnDetailsPage"
        AjaxReturnPartialView("GET", Link, userId, ".CustumerDetailsDeclerationModalContentDiv");

        $(".declerationShowModalBtnDiv button").click();
    });
    //when change country 

    $(".CustumerDetailsDeclerationModalContentDiv").on("change", "#DeclerationCountrySelect", function () {
        var CurrencyName = $("#DeclerationCountrySelect  option:selected").attr("data-id");
        var userId = $(".CustumersDetailsActionsMainDiv #CustumerId").val();
        var id = $(this).val();
        $("#DeclerationValyutaDiv #DeclerationOrderOrderValyuta").text(CurrencyName);

        $.ajax({
            type: "POST",
            url: "/Declerations/CountryOrders",
            dataType: "json",
            data: { id: id, UserId: userId },
            success: function (response) {
                if (response != null && response.length > 0) {
                    $(".DeclerationFromMainDiv #DeclerationOrdersDiv #OrdesName").html(" ");
                    for (var i = 0; i < response.length; i++) {
                        var option = '<option class="OrderNameClasse" value="' + response[i].Id + '">' + response[i].OrderName + '</option>'
                        $(".DeclerationFromMainDiv #DeclerationOrdersDiv #OrdesName").append(option);
                        if (response.length == 1) {
                            $(".DeclerationFromMainDiv #DeclerationOrdersDiv #OrdesName").change();

                        }
                    }
                }
                else {
                    $(".DeclerationFromMainDiv #DeclerationOrdersDiv #OrdesName").html(" ");
                    alert("Bu Olkeden Tesdiqlenmeyen Sifarisiniz Yoxdur")
                }



            }
        })
    })

    /////show order information   when selecting ordername in my account decleration modal
    $(".CustumerDetailsDeclerationModalContentDiv").on("change", "#OrdesName", function () {
        var id = $(this).val();
        var userId = $(".CustumersDetailsActionsMainDiv #CustumerId").val();
        $.ajax({
            type: "POST",
            url: "/Declerations/OrderInformation",
            dataType: "json",
            data: { id: id, UserId: userId },
            success: function (response) {
                if (response.success) {


                    var Date = '<input type="text" name="DecDate"  class="form-control" id = "DeclerationOrderDateInput" value="' + response.OrderDate + '"  required/>'
                    $("#DeclerationOrderDateDiv").html(" ");
                    $("#DeclerationOrderDateDiv").append(Date);
                    $("#DeclerationOrderCountDiv #DeclerationOrderCountInput").val(response.OrderCount);
                    $("#DeclerationOrderDateDiv #DeclerationOrderDateInput").val(response.OrderDate);
                    $("#DeclerationOrderPriceDiv #DeclerationOrderPriceInput").val(response.OrderPrice);
                    $("#DeclerationComentDiv #DeclerationComentTextArea").text(response.OrderComent);

                    //$("#DeclerationValyutaDiv #DeclerationOrderOrderValyuta").text(response.OrderCurrency);

                   


                }
                else {
                    alert(response.responseText);
                }
            },
            error: function () {
                alert("Bilinmeyen Xeta ");
            }
        })

    })
})


    //var a = $(this).find(':selected').attr('data-id');
    //console.log('Clicked option value => ' + $(this).val());
    //console.log(':select & $(this) => ' + $(':selected', this).data('id'));
    //console.log(':select & this => ' + $(':selected', this).data('id'));
    //console.log('option:select & this => ' + $('option:selected', this).data('id'));

