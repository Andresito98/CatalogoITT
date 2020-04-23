// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//validaciones
$('#search-button').on('click', function () {
    var inputOption = $('#search-select option:selected').text();
    var inputText = $('#search-text').val();
    if (inputText == "") {
        alert("¡Por favor ingresa al menos una palabra clave!");
        return false;
    } else {
        var data = { "inputOption": inputOption, "inputText": inputText };
        data = JSON.stringify(data);
        $.post('../Libro/Index', data, function (resp) {
            console.log(resp)
        })
        return true;
    }
});
