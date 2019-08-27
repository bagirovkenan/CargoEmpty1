$(document).ready(function () {
    //Index Bundel Page js

    //show bundel decleration info
    $(".BundelIndexTableMainDiv").on("click", "#BundelIndexDecNameId", function () {
        var id = $(this).attr("data-id");

        AjaxReturnPartialView("GET", "/Bundel/DeclerationInfo", id, ".BundelIndexDeclerationInfoModalContenDiv");
        $("#bundelIndexModalSaveBtn").css("display", "none");
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
            CountryId: CountryId,
            StatusId: StatusId
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

    //Click Bundel Status Button in bundel index page
    $(".BundelIndexTableMainDiv").on("click", "#changeBundelStatus", function () {
        var Link = "/Bundel/ChangeStatusModal";
        var id = $(this).attr("data-id");
        AjaxReturnPartialView("POST", Link, id, ".BundelIndexDeclerationInfoModalContenDiv");
        $("#bundelIndexModalSaveBtn").css("display", "block");
        $("#BundelIndexPrintBtn").css("display", "none");
        $("#bundelIndexChangeStatusModalSaveBtn").css("display", "block");
        $("#indexBundelDecIfoModalShowBtn").click();
    });


    //when clicked the add button in the Index Bundel Pages Change Modal 
    var bundels;

    $(".BundelIndexDeclerationInfoModalContenDiv").on("click", "#ChangeBundelStatuseModalTableAddBtn", function () {
        bundels = document.querySelectorAll(".BundelProductsTrClass").length;
        var idInput =  document.getElementsByClassName("BundelEditBundelPruoductClass")[0].value;
        console.log(document.getElementsByClassName("BundelEditBundelPruoductClass")[0].value);
        if (bundels < 5) {
            document.getElementsByClassName("BundelEditBundelPruoductClass")[0].value = "";
            $(".ChangeBundelStatuseModalTableRemoveTd").css("display", "block");
            var tr = $("#IndexChangeStatusWarehouseAbroadTableBody").children()[0].outerHTML;
            $("#IndexChangeStatusWarehouseAbroadTableBody").append(tr);
            document.getElementsByClassName("BundelEditBundelPruoductClass")[0].value = idInput;           
            bundels = document.querySelectorAll(".BundelProductsTrClass").length;           
        }
        else {
            alert("Bir Baglamada 5 sifaris ola biler");
            $(".ChangeBundelStatuseModalTableRemoveTd").css("display", "block")
        }
        
    });
    //when clicked the remove button in the Index Bundel Pages Change Modal 
    $(".BundelIndexDeclerationInfoModalContenDiv").on("click", "#ChangeBundelStatuseModalTableRemoveBtn", function () {
       
        console.log(bundels);
        if (bundels > 1) {
            $(this).parent().parent().remove();
            bundels = document.querySelectorAll(".BundelProductsTrClass").length;
        }
        if (bundels == 1) {
            $(".ChangeBundelStatuseModalTableRemoveTd").css("display", "none")
        }
    });

    //delete btn in the edit bundel
    $(".BundelIndexDeclerationInfoModalContenDiv").on("click", "#ChangeBundelStatuseModalTableDeleteBtn", function () {
        bundels = document.querySelectorAll(".BundelProductsTrClass").length;        
        if (bundels > 1) {
            var deleteBtn = $(this);
            var id = $(this).parent().parent().children()[0].firstChild.value;
            if (id==null || id=="") {
                $(this).parent().parent().remove();
                bundels = document.querySelectorAll(".BundelProductsTrClass").length;
                console.log(id);
            }
            else {
                console.log(id + " aj")
            $.ajax({
                url: "/Bundel/DeleteProduct",
                type: "GET",
                data: { id: id },
                success: function (res) {
                    if (res.success == "true") {
                        deleteBtn.parent().parent().remove();
                        bundels = document.querySelectorAll(".BundelProductsTrClass").length;
                    }
                    else {
                        bundels = document.querySelectorAll(".BundelProductsTrClass").length;
                    }
                },
                error: function () {
                    bundels = document.querySelectorAll(".BundelProductsTrClass").length;
                }
                })
            }
        }
        else {
            alert("Butun mehsullar Siline bilmez");
        }
    });
    //change order statuse  in change status bundel modal

    $(".BundelIndexDeclerationInfoModalContenDiv").on("change", "#BundelIndexStatusSelect", function () {
        var val = $(this).val();
        var id = $("#changeStatusModalBundelId").val();
        if (val == 9) {
            AjaxReturnPartialView("GET", "/Bundel/ForeignWarehouse", id, ".ForeignWarehouseModalHiddenDiv");

            $("#IndexBundelStatusForm").attr("action", "/Bundel/ForeignWarehouse");

        }
        else {
            $("#IndexBundelStatusForm").attr("action", "/Bundel/ChangeStatus");
            $(".ForeignWarehouseModalHiddenDiv").html("");
        }
    })
    //when chenged bundel wheight
    
    $(".BundelIndexDeclerationInfoModalContenDiv").on("keyup", "#ChangeBundelStatusModalWeightInputId", function () {
        $("#ChangeBundelStatusModalPriceSpanId").text("");
        $("#ChangeBundelStatusModalPriceInputId").val("");
    })
    //Calculate bundel delivery price

    $(".BundelIndexDeclerationInfoModalContenDiv").on("click", "#ChangeBundelStatusModalPriceButtonId", function () {

        $("input[type=number].ChangeBundelStatusModalBundelSize").each(function (i) {
            var value = $(this).val();

            if (value != 0) {
                $(this).css("background-color", "white");
                var model = {
                    BundleWeight: $("#ChangeBundelStatusModalWeightInputId").val(),
                    CountryId: $("#changeStatusModalBundelCountryId").val(),
                    BundelCount: 1,
                    BundleWidth: $("#ChangeBundelStatusModalWidthInputId").val(),
                    BundleLenght: $("#ChangeBundelStatusModalLengthInputId").val(),
                    BundleHeight: $("#ChangeBundelStatusModalHeightInputId").val()
                }
                $.ajax({
                    url: "/Bundel/CalculatePrice",
                    data: { model: model },
                    type: "POST",
                    success: function (res) {
                        if (res.success == "true") {
                            var text = res.responseUSD + " USD | " + res.responseAZN + " AZN";
                            $("#ChangeBundelStatusModalPriceSpanId").text(text);
                            $("#ChangeBundelStatusModalPriceInputId").val(res.responseUSD);
                        }
                        else {
                            text = 0
                            $("#ChangeBundelStatusModalPriceSpanId").text(text);
                            $("#ChangeBundelStatusModalPriceInputId").val(text);
                            alert("Qiymet Hesablana bilmedi baglama parametrlerine(ceki/en/uzunluq/hundurluk)birde baxin");
                        }
                    },
                    error: function () {
                        alert("Qiymet Hesablana bilmedi baglama parametrlerine(ceki/en/uzunluq/hundurluk)birde baxin");
                    }
                })
            }
            else {
                $(this).css("background-color", "#e6161654");
            }
        });
    });

    //save bundel staus 
    $("#bundelIndexChangeStatusModalSaveBtn").click(function () {
        $(".changeStatusSubmitButton").click();
        console.log("submit")
        
    });

    //Change the status of the bundle on the external storage
    $("#BundelIndexActinDropdownMainDinDivId .ActionChangeStatus").click(function () {
        var id = $(this).parent().children(".ActionBundelId").val();

        AjaxReturnPartialView("GET", "/Bundel/EditForeignWarehouseBundelStatuse", id, ".BundelIndexDeclerationInfoModalContenDiv");
        $("#BundelIndexPrintBtn").css("display", "none");
        $("#bundelIndexChangeStatusModalSaveBtn").css("display", "block");
        $("#indexBundelDecIfoModalShowBtn").click();
    })


    // bill btn click info bundel
    $("#BundelIndexActinDropdownMainDinDivId .BundelIndexActivBill").click(function () {
        var id = $(this).parent().children(".ActionBundelId").val();
        AjaxReturnPartialView("GET", "/Bundel/BundelBill", id, ".BundelIndexDeclerationInfoModalContenDiv");
        $("#bundelIndexChangeStatusModalSaveBtn").css("display", "none");
        $("#BundelIndexPrintBtn").css("display", "block");
        $("#BundelIndexModalDialog").css("max-width", "900px");
        $("#indexBundelDecIfoModalShowBtn").click();
    });

    //click print btn
    $("#BundelIndexModalFooter").on("click", "#BundelIndexPrintBtn", function () {
        PrintScreen(document.getElementById("BundelIndezChangeStatusModalMainDiv1"));
    })
    //Edit bundel Action btn
    $("#BundelIndexActinDropdownMainDinDivId .BundelIndexEditBundelBtn").click(function () {
        var id = $(this).parent().children(".ActionBundelId").val();
        AjaxReturnPartialView("GET", "/Bundel/BundelEdit", id, ".BundelIndexDeclerationInfoModalContenDiv");

        $("#BundelIndexPrintBtn").css("display", "none");
        $("#bundelIndexChangeStatusModalSaveBtn").css("display", "block");
        $("#indexBundelDecIfoModalShowBtn").click();
    })

    //bundel label
    $("#BundelLabelPages").on("click", "#BundelLabelPrint", function () {
        PrintScreen(document.getElementById("BundelLabelPages"));
    })
    //----------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------
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
            data: { ShopName: name },
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
                if (data.Success == true) {
                    $("#CreateBundelModalCompanyName").val(data.CompanyName);
                    $("#CreateBundelModalAdress").val(data.Adress);
                    $("#CreateBundelModalAccountNumber").val(data.AccountNumber);
                    $("#CreateBundelModalCountry").val(data.Country);
                    $("#CreateBundelModalCity").val(data.City);
                    $("#CreateBundelModalPhone").val(data.PhoneNumber);
                    $("#CreateBundelModalPostCode").val(data.PostCode);
                    $("#CreateBundelModalShopNameInputDiv").html("");
                }
                else {
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