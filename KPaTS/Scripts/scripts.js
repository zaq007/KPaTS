function isScrolledIntoView(elem) {
    var $elem = $(elem);
    var $window = $(window);

    var docViewTop = $window.scrollTop() + 56;
    var docViewBottom = docViewTop + $window.height();

    var elemTop = $elem.offset().top;
    var elemBottom = elemTop + $elem.height();

    return (((elemTop >= docViewTop) && (elemTop <= docViewBottom)) || ((elemBottom >= docViewTop) && (elemBottom <= docViewBottom)));
}

function registerScrollTransformation(view, viewTarget, button, origin, destination) {
    $(view).scroll(function () {
        if (!isScrolledIntoView($(viewTarget)) && !$("#test-fab").hasClass("header")) {
            $(button).addClass("transition");
            setTimeout(function () {
                $(button).appendTo($(destination)).addClass("header");
                setTimeout(function () {
                    $(button).removeClass("transition");
                }, 200);
            }, 200);
        }
        else if (isScrolledIntoView($(viewTarget)) && $(button).hasClass("header")) {
            $(button).addClass("transition");
            setTimeout(function () {
                $(button).appendTo($(origin)).removeClass("header");
                setTimeout(function () {
                    $(button).removeClass("transition");
                }, 200);
            }, 200);
        }
    });
}
