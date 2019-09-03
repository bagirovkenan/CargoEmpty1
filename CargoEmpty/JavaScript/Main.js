ShowCategories();
ShowCategories2();

//////////////////////////////////////////////////////
function ShowCategories() {
    $("#CategoryMenyuButton").click(function () {
        $(".categoryTitetelColDiv").toggle(100);
    })
}
/////////////////////////////////////////////////////
function ShowCategories2() {
    $(".CategoryTitelColDiv").click(function () {
        $(".categoryTitetelColDiv").show(100);
    })
}


////////////////////////////////////////////////////
function ChangeActivClassFromIndex(element) {

    var obj = {};

    var ElementClass = element.attr("class");

    if (ElementClass == "Activ") {

        element.removeClass(element.attr("class"));
        element.addClass("DeActiv");

    }
    else {
        element.removeClass(element.attr("class"))
        element.addClass("Activ")
    }
    obj =
        {
            id: element.attr("data-id"),
            status: element.attr("class"),

        };

    return obj;
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function AjaxRequestArray(MetodType, ActionUrl, DataType, Data) {
    $.ajax({
        type: MetodType,
        url: ActionUrl,
        dataType: DataType,
        data: { id: Data },
        success: function (response) {
            if (response.success) {
                alert(response.responseText);
            } else {
                // DoSomethingElse()
                alert(response.responseText);
            }
        },
        error: function (response) {
            alert(response.responseText);  // 
        }

    })
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function AjaxReturnPartialView(MetodType, ActionUrl, Data, AddpartalView) {

    $.ajax({
        type: MetodType,
        url: ActionUrl,
        data: { id: Data },
        error: function () {
            alert("Xeta Basverdi")
        }
    }).done(function (res) {

        $(AddpartalView).html(res);
        })
       
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function ChangActivStatusFromCreateEdit(element, element2) {
    var text = element.text();
    if (text == "Activ") {
        element.removeClass(element.attr("class"));
        element.addClass("btn btn-danger");
        element.text("DeActiv");
        $(element2).val("false");
    }
    else {
        element.removeClass(element.attr("class"));
        element.addClass("btn btn-success");
        element.text("Activ");
        $(element2).val("true");
    }

}
///////////////////////////////////////////////////////////////////////////////////////////////////////
////////

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////Add Html
function ChangeHtml(HtmlChangedElement, AddHtmlElement) {
    $(HtmlChangedElement).html("");
    $(HtmlChangedElement).html(AddHtmlElement);
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////Error Function
function Error(ErrorMessage) {
    alert(ErrorMessage);
}
///////////////////////////
/////All Select
function AllSelect(StatickElement, SelectedElements) {
    var r = document.querySelectorAll(SelectedElements);//////////////////////////////////////////////////////////burani mellimnen sorus
    var v = r.length;
    var c = 0
    $(StatickElement + "  input[type = 'checkbox']:checked").each(function () {
        c++
    })

    if (c == v) {
        $(StatickElement + "  input[type = 'checkbox']:checked").each(function () {
            $(this).click();
            c = 0;
        })
    }
    else {
        $(StatickElement + "  input:checkbox:not(:checked)").each(function () {
            $(this).click();
            c = 0;

        })
    }
}
/////////print modal screen
function PrintScreen(e) {
    var domClone = e.cloneNode(true);
    var printSection = document.getElementById("printSection");

    if (!printSection) {
        var printSection = document.createElement("div");
        printSection.id = "printSection";
        document.body.appendChild(printSection);
    }

    printSection.innerHTML = "";
    printSection.appendChild(domClone);
    window.print();
}


/////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////Main Decleration on the Admin Panel

$("#layoutDeclerationModal").on("click", function () {
    var userId = "";
    var Link = "/Declerations/CreateOnLayoutPage"
    AjaxReturnPartialView("GET", Link, userId, ".DeclerationModalAdminLayout");
    $("#adminLayoutModalBtn").click();
});

$(".DeclerationModalAdminLayout").on("change", "#MainDeclerationUserSelect", function () {
    var userId = $(".DeclerationModalAdminLayout #MainDeclerationUserSelect").val();
    var Link = "/Declerations/CustumersOrders"
    $.ajax({
        type: "POST",
        url: Link,
        dataType: "json",
        data: { UserId: userId },
        success: function (res) {
            if (res != null && res.length > 0) {
                $(".MainDeclerationFormMainDiv #MainDeclerationOrdersDiv #MainOrdesName").html(" ");
                for (var i = 0; i < res.length; i++) {
                    var option = '<option class="MainDeclerationOrderNameClasse" value="' + res[i].Id + '">' + res[i].OrderName + '</option>'
                    $(".MainDeclerationFormMainDiv #MainDeclerationOrdersDiv #MainOrdesName").append(option);
                    if (res.length == 1) {
                        $(".MainDeclerationFormMainDiv #MainDeclerationOrdersDiv #MainOrdesName").change();
                    }
                }
            }
            else {
                $(".MainDeclerationFormMainDiv #MainDeclerationOrdersDiv #MainOrdesName").html(" ");
                var option = '<option class="MainDeclerationOrderNameClasse">Sifaris Tapilmadi</option>'
                $(".MainDeclerationFormMainDiv #MainDeclerationOrdersDiv #MainOrdesName").append(option);
            }
        },
        error: function () {
            alert("bilinmeyen Sef Askar Oldu")
        }
    })
})


$(".DeclerationModalAdminLayout").on("change", "#MainDeclerationCountrySelect", function () {
    var CurrencyName = $("#MainDeclerationCountrySelect  option:selected").attr("data-id");
    var userId = $(".DeclerationModalAdminLayout #MainDeclerationUserSelect").val();
    var id = $(this).val();
    $("#MainDeclerationValyutaDiv #MainDeclerationOrderOrderValyuta").text(CurrencyName);
    $.ajax({
        type: "POST",
        url: "/Declerations/CountryOrders",
        dataType: "json",
        data: { CountryId: id, UserId: userId },
        success: function (response) {
            if (response != null && response.length > 0) {
                $(".MainDeclerationFormMainDiv #MainDeclerationOrdersDiv #MainOrdesName").html(" ");
                for (var i = 0; i < response.length; i++) {
                    var option = '<option class="MainDeclerationOrderNameClasse" value="' + response[i].Id + '">' + response[i].OrderName + '</option>'
                    $(".MainDeclerationFormMainDiv #MainDeclerationOrdersDiv #MainOrdesName").append(option);

                    if (response.length == 1) {
                        $(".MainDeclerationFormMainDiv #MainDeclerationOrdersDiv #MainOrdesName").change();

                    }
                }
            }
            else {
                $(".MainDeclerationFromMainDiv #MainDeclerationOrdersDiv #MainOrdesName").html(" ");
                alert("Bu Olkeden Tesdiqlenmeyen Sifarisiniz Yoxdur")
            }

        }
    })
})

/////show order information   when selecting ordername in my account decleration modal
$(".DeclerationModalAdminLayout").on("change", "#MainOrdesName", function () {
    var id = $(this).val();
    var userId = $(".DeclerationModalAdminLayout #MainDeclerationUserSelect").val();
    $.ajax({
        type: "POST",
        url: "/Declerations/OrderInformation",
        dataType: "json",
        data: { id: id, UserId: userId },
        success: function (response) {
            if (response.success) {


                var Date = '<input type="text" name="DecDate"  class="form-control" id = "MainDeclerationOrderDateInput" value="' + response.OrderDate + '"  required/>'
                $("#MainDeclerationOrderDateDiv").html(" ");
                $("#MainDeclerationOrderDateDiv").append(Date);
                $("#MainDeclerationOrderCountDiv #MainDeclerationOrderCountInput").val(response.OrderCount);
                $("#MainDeclerationOrderDateDiv #MainDeclerationOrderDateInput").val(response.OrderDate);
                $("#MainDeclerationOrderPriceDiv #MainDeclerationOrderPriceInput").val(response.OrderPrice);
                $("#MainDeclerationComentDiv #MainDeclerationComentTextArea").text(response.OrderComent);

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



////////////////////////////////////////////////
//User Search
$("#MainPageUserSerchInput").keyup(function () {
    var id = $(this).val().toString();
    AjaxReturnPartialView("GET", "/Search/UserSearch", id, "#MainPageUserSerchDiv");
    console.log(id);
})

//order search
$("#MainPageOrderSerchInput").keyup(function () {
    var id = $(this).val().toString();
    AjaxReturnPartialView("GET", "/Search/BundelSearch", id, "#MainPageOrderSerchDiv");
    console.log(id);
})
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

//function SelectClickedClass(ClickedElement) {heleki lazim deyil
//    $(ClickedElement).on("click", function () {


//        var ElementClass = $(this).attr("class");

//        var HateIndex = ElementClass.lastIndexOf("-");
//        var IdStrig = ElementClass.substring(HateIndex + 1);
//        var IDInt = ElementClass.length - ElementClass.substring(HateIndex).length;
//        var ActivId = ElementClass.substring(0, IDInt);

//        if (IdStrig == "Activ") {
//            console.log($(this).attr("class"));
//            $(this).removeClass($(this).attr("class"));
//            $(this).addClass(ActivId + "-DeActiv");

//        }
//        else {
//            $(this).removeClass($(this).attr("class"))
//            $(this).addClass(ActivId + "-Activ")
//        }

//    })

//};
//$("li").each(function (index) {
//    console.log(index + ": " + $(this).text());
//});