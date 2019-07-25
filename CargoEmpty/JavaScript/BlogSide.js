/////////////////////////////////////////////////////
//////////////Slider Edit

$(".CaruselDetailsBtn").click(function () {

    var Id = $(this).attr('id')
    var Title = $(this).parent().parent().children()[0].innerText
    var Text = $(this).parent().parent().children()[1].innerText
    var ImagePath = $(this).parent().parent().children()[2].innerText

    $("#CaruselDetailsModalId").val(Id);
    $("#CaruselDetailsModalTitle").val(Title);
    $("#CaruselDetailsModalText").val(Text);
    $("#CaruselDetailsModalImage").attr("src", ImagePath);



})
//////////////////////////////////////////////////////////////////////////////////
$(".CaruselDeleteBtn").click(function () {

    var Id = $(this).attr('id')
    var Title = $(this).parent().parent().children()[0].innerText
    var Text = $(this).parent().parent().children()[1].innerText
    var ImagePath = $(this).parent().parent().children()[2].innerText

    $("#CaruselDeleteModalId").val(Id);
    $("#CaruselDeLeteModalTitle").val(Title);
    $("#CaruselDeLeteModalText").val(Text);

    $("#CaruselDeLeteModalImage").attr("src", ImagePath);



})



/////////////////////////////////////////s/////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////////////////
$(document).ready(function () {
    var Array = [];
    $(".ChecxBoxCarusel input[type = checkbox]").on("click", function () {
        Array.push(ChangeActivClassFromIndex($(this)));

    });
    $("#SaveActiveCaruselsBtn").click(function () {
        AjaxRequestArray("POST", "/Carusel/IsActive", "json", Array);
        Array = [];
    })
   
});

