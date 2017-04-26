webpackJsonp([0],[
/* 0 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(1);


/***/ },
/* 1 */
/***/ function(module, exports, __webpack_require__) {

	//JS
	__webpack_require__(2);

	//SASS
	__webpack_require__(7);

/***/ },
/* 2 */
/***/ function(module, exports, __webpack_require__) {

	//Script
	__webpack_require__(3);
	__webpack_require__(6);

/***/ },
/* 3 */
/***/ function(module, exports, __webpack_require__) {

	/* WEBPACK VAR INJECTION */(function($, jQuery) {/* xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx 
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

	    $("#lb-search .search-btn").click(function () {

	    });

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
	    });

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
	    }).focus(function () {
	        $(this).prev().fadeOut(300);
	    }).blur(function () {
	        if (!this.value) {
	            $(this).prev().fadeIn(300);
	        }
	    });

	    $("input[type=password]").each(function () {
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

	    //// SLICK | WIDE SLIDER
	    //$('.wide-slider').slick({
	    //    lazyLoad: 'ondemand',
	    //    infinite: true,
	    //    fade: true,
	    //    cssEase: 'linear',
	    //    speed: 700,
	    //    autoplay: true,
	    //    autoplaySpeed: 5000,
	    //    slidesToShow: 1,
	    //    slidesToScroll: 1
	    //});

	    //// SLICK | CAROUSEL SLIDER
	    //$('.carousel').slick({
	    //    infinite: true,
	    //    dots: true,
	    //    speed: 400,
	    //    slidesToShow: 3,
	    //    slidesToScroll: 3,
	    //    responsive: [{
	    //        breakpoint: 1041,
	    //        settings: {
	    //            slidesToShow: 2,
	    //            slidesToScroll: 2
	    //        }
	    //    }, {
	    //        breakpoint: 641,
	    //        settings: {
	    //            slidesToShow: 1,
	    //            slidesToScroll: 1
	    //        }
	    //    }]
	    //});

	    //// SLICK | SUB HEADER SLIDER
	    //$('.sub .header-slider').slick({
	    //    lazyLoad: 'ondemand',
	    //    infinite: true,
	    //    fade: true,
	    //    cssEase: 'linear',
	    //    speed: 700,
	    //    autoplay: true,
	    //    autoplaySpeed: 5000,
	    //    slidesToShow: 1,
	    //    slidesToScroll: 1
	    //});

	    //// SLICK | MAIN SLIDER
	    //$('.main-slider').slick({
	    //    lazyLoad: 'ondemand',
	    //    infinite: true,
	    //    fade: true,
	    //    cssEase: 'linear',
	    //    speed: 400,
	    //    autoplay: true,
	    //    autoplaySpeed: 5000,
	    //    slidesToShow: 1,
	    //    slidesToScroll: 1
	    //});
	});
	/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(4), __webpack_require__(4)))

/***/ },
/* 4 */,
/* 5 */,
/* 6 */
/***/ function(module, exports, __webpack_require__) {

	/* WEBPACK VAR INJECTION */(function($) {$(document).ready(function () {

	    if ($("body").hasClass("segora")) {
	        $(".sectionChoice").removeClass("sectionChoice").addClass("segora");
	    } else if ($("body").hasClass("event")) {
	        $(".sectionChoice").removeClass("sectionChoice").addClass("event");
	    } else if ($("body").hasClass("ata")) {
	        $(".sectionChoice").removeClass("sectionChoice").addClass("ata");
	    } else if ($("body").hasClass("bo")) {
	        $(".sectionChoice").removeClass("sectionChoice").addClass("bo");
	    }

	    GetLocation();

	    var valueExctract = $(".ViewbagExtract").html();
	    if (valueExctract != null) {
	        $("#Extract").val(valueExctract.replace("<br/>", /\r?\n/g));
	    }

	    var valueMainBody = $(".ViewbagMainbody").html();
	    if (valueMainBody != null) {
	        $("#MainBody").val(valueMainBody.replace("<br/>", /\r?\n/g));
	    }

	    var valueOpening = $(".ViewbagOpening").html();
	    if (valueOpening != null) {
	        $("#Opening").val(valueOpening.replace("<br/>", /\r?\n/g));
	    }

	    var valueAccess = $(".ViewbagAccess").html();
	    if (valueAccess != null) {
	        $("#Access").val(valueAccess.replace("<br/>", /\r?\n/g));
	    }

	    var valueTripadvisor = $(".ViewbagTripadvisor").html();
	    if (valueTripadvisor != null) {
	        $("#Tripadvisor").val(valueTripadvisor.replace("<br/>", /\r?\n/g));
	    }

	    if (window.location.href.indexOf("?companyid") > -1) {
	        $(".deleteBtn").css("display", "block");
	        $(".inactivateBtn").css("display", "block");
	        SetCompanyCategories();
	    } else if (window.location.href.indexOf("?eventid") > -1) {
	        $(".deleteBtn").css("display", "block");
	        SetEventCategories();
	    } else {
	        $(".deleteBtn").css("display", "none");
	        $(".inactivateBtn").css("display", "none");
	    }

	    $(".clickDelete").click(function () {
	        $(".showDelete").css("display", "block");
	        $(".overlay").css("display", "block");
	    });
	    $("#cancelDelete").click(function () {
	        $(".showDelete").css("display", "none");
	        $(".overlay").css("display", "none");
	    });
	    $(".clickInactivate").click(function () {
	        $(".showInactivate").css("display", "block");
	        $(".overlay").css("display", "block");
	    });
	    $("#cancelInactivate").click(function () {
	        $(".showInactivate").css("display", "none");
	        $(".overlay").css("display", "none");
	    });

	    $("#lnkEULA").click(function (e) {
	        e.preventDefault();
	        $("#EULA").css("display", "block");
	        $(".overlay").css("display", "block");
	    });
	    $(".overlay").click(function () {
	        $("#EULA").css("display", "none");
	        $(".showDelete").css("display", "none");
	        $(".showInactivate").css("display", "none");
	        $(".cropper").css("display", "none");
	        $(".overlay").css("display", "none");
	    });

	   

	    var valueSuccess = $(".successText").html();
	    if (valueSuccess != "") {
	        $(".successText").css("display", "block");
	    } else {
	        $(".successText").css("display", "none");
	    }

	    var valueNoSuccess = $(".noSuccessText").html();
	    if (valueNoSuccess != "") {
	        $(".noSuccessText").css("display", "block");
	    } else {
	        $(".noSuccessText").css("display", "none");
	    }

	    ValidateCategories();

	    $(".imageUpload").click(function (e) {

	        e.preventDefault();
	        var id = "#cropper" + $(this).attr('id');

	        $(id).css("display", "block");
	        $(".overlay").css("display", "block");
	    });
	});

	function SetCompanyCategories() {
	    var strCompany = $(".CompanyCategoryString").html();
	    var strConference = $(".ConferenceCategoryString").html();

	    $("#CompanyCategory").val(strCompany.split(',')).trigger("chosen:updated");
	    $("#ConferenceCategory").val(strConference.split(',')).trigger("chosen:updated");
	}

	function SetEventCategories() {
	    var strAttractions = $(".AttractionsCategoryString").html();
	    var strEvent = $(".EventCategoryString").html();

	    $("#AttractionsCategory").val(strAttractions.split(',')).trigger("chosen:updated");
	    $("#EventCategory").val(strEvent.split(',')).trigger("chosen:updated");
	}

	function ValidateCategories() {
	    var companyCategoryValid = false;
	    $(".createCompany").submit(function (e) {
	        $("#CompanyCategory_chosen .search-choice-close").each(function (index) {
	            companyCategoryValid = true;
	        });
	        if (!companyCategoryValid) {
	            e.preventDefault();
	            $("#CompanyCategory_chosen .chosen-choices").css('border-color', '#FF0000');
	            $("#CompanyCategory-error").css('display', 'inline-block');
	        }
	    });

	    var eventCategoryValid = false;
	    $(".createEvent").submit(function (e) {
	        $("#EventCategory_chosen .search-choice-close").each(function (index) {
	            eventCategoryValid = true;
	        });
	        if (!eventCategoryValid) {
	            e.preventDefault();
	            $("#EventCategory_chosen .chosen-choices").css('border-color', '#FF0000');
	            $("#EventCategory-error").css('display', 'inline-block');
	        }
	    });
	}

	function GetLocation() {
	    $("#Address").change(function () {
	        var geocoder = new google.maps.Geocoder();
	        var address = $("#Address").val();
	        geocoder.geocode({ 'address': address }, function (results, status) {
	            if (status == google.maps.GeocoderStatus.OK) {
	                document.getElementById("DefaultLat").value = results[0].geometry.location.lat();
	                document.getElementById("DefaultLong").value = results[0].geometry.location.lng();
	            }
	        });
	    });
	}
	/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(4)))

/***/ },
/* 7 */
/***/ function(module, exports) {

	// removed by extract-text-webpack-plugin

/***/ }
]);