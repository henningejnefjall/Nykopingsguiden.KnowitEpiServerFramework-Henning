$(document).ready(function () {

    if ($("body").hasClass("segora")) {
        $(".sectionChoice").removeClass("sectionChoice").addClass("segora");
    }
    else if ($("body").hasClass("event")) {
        $(".sectionChoice").removeClass("sectionChoice").addClass("event");
    }
    else if ($("body").hasClass("ata")) {
        $(".sectionChoice").removeClass("sectionChoice").addClass("ata");
    }
    else if ($("body").hasClass("bo")) {
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

    $("#eventCreateBtn").click(function (event) {
        event.preventDefault();
        $("#eventCreateContent2").css("display", "block");
        $("#eventCreateContent").css("display", "none");
        $(".gllpLatlonPicker").each(function () {
            $obj = $(document).gMapsLatLonPicker();
            $obj.init($(this));
        });
    });

    $("#eventCreateBtn2").click(function (event) {
        event.preventDefault();
        $("#eventCreateContent").css("display", "block");
        $("#eventCreateContent2").css("display", "none");
    });

        if (window.location.href.indexOf("?companyid") > -1) {
            $(".deleteBtn").css("display", "block");
            $(".inactivateBtn").css("display", "block");
            //SetCompanyCategories();
        }
        else if (window.location.href.indexOf("?eventid") > -1) {
            $(".deleteBtn").css("display", "block");
            SetEventCategories();
        } else {
            $(".deleteBtn").css("display", "none");
            $(".inactivateBtn").css("display", "none");
        }

        $(".clickDelete").click(function () {
            $(".showDelete").css("display", "block");
            //$(".overlay").css("display", "block");
        });
        $("#cancelDelete").click(function() {
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

        //Använda chosen?
        //$("#CompanyCategory").chosen();
        //$("#ConferenceCategory").chosen();
        //$("#EventCategory").chosen();
        //$("#AttractionsCategory").chosen();
        //$("#Companies").chosen();
        //$("#Places").chosen();

       $("#Places").on('change', function() {   
                if ($(this).val() == "Annan") {
                    $(".hidePlace").fadeIn( "slow", function() {});
                } else {
                    $(".hidePlace").fadeOut("slow", function () { });
                }
        });

        var valueSuccess = $(".successText").html();
        if (valueSuccess != "") {
            $(".successText").css("display", "block");
        }
        else {
            $(".successText").css("display", "none");
        }

        var valueNoSuccess = $(".noSuccessText").html();
        if (valueNoSuccess != "") {
            $(".noSuccessText").css("display", "block");
        }
        else{
            $(".noSuccessText").css("display", "none");
        }

        //ValidateCategories();

        $(".imageUpload").click(function (e) {
            
            e.preventDefault();
            var id = "#cropper" + $(this).attr('id');

            $(id).css("display", "block");
            $(".overlay").css("display", "block");
        });

});

//function SetCompanyCategories (){
//    var strCompany = $(".CompanyCategoryString").html();
//    var strConference = $(".ConferenceCategoryString").html();

//    $("#CompanyCategory").val(strCompany.split(',')).trigger("chosen:updated");
//    $("#ConferenceCategory").val(strConference.split(',')).trigger("chosen:updated");
   
//}

function SetEventCategories() {
    var strAttractions = $(".AttractionsCategoryString").html();
    var strEvent = $(".EventCategoryString").html();

    //$("#AttractionsCategory").val(strAttractions.split(',')).trigger("chosen:updated");
    //$("#EventCategory").val(strEvent.split(',')).trigger("chosen:updated");
}


function ValidateCategories() {
    var companyCategoryValid = false;
    $(".createCompany").submit(function(e) {
        $("#CompanyCategory_chosen .search-choice-close").each(function(index) {
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
        geocoder.geocode({ 'address': address }, function(results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                document.getElementById("DefaultLat").value = results[0].geometry.location.lat();
                document.getElementById("DefaultLong").value = results[0].geometry.location.lng();
            } 
        });
    });
}