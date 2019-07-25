$(document).ready(function () {

$(".CheckedRole").on("click", function () {
    if ($(this).prop('checked'))
    {
        var input = ' <input type="hidden" name="UserRoles" id="Activ-' + $(this).attr("data-Id") +'" value="Activ-' + $(this).attr("data-Id") + '" />';
        $("#UserRolesDiv").append(input);
    }
    else
    {     
        $("#Activ-" + $(this).attr("data-Id")).remove();
       
    }  
    })

    $(".DeleteCheckedRole").on("click", function () {

        if ($(this).prop('checked')) {
            var input = ' <input type="hidden" name="UserRoles" id="DeActiv-' + $(this).attr("data-Id") + '" value="DeActiv-' + $(this).attr("data-Id") + '" />';
            $("#UserRolesDiv").append(input);
        }
        else {
            $("#DeActiv-" + $(this).attr("data-Id")).remove();            
        }
    })

})