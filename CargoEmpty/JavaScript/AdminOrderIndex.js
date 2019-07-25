$(document).ready(function () {

    //Change view by order status in adminpanel order index
    $(".AdminCustumersOrdersIndex").on("click", ".custumersOrdersActionBtn", function () {
        var id = "";
        var Link = $(this).attr("data-action");
        var changeHtml = $("#OrdersJsonTabelMainDiv");
        AjaxReturnPartialView("POST", Link, id, changeHtml)        
    })

    $(".AdminCustumersOrdersIndex").on("change", ".OrderIndexCountrySelect", function () {
        var id = $(this).val();
        var Link = $(this).attr("data-action");
        var changeHtml = $("#OrdersJsonTabelMainDiv");
        AjaxReturnPartialView("POST", Link, id, changeHtml)
    })

        //delete order in adminpanel order index

    $("#OrdersIndexMainDiv").on("click", ".OrderDelete", function () {

        var orderId = $(this).attr("data-id");
        var Action = "/Orders/DeleteOrderInIndex";      
        var text = '<span>Secdiyiniz Sifaris <span style="color:red">Silinecek!!!</span> Eminsiniz?</span>';
        $("#OrderIndexModalFormParentDiv form").attr("action", Action);

        var Order = '<input type="hidden" class="AdminSelectedOrder" name="id" value="' + orderId + '"/>'
        
        $(".OrderIndexModalParentDiv .AdminOrderIndexModalBody").html("");
        $(".OrderIndexModalParentDiv .AdminOrderIndexModalBody").append(Order);
        $(".OrderIndexModalParentDiv .AdminOrderIndexModalBody").append(text);

        $(".OrderIndexModalParentDiv #OrderIndexModalBtn").click();


    })
    //details order in adminpanel order index

    $("#OrdersIndexMainDiv").on("click", ".OrderEditBtn", function () {

        var Link = "/Orders/AdminDetailsOrder";
        var id = $(this).attr("data-id")
        $("#OrderIndexModalFormParentDiv form").attr("action", "");
        $(".OrderIndexModalParentDiv .AdminOrderIndexModalBody").html("");
        AjaxReturnPartialView("GET", Link, id, ".AdminOrderIndexModalBody")

        $(".OrderIndexModalParentDiv #OrderIndexModalBtn").click();
    })
})