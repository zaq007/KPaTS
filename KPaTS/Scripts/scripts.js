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

$(document).ready(function () {
    $(".search-card").on("focus", ".mdl-textfield__input", function () {
        $(this).parents(".search-card").addClass("focused");
    });

    $(document).click(function (event) {
        var x = event.clientX, y = event.clientY,
        elementMouseIsOver = document.elementFromPoint(x, y);
        if (!($(".search-card").has($(elementMouseIsOver)).length > 0))
            $(".search-card").removeClass("focused");
    });

    $(".search-card").on("click", ".expandable-content", function () {
        var content = $(this).children(".expandable");
        $.get("/Api/PreviewInfo", { infoGuid: $(this).data("entry-id") }, function (data) {
            content.find(".body").html(data)
        })

        content.addClass("mdl-shadow--8dp mdl-color--white expanding")
        setTimeout(function () {
            var offset = content.offset()
            var width = content.width;
            content.appendTo("body").css({ "width": width, "position": "fixed", "top": offset.top, "left": offset.left, "transition": "none", "z-index": "9999" });
            content.animate({
                "width": $(".search-card").outerWidth(true),
                "height": $(".search-card").outerHeight(true),
                "top": $(".search-card").offset().top,
                "left": $(".search-card").offset().left
            }, 300, "easeOutCubic", function () {
                content.appendTo(".search-card").attr("style", "").addClass("is-expanded").removeClass("expanding");
            });
            content.children(".header").animate({
                "padding": "8px",
                "font-size": "20px",
                "font-weight": "500"
            }, 300);
        });
    });

    $(".search-card").on("click", ".close-preview", function () {
        var content = $(this).parents(".expandable");
        var target = $(".search-card").find(".expandable-content[data-entry-id='" + content.data("entry-id") + "']");

        var offset = content.offset()
        var width = content.width
        content.addClass("expanding")
        content.removeClass("is-expanded").appendTo("body").css({ "width": width, "position": "fixed", "top": offset.top, "left": offset.left, "transition": "none", "z-index": "9999" });
        content.animate({
            "width": target.outerWidth(true),
            "height": target.outerHeight(true),
            "top": target.offset().top,
            "left": target.offset().left
        }, 300, "easeOutCubic", function () {
            content.removeClass("mdl-shadow--8dp mdl-color--white").removeClass("expanding")
            setTimeout(function () {
                content.attr("style", "").appendTo(target);
            }, 300)
        });
        content.children(".header").animate({
            "padding": "0px",
            "font-size": "13px",
            "font-weight": "normal"
        }, 300);
    });
});
