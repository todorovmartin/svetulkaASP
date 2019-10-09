// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#Search").autocomplete({
    source: "/Home/Search",
    minLength: 3,
    select: function (event, ui) {
        window.location.href = ui.item.url;
    }
});
$('#Search').on('keypress', function (e) {
    if (e.which === 13) {
        window.location.href = '/Home/Index?searchString=' + $('#Search').val();
    }
});