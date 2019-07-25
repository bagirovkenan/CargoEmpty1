$(document).ready(function () {
    //Index Bundel Page js

    //show bundel decleration info
    $(".BundelIndexTableMainDiv").on("click", "#BundelIndexDecNameId", function () {
        var id = $(this).attr("data-id");
        
        AjaxReturnPartialView("GET", "/Bundel/DeclerationInfo", id, ".BundelIndexDeclerationInfoModalContenDiv");
        $("#indexBundelDecIfoModalShowBtn").click();
    })

    //change country in index bundel
    $(".BundelIndexCountry").change(function () {
        var CountryId = $(this).val();
        if (CountryId == "") {
            $("#BundelStatuseIdInIndex").val("");
            $(".BundelIndexStatusBtn").css({ "background-color": "#FFC107", "color": "black" });
        }
        var StatusId = $("#BundelStatuseIdInIndex").val();
        var id =
        {
            CountryId: CountryId,
            StatusId: StatusId
        }
        AjaxReturnPartialView("POST", "/Bundel/ChangeCountryInIndexBundel", id, "#BundelIndexTableBodyId")
    }); 
        //When Bundel clicks status buttons
    $(".BundelIndexStatusBtn").click(function () {
        $(".BundelIndexStatusBtn").css({ "background-color": "#FFC107", "color": "black" });
        $(this).css({ "background-color": "#ff0000", "color": "white" });
        var CountryId = $(".BundelIndexCountry").val();
        var StatusId = $(this).attr("data-id");
        $("#BundelStatuseIdInIndex").val(StatusId);
        var id =
        {
            CountryId : CountryId,
            StatusId : StatusId
        }
        AjaxReturnPartialView("POST", "/Bundel/ChangeCountryInIndexBundel", id, "#BundelIndexTableBodyId")

    });
    //delete bundel in index bundel page
    $(".BundelIndexTableMainDiv").on("click", "#bundelIndexDeleteButton", function () {
        var id = $(this).attr("data-id");
        $.ajax({
            url: "/Bundel/Delete",
            data: { id: id },
            type: "POST",
            success: function (data) {
                if (data.success == "true") {
                    location.reload();
                    alert("Secdiyiniz Baglama Silindi");
                }
                else {
                    alert("Xeta Bas Verdi Baglama Silinmedi");
                }

            },
            error: function () {
                alert("Emeliyyat Bas Tutumadi Bilinmeyen Xeta Bas Verdi Secilen Baglamada Yanlisliq Var ");
            }
        })
    })

    //Change Bundel Status
    $(".BundelIndexTableMainDiv").on("click", "#changeBundelStatus", function () {
        var Link = "/Bundel/ChangeStatus";
        var id = $(this).attr("data-id");
        AjaxReturnPartialView("GET", Link, id, ".BundelIndexDeclerationInfoModalContenDiv");
        $("#indexBundelDecIfoModalShowBtn").click();
    });




    ///Creaate Bundel Page js
    $("#ShowOrdersTableBtnId").on("click", function () {
        $("#CreateBundelDeclerationTableParentDivId").css("display", "none");
        $("#CreateBundelOrdersTableParentDivId").css("display", "block");

        $("#ShowDeclerationTableBtnId").css("background-color", "#f6f6f6");
        $(this).css("background-color", "#ffc107");

    });

    $("#ShowDeclerationTableBtnId").on("click", function () {
        $("#CreateBundelDeclerationTableParentDivId").css("display", "block");
        $("#CreateBundelOrdersTableParentDivId").css("display", "none");

        $("#ShowOrdersTableBtnId").css("background-color", "#f6f6f6");
        $(this).css("background-color", "#ffc107");
    })
    //show crete bundel Modal
    $("#CreateBundelModalBtn").on("click", function () {
        var ordersLength = $(".OrderInputParentDiv").children().length;
        if (ordersLength == 0) {
            alert("Hec bir Sifaris ve ye Beyanname secilmeyib")
        }
        else {
            $("#CreateBundelModalBtnMainBtn").click();
        }

    })

    //change orders and declerations when chenges country 
    $("#CreateBundelFormContryId").val($("#BundelCountryId").val());//???
    $("#BundelCountryId").change(function () {

        var ordersLength = $(".OrderInputParentDiv").children().length;

        if (ordersLength > 0) {
            alert("Bir Baglamada Yalniz Eyni Olkeden Sifarisler Ola Biler")
        }
        else {
           
            var CountryId = $(this).val();
            var userId = $("#BundelUserId").val();
            $("#CreateBundelFormContryId").val(CountryId);
            var id =
            {
                CountryId: CountryId,
                userId: userId
            }
            AjaxReturnPartialView("POST", "/Bundel/ChangeCountryOrder", id, "#orderTableBody")
            AjaxReturnPartialView("POST", "/Bundel/ChangeCountryDecleration", id, "#declerationTableBody")
        }


    })

    //add order or package id to modal form div
    $(".CreateBundelOrdersTableParentDiv").on("click", ".CheckedForBundel", function () {
        var id = $(this).attr("data-id");
        var type = $(this).attr("data-type");
        if ($(this).is(':checked')) {
            var input = '<input id="orderID-' + id + '" class="' + type + '" type="hidden" name="orderId" value="' + id + "-" + type + '" />'
            $(".OrderInputParentDiv").append(input);
        }
        else {
            $("#orderID-" + id).remove();
        }

    })

    //check the price on the create bundel modal 
    $("#bundelModalPrice").blur(function () {
        var price = $(this).val();
        var PriceInput = $(this);
        var userId = $("#BundelUserId").val();
        $.ajax({
            url: "/Bundel/CheckThePrice",
            data: { price: price, UserId: userId },
            type: 'GET',
            success: function (data) {
                if (data.success == "false") {
                    alert("Balans Yetersizdir");
                    PriceInput.val("");
                }
            },
            error: function () {
                alert("Balans Yetersizdir ve ya Reqemi Duzgun Daxil Edin ");
                PriceInput.val("");
            }
        });

    });

    //Show Shop #CreateBundelModalShopNameInputDiv
    $("#ShopName").keyup(function () {
        $("#CreateBundelModalShopNameInputDiv").html("");
        var name = $(this).val();
        var ShopInput = $(this);
        $.ajax({
            url: "/Bundel/ShowShop",
            data: { ShopName: name},
            type: 'GET',
            success: function (data) {
                if (data.success == "true") {
                    var button = '<button id="ShowShopInfoButton" type="button" style="width:100%;text-align:left;" class="btn" data-id="' + data.id + '">' + data.shopName + ' | ' + data.companyName + ' </button >'

                    $("#CreateBundelModalShopNameInputDiv").append(button);
                }
            },
            error: function () {
                alert("Market Adini Duzgun Daxil Edin ");
                ShopInput.val("");
            }
        });

    });
    //Show Shop info on the create bundel modal 
    $("#CreateBundelModalShopNameInputDiv").on("click", "#ShowShopInfoButton", function () {
        var id = $(this).attr("data-id");
        $.ajax({
            url: "/Bundel/ShopInfo",
            data: { id: id },
            type: "GET",
            success: function (data) {
                if (data.Success == true)
                {
                    $("#CreateBundelModalCompanyName").val(data.CompanyName);
                    $("#CreateBundelModalAdress").val(data.Adress);
                    $("#CreateBundelModalAccountNumber").val(data.AccountNumber);
                    $("#CreateBundelModalCountry").val(data.Country);
                    $("#CreateBundelModalCity").val(data.City);
                    $("#CreateBundelModalPhone").val(data.PhoneNumber);
                    $("#CreateBundelModalPostCode").val(data.PostCode);
                    $("#CreateBundelModalShopNameInputDiv").html("");
                }
                else
                {
                    alert("Magaza Melumatlarina Yeniden Baxin");
                }
            },
            error: function (data) {
                alert("Magaza Haqqqinda Hec Bir Melumat Tapilmadi");
            }

        });
    })
    //Submit
    $("#CreateButtonModalSaveBtn").click(function () {

        $("#CreateBundelModalFormSubmitBtn").click();
    })
});