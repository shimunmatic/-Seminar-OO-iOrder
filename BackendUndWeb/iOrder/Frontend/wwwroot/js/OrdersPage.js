$(function () {

    // track width, set to window width
    var height = $(window).height();
    var ordersList = $("#ordersList");
    ordersList.css('max-height', (height - 100) +'px');

    $(window).resize(function () {
        if ($(window).height() == height) return;
        height = $(window).height();
        var newheight = height - 100;
        ordersList.css('max-height', newheight+'px');
    });

});

