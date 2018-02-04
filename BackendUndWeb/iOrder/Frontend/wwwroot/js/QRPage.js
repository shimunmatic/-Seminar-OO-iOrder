$(function () {

    // track width, set to window width
    var height = $(window).height();
    var ordersList = $("#locationsList");
    var wrapper = $("#qrPlaceholderWrapper");
    ordersList.css('max-height', (height - 100) + 'px');
    wrapper.css('height', (height - 100) + 'px');

    $(window).resize(function () {
        if ($(window).height() == height) return;
        height = $(window).height();
        var newheight = height - 100;
        ordersList.css('max-height', newheight + 'px');
        wrapper.css('height', newheight + 'px');
    });

});
