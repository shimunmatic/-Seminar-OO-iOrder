$(function () {

    $("a.orderItem").click(function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
        console.log(url);
        $("#orderDetailsContainer").load(url);
    });

});

