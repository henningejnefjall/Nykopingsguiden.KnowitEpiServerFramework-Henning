$(document).ready(function () {
    //If page is not productpage
    if (!$(".productpage-navigation").length) {
        $('.vad-navbar').affix({
            offset: {
                top: 1000
            }
        });
    }
});