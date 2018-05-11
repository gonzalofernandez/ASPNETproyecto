
//Función que obtiene el formulario del elemento correspondiente 
function details(elemId, compName) {
    jQuery.ajax({
        //url: '@Url.Action("Show", "ElementoController")',
        url: "/elemento/show/{data}",
        method: "get",
        cache: false,
        data: { compName: compName, elemId: elemId }
    }).done(function (result) {
        $('#formulario').html(result);
    });
}
