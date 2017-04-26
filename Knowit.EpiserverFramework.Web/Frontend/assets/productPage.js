webpackJsonp([2],{

/***/ 0:
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(38);


/***/ },

/***/ 38:
/***/ function(module, exports, __webpack_require__) {

	/* WEBPACK VAR INJECTION */(function($) {$(document).ready(function () {
	    $('.anchor').click(function () {
	        $('html, body').animate({
	            scrollTop: $($(this).attr('href')).offset().top
	        }, 1000);
	        return false;
	    });

	    $('.productpage-navigation').affix({
	        offset: {
	            top: function () {
	                return this.bottom = $('.vad-navbar').outerHeight(true) + $('.branding-image').outerHeight(true);
	            }
	        }
	    });
	});
	/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(2)))

/***/ }

});