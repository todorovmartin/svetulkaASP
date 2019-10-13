﻿var TeamDetailPostBackURL = '/Products/Details';
$(function () {
    $(".anchorDetail").click(function () {
        debugger;
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamDetailPostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                debugger;
                $('#myModalContent').html(data);
                $('#myModal').modal(options);
                $('#myModal').modal('show');

            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });

    //$("#closbtn").click(function () {
    //    $('#myModal').modal('hide');
    //});

    $("body").click(function () {
        if (!$(event.target).closest('.modal').length && !$(event.target).is('.modal')) {
            $('#myModal').modal('hide');
        }
    });
});