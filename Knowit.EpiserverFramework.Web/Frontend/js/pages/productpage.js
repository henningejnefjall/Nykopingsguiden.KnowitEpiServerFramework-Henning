$(document).ready(function () {
    $('.anchor').click(function () {
        $('html, body').animate({
            scrollTop: $($(this).attr('href')).offset().top
        }, 1000);
        return false;
    });

    $('.productpage-navigation').affix({
        offset: {
            top: function () {
                return (this.bottom = $('.vad-navbar').outerHeight(true) + $('.branding-image').outerHeight(true));
            }
        }
    });
});