/* xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx 
	NYKOPINGSGUIDEN | GLOBAL.JS
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx */



// SCROLL TO TOP
function scrollToTop() {
    $('html, body').animate({
        scrollTop: $('#site').offset().top
    }, 500);
}

// LOAD/UNLOAD EVENT MAP | ps-eventguide
function loadMap(url) {
    $url = url;
    $("#mapiframe").attr("src", $url);
}
function unloadMap() {
    $("#mapiframe").attr("src", "");
}

/* PRINT CONTENT 

.sub-content-footer > print-button  

Print: #sub-content 

*/

function printContent(elementID) {

    var printElement = document.getElementById(elementID).outerHTML;
    var webPage = document.body.innerHTML;

    document.body.innerHTML = printElement;

    window.print();

    document.body.innerHTML = webPage;
    location.reload();

}

/* ========================================================================== 
   DOCUMENT READY  
================================|========================================= */

jQuery(document).ready(function ($) {



    // ANDROID
    var is_Android = /(android)/i.test(navigator.userAgent);
    if (is_Android) {
        $('html, body').addClass("android");
    }

    // IPHONE
    var is_iPhone = /(iPhone)/i.test(navigator.userAgent);
    if (is_iPhone) {
        $('html, body').addClass("iphone");
    }



    // LB SEARCH BUTTON
    $('#lb-search .search-btn').val("\uf002");
    $('.search-result .search-form .search-btn').val("\uf002");

    // Show Header Search Form 
    $(".header-search-btn").click(function () {
        $("#lb-search").fadeIn(400);
        $("#lb-search .search-field").focus();
    });
    // Hide Header Search Form 
    $("#lb-search .lb-overlay").click(function () {
        $("#lb-search").fadeOut(400);
    });
    $("#lb-search .close").click(function () {
        $("#lb-search").fadeOut(400);
    });



    // PORTABLE NAV
    // Show LB Portable Nav 
    $(".header-port-menu-btn").click(function () {
        $("#port-menu").fadeIn(400);
        $("#port-menu").addClass("active");
    });
    // Hide LB Portable Nav 
    $("#port-menu .lb-overlay").click(function () {
        $(".header-port-menu-btn").fadeIn(400);
        $("#port-menu").fadeOut(400);
        $("#port-menu").removeClass("active");
    });
    $("#port-menu .close").click(function () {
        $(".header-port-menu-btn").fadeIn(400);
        $("#port-menu").fadeOut(400);
        $("#port-menu").removeClass("active");
    });



    // PORTABLE MENU SETUP
    (function () {

        if ($(".port-main-menu").length) {

            // SETUP MENU
            $(".port-main-menu ul ul").each(function () {
                var submenu = $(this);
                submenu.hide();
                submenu.addClass('sub-menu');
                submenu.parent().addClass('has-children');
                submenu.parent().find('a:first').wrap('<div class="toggle-row"></div>');
                submenu.parent().find('a:first').after('<div class="toggle"></div>');
            });

            $(".port-main-menu ul li").each(function () {
                var checkactivepage = $(this);
                if (checkactivepage.hasClass("current-menu-item")) {
                    $(this).addClass("exp");
                    $(this).parents("li").addClass("current-menu-parent exp");
                    $(this).parents("ul").show();
                    $(this).find(".sub-menu:first").show();
                };
            });

            // SUB MENU TOGGLE SLIDE
            $(".port-main-menu ul .toggle").click(function () {

                var slideMenu = $(this).parent().parent().find(".sub-menu:first");

                if ($(this).parent().parent().hasClass("exp")) {
                    $(slideMenu).slideUp();
                    $(this).parent().parent().removeClass("exp");
                } else {
                    $(this).parent().parent().addClass("exp");
                    $(slideMenu).slideDown();
                }

            });

        }

    })();

    // SET MAIN MENU MIN HEIGHT
    var docheight = $(document).height();
    $('.port-menu-box').css('min-height', docheight);



    // SUB NAV SETUP
    (function () {

        if ($(".sub-nav").length) {

            // SETUP MENU
            $(".sub-nav ul ul").each(function () {
                var submenu = $(this);
                submenu.hide();
                submenu.addClass('sub-menu');
                submenu.parent().addClass('has-children');
                submenu.parent().find('a:first').wrap('<div class="toggle-row"></div>');
                submenu.parent().find('a:first').after('<div class="toggle"></div>');
            });

            $(".sub-nav ul li").each(function () {
                var checkactivepage = $(this);
                if (checkactivepage.hasClass("current-menu-item")) {
                    $(this).addClass("exp");
                    $(this).parents("li").addClass("current-menu-parent exp");
                    $(this).parents("ul").show();
                    $(this).find(".sub-menu:first").show();
                };
            });

            // SUB MENU TOGGLE SLIDE
            $(".sub-nav ul .toggle").click(function () {

                var slideMenu = $(this).parent().parent().find(".sub-menu:first");

                if ($(this).parent().parent().hasClass("exp")) {
                    $(slideMenu).slideUp();
                    $(this).parent().parent().removeClass("exp");
                } else {
                    $(this).parent().parent().addClass("exp");
                    $(slideMenu).slideDown();
                }

            });

        }

    })();



    // BREADCRUMB NAV SUB MENU
    (function () {

        if ($("#breadcrumb-nav").length) {

            $("#breadcrumb-nav a.parent").mouseover(function () {
                $(this).next().show();
            });

            $("#breadcrumb-nav a.parent").mouseout(function () {
                $(this).next().hide();
            });

            $("#breadcrumb-nav ul ul").mouseover(function () {
                $(this).show();
            });

            $("#breadcrumb-nav ul ul").mouseout(function () {
                $(this).hide();
            });

        }

    })();



    // MAIN ARTICLE INFO CALENDAR
    $("#main-article-info-calendar a.show").click(function () {
        $(this).parent().addClass("active");
    });
    $("#main-article-info-calendar a.hide").click(function () {
        $(this).parent().removeClass("active");
    });



    // SCROLL UP BUTTON
    $(window).scroll(function () {
        if ($(this).scrollTop() > 800) {
            $('.scroll-up-btn').addClass("active");
        } else {
            $('.scroll-up-btn').removeClass("active");
        }
    });

    $('.scroll-up-btn').click(function (event) {
        event.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, 500);
        return false;
    })



    // LB CONTACT FORM
    $(".show-lb-contact").click(function () {
        $("#lb-contact").fadeIn(400);
        scrollToTop();
    });
    // Hide LB Contact 
    $("#lb-contact .lb-overlay").click(function () {
        $("#lb-contact").fadeOut(400);
    });
    $("#lb-contact .lb-close").click(function () {
        $("#lb-contact").fadeOut(400);
    });

    // FORM LABEL TOGGLE
    //$("input[type=text]").each(function () {
    //    if (this.value) {
    //        $(this).prev().fadeOut(300);
    //    }
    //})
    //.focus(function () {
    //    $(this).prev().fadeOut(300);
    //})
    //.blur(function () {
    //    if (!this.value) {
    //        $(this).prev().fadeIn(300);
    //    }
    //});

    $("input[type=email]").each(function () {
        if (this.value) {
            $(this).prev().fadeOut(300);
        }
    })
	.focus(function () {
	    $(this).prev().fadeOut(300);
	})
	.blur(function () {
	    if (!this.value) {
	        $(this).prev().fadeIn(300);
	    }
	});

    $("input[type=password]").each(function () {
        if (this.value) {
            $(this).prev().fadeOut(300);
        }
    })
	.focus(function () {
	    $(this).prev().fadeOut(300);
	})
	.blur(function () {
	    if (!this.value) {
	        $(this).prev().fadeIn(300);
	    }
	});

    $("textarea").each(function () {
        if (this.value) {
            $(this).prev().fadeOut(300);
        }
    }).focus(function () {
        $(this).prev().fadeOut(300);
    }).blur(function () {
        if (!this.value) {
            $(this).prev().fadeIn(300);
        }
    });

    // SLICK | WIDE SLIDER
    $('.wide-slider').slick({
        lazyLoad: 'ondemand',
        infinite: true,
        fade: true,
        cssEase: 'linear',
        speed: 700,
        autoplay: true,
        autoplaySpeed: $(this).data('sliderautoplayinterval'),
        slidesToShow: 1,
        slidesToScroll: 1
    })
    .on("afterChange", function (e, slick) {
        $('.wide-slider').slick('setOption', 'autoplaySpeed', $(this).data('sliderautoplayinterval'));
    });

    // SLICK | CAROUSEL SLIDER
    $('.carousel').slick({
        infinite: true,
        dots: true,
        speed: 400,
        slidesToShow: 3,
        slidesToScroll: 3,
        responsive: [
           {
               breakpoint: 1041,
               settings: {
                   slidesToShow: 2,
                   slidesToScroll: 2
               }
           },
           {
               breakpoint: 641,
               settings: {
                   slidesToShow: 1,
                   slidesToScroll: 1
               }
           }
        ]
    });

    // SLICK | SUB HEADER SLIDER
    $('.sub .header-slider').slick({
        lazyLoad: 'ondemand',
        infinite: true,
        fade: true,
        cssEase: 'linear',
        speed: 700,
        autoplay: true,
        autoplaySpeed: $(this).data('sliderautoplayinterval'),
        slidesToShow: 1,
        slidesToScroll: 1
    })
    .on("afterChange", function (e, slick) {
        $('.sub .header-slider').slick('setOption', 'autoplaySpeed', $(this).data('sliderautoplayinterval'));
    });

    // SLICK | MAIN SLIDER
    $('.main-slider').slick({
        lazyLoad: 'ondemand',
        infinite: true,
        fade: true,
        cssEase: 'linear',
        speed: 400,
        autoplay: true,
        autoplaySpeed: 5000,
        slidesToShow: 1,
        slidesToScroll: 1
    });
});
