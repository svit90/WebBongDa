/**
 * Function common START
 */

function setCookie(key, value) {
    var expires = new Date();
    expires.setTime(expires.getTime() + (1 * 24 * 60 * 60 * 1000));
    document.cookie = key + '=' + value + ';expires=' + expires.toUTCString();
}

function getCookie(key) {
    var keyValue = document.cookie.match('(^|;) ?' + key + '=([^;]*)(;|$)');
    return keyValue ? keyValue[2] : null;
}

function clearCookie(key) {
    var expires = new Date();
    expires.setTime(-1);
    document.cookie = key + '=' + "" + ';expires=' + expires.toUTCString();
}

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function formatTimeAgo(_class_name) {
    var i = 0;
    $("."+ _class_name).each(function () {
        if (i > 5) {
            $(this).text(moment(new Date($(this).text())).calendar());
        } else {
            $(this).text(moment(new Date($(this).text())).fromNow());
        }
        i++;
    });
}

function formatTime(_class_name) {
    var $scope = {};
    $("." + _class_name).each(function () {
        $scope.date = new Date($(this).text());
        $scope.moment = moment($scope.date);
        $(this).text($scope.moment.format('DD MMMM YYYY HH:mm'));
    });
}

function clearSummernote(_modal, _class) {
    $('#' + _modal).modal('hide');
    $('.' + _class).summernote('code', '');
}
//function encrypted(_text) {   
//    var key = CryptoJS.enc.Utf8.parse('07032021');
//    var iv = CryptoJS.enc.Utf8.parse('07032021');
//    var encryptedlogin = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(_text), key,
//        { keySize: 128 / 8, iv: iv, mode: CryptoJS.mode.CBC, padding: CryptoJS.pad.Pkcs7 });

//    return encryptedlogin; 
//}

function fccount(_class_name) {
    var i = 0;
    $("." + _class_name).each(function () {       
        i++;
    });
    $(".count-" + _class_name).text(i);
}

// check if browser support HTML5 local storage
function localStorageSupport() {
    return (('localStorage' in window) && window['localStorage'] !== null)
}

function CloseModalShare() {
    $('#ShareModal').modal('hide')
};

function showerror(msg, title, type, pos) {
    var $toastlast;
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "progressBar": true,
        "preventDuplicates": false,
        "positionClass": pos,
        "onclick": null,
        "showDuration": "400",
        "hideDuration": "1000",
        "timeOut": "7000",
        "extendedTimeOut": "1000",
        "width": "600",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
    var $toast = toastr[type](msg, title);
    $toastlast = $toast;
}

function getUserLocation() {

    var flickerAPI = "https://jsonip.com/";
    var IPAddress = ""; var str = "";
    $.getJSON(flickerAPI, {
        tags: "ip",
        tagmode: "any",
        format: "json"
    }).done(function (data) {
        IPAddress = data.ip;
        //var uri_1 = "http://api.ipstack.com/";
        //var access_key_1 = 'da07864e4f5506da881b236b57f43dc4';
        //var uri_2 = "http://api.ipapi.com/";
        //var access_key_2 = '2fe0c1d5b9e2f6c8c70d49cd2eecbc51';

        if (IPAddress === "115.73.214.199" || IPAddress === "118.69.224.243" || IPAddress === "118.69.224.168") {
            str = "Imm Group Building, Số 99 Nguyễn Đình Chiểu, Phường 6, Quận 3, TP. HCM";
        } else if (IPAddress === "118.70.171.215") {
            str = "Lotte Center, 54 Liễu Giai, Quận Ba Đình, Hà Nội";
        } else {
            str = "Bạn đang truy cập hệ thống từ bên ngoài văn phòng Imm Group";
        }

        $("#label_IPAddress").text(IPAddress);
        $("#lb_Location").text(str);
        $("#txt_IPAddress").val(IPAddress);
        // get the API result via jQuery.ajax
        //$.ajax({
        //    url: "http://api.ipapi.com/" + data.ip + "?access_key=2fe0c1d5b9e2f6c8c70d49cd2eecbc51&format=1",
        //    dataType: 'jsonp',
        //    success: function (json) {
        //        str = json.region_name + " , " + json.city + " , " + json.country_name;
        //        if (json.ip === "115.73.214.199" || json.ip === "118.69.224.243" || json.ip === "118.69.224.168") {
        //            str = "Imm Group Building, Số 99 Nguyễn Đình Chiểu, Phường 6, Quận 3, TP. HCM";
        //        }
        //        if (json.ip === "118.70.171.215") {
        //            str = "Lotte Center, 54 Liễu Giai, Quận Ba Đình, Hà Nội";
        //        }

        //        $("#label_IPAddress").text(json.ip);
        //        $("#lb_Location").text(str);
        //        $("#txt_IPAddress").val(json.ip);
        //    }
        //});
    });
}

function load_user_infor() {
    var email = getCookie("Email");
    var fullname = getCookie("FullName");
    var token = getCookie("Token");
    $("#img_avatar").attr('src', "/Content/img/avatar/" + token + ".jpg");
    $("#lb_userName").val(fullname);
    $("#lb_Email").val(email);
    $("#link_profile").attr('href', "/staff/profile/" + token);
}

function showHeaderPage(parent, curent) {
    var str = "";
    var arr = parent.split("/");
    $("#pageHeading").empty();
    $("#pageHeading").append("<h2>" + curent + "</h2>");
    var ol = "<ol class=\"breadcrumb\">";
    $.each(arr, function (index, value) {
        str += "<li class=\"breadcrumb-item\"><a href=\"#\">" + value + "</a></li>";
    });
    str += "<li class=\"breadcrumb-item active\"><strong>" + curent + "</strong></li>";
    $("#pageHeading").append(ol + str + "</ol>");
}

/**
 * Function common END
 */





// Menu - Bar  Init START
function load_control_menu() {
    var token = getCookie("Token");
    var flickerAPI = "https://api.immgroup.com/crm/menu/all/" + token +"/";
    $.getJSON(flickerAPI, {
        format: "json"
    }).done(function (data) {
        var str = "";
        str = create_menu_control("0","Trang chủ", "0", data);
        $("#side-menu").append(str);
        str = "";

        var sideMenu = $('#side-menu').metisMenu();
        sideMenu.on('shown.metisMenu', function (e) {
            fix_height();
        });
    });

}

function create_menu_control(mode, parent, level, data) {
    if(level === "0") {level = "first";}else if(level === "first") {level = "second";}else if(level === "second") {level = "third";}
    var str = "";
    if (mode === "0") {
        jQuery.each(data, function (i, val) {
            var arrow = "<span class=\"fa arrow\"></span>";
            if (val.ParentKey === "0") {
                var str_sub = create_menu_control(val.PriKey, parent +"/"+ val.MenuName, level, data);
                if (str_sub === "") {
                    arrow = "";
                }
                str += "<li id=\"li_" + val.PriKey + "\">";
                if (val.MenuFunction !== "") {
                    var func = val.MenuFunction.replace("+", "'");
                    str += "<a href=\"#\" onclick=\"" + func + "\"><i class=\"" + val.MenuIcon + "\"></i> <span class=\"nav-label\">" + val.MenuName + "</span> " + arrow;
                } else {
                    str += "<a href=\"" + val.MenuUrl + "\"><i class=\"" + val.MenuIcon + "\"></i> <span class=\"nav-label\">" + val.MenuName + "</span> " + arrow;
                }
                

                str += "</a> ";
                str += str_sub;
                str += "</li>";
            }
        });
    } else {
        var str_sub = "";
        var ul = "<ul class=\"nav nav-" + level + "-level collapse\">";
        jQuery.each(data, function (i, val) {
            var arrow = "<span class=\"fa arrow\"></span>";
            if (val.ParentKey === mode) {
                var str_sub_child = create_menu_control(val.PriKey, parent + "/" + val.MenuName, level, data);
                if (str_sub_child === "") {
                    arrow = "";
                }
                str_sub += "<li id=\"li_" + val.PriKey + "\">";
                if (val.MenuFunction !== "") {
                    var func = val.MenuFunction.replace("+", "'");
                    str_sub += "<a href=\"#\" onclick=\"" + func + "\"> <i class=\"" + val.MenuIcon + "\"></i>" + val.MenuName + arrow;
                } else {
                    str_sub += "<a href=\"" + val.MenuUrl + "\"> <i class=\"" + val.MenuIcon + "\"></i>" + val.MenuName + arrow;
                }
                
                str_sub += "</a > ";
                str_sub += str_sub_child;
                str_sub += "</li>";
            }
        });
        if (str_sub !== "") {
            str += ul + str_sub + "</ul>";
        }        
    }
    return str;
}

function load_noti_fromcus() {
    var str = "";
    var token = getCookie("Token");
    var flickerAPI = "https://api.immgroup.com/crm/get/notification/c/" + token;
    $.getJSON(flickerAPI, {
        format: "json"
    }).done(function (data) {
        var count = 0;
        jQuery.each(data, function (i, val) {
            str += `<div class="item feed-element cursor-trans" onclick="viewConversation('${val.NotiId}', '${val.CusId}');">
                        <a class="float-left p-0" href="profile.html">
                            <img alt="image" class="rounded-circle" src="/Content/img/avatar/cus_default_avatar.png">
                        </a>
                    <div class="media-body ">
                        <small class="float-right noti-date">${moment(new Date(val.NotiDate)).fromNow()}</small>
                        <strong>${val.CusName}</strong> gửi cho bạn một phản hồi <br>
                        <i class="fa fa-clock-o"></i> <small class="text-muted">${moment(new Date(val.NotiDate)).format('DD MMMM YYYY HH:mm')}</small>
                        <div class="well p-0 m-t-1">
                            ${val.NotiDescript}
                        </div>
                    <div class="float-right">`;
            if (val.SeenTick !== "") {
                str += `<a href="" class="btn btn-xs btn-white badge badge-warning seentick-c"><i class="fa fa-eye"></i> New </a>`;
                count++;
            } else {
                str += `<a href="" class="btn btn-xs btn-white badge badge-primary"><i class="fa fa-check"></i> Seen </a>`;
            };
            str += `</div></div></div>`;
           
        })
        $(".noti-f-cus").append(str);
        formatTimeAgo("time-noti-cus");  
        $("#count_notifromcus").text(count);
        //fccount("new-feed-cus");
    });
    
}
function load_noti_fromsys() {
    var str = "";
    var token = getCookie("Token");
    var flickerAPI = "https://api.immgroup.com/crm/get/notification/s/" + token;
    $.getJSON(flickerAPI, {
        format: "json"
    }).done(function (data) {
        var count = 0;
        jQuery.each(data, function (i, val) {       
            if (val.CaseMode === "Staff-handle-Cus") {
                str += `<div class="item feed-element cursor-trans" onclick="viewNotification('${val.CaseMode}','${val.NotiId}', '${val.CusId}');">`;
            } else {
                str += `<div class="item feed-element cursor-trans" onclick="viewNotification('${val.CaseMode}','${val.NotiId}', '${val.NotiDetails}');">`;
            }
            str += `<a class="dropdown-item float-left p-0" href="/customer/profile/${val.CusId}">
                        <img alt="image" class="rounded-circle" src="/Content/img/avatar/${val.StaffSendAvatar}">
                    </a>
                    <div class="media-body ">
                        <small class="float-right noti-date">${moment(new Date(val.NotiDate)).fromNow()}</small>
                        <strong>${val.StaffSendName}</strong>  ${val.NotiDescript}
                        `;
            if (val.CaseMode === "Staff-handle-Cus") {
                str += `<div class="text-small text-muted">${val.CusName}</div>`;
            };
            str += `<i class="fa fa-clock-o"></i> <small class="text-muted">${moment(new Date(val.NotiDate)).format('DD MMMM YYYY HH:mm')}</small>
                                <div class="float-right">`;
            if (val.SeenTick !== "") {
                str += ` <a href="" class="btn btn-xs btn-white badge badge-warning seentick-s"><i class="fa fa-eye"></i> New </a>`;
                count++;
            } else {
                str += ` <a href="" class="btn btn-xs btn-white badge badge-primary"><i class="fa fa-check"></i> Seen </a>`;
            };
            str += `</div></div></div>`;
        })
        $(".noti-f-sys").append(str);
        formatTimeAgo("time-noti-sys");
        $("#count_notifromsys").text(count);
        //fccount("new-feed-sys");
    });
}

function noti_Seenall(_mode) {
    var _class_name = "seentick-c";
    var form = new FormData
    form.append("_mode", _mode);
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/function/noti/seen/all", true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            if (_mode === "c") {
                $("#count_notifromcus").text(0);               
                _class_name = "seentick-c";
            } else {
                $("#count_notifromsys").text(0);
                _class_name = "seentick-s";
            }           
            $("." + _class_name).each(function () {
                $(this).empty();
                $(this).removeClass("badge-warning");
                $(this).removeClass("badge-primary");
                $(this).html('<i class="fa fa-check"></i> Seen');
            });
        }
    };
    xhr.send(form);
}

function check_access_page(pageid) {
    var str = "";
    var token = getCookie("Token");
    var flickerAPI = "https://api.immgroup.com/crm/check/func/" + token  + "/" + pageid;
    $.getJSON(flickerAPI, {
        format: "json"
    }).done(function (data) {
        if (data.length === 0) window.location.href = "/error?m=Bạn không có quyền truy cập chức năng này.";
    });
}

function check_access_function(code, res) {
    var token = getCookie("Token");
    var flickerAPI = "https://api.immgroup.com/crm/check/func/" + token + "/" + code;
    $.getJSON(flickerAPI, {
        format: "json"
    }).done(function (data) {
        if (data.length === 0) //window.location.href = "/error?m=Bạn không có quyền truy cập chức năng này.";
        {
            //swal("Something Wrong!", "Bạn không có quyền truy cập chức năng này.", "error");
            return res = "false";
        } else {
            return res = "true";
        }
    });
}

function check_access_control() {
    $(".check-access-func").each(function () {
        var _code = $(this).attr("data-func");
        var control = $(this);
        var token = getCookie("Token");
        var flickerAPI = "https://api.immgroup.com/crm/check/func/" + token + "/" + _code;
        $.getJSON(flickerAPI, {
            format: "json"
        }).done(function (data) {
            if (data.length === 0) {
                control.remove();
            }
        });
    });
}


function viewConversation(feedId, cusId) {
    var form = new FormData
    form.append("_feedid", feedId);        
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/customer/conversation/" + feedId +"/seen", true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            window.location = "/customer/c/conversation/" + cusId;
        }
    };
    xhr.send(form);

}

function auto_save_compse() {
    if ($('#t_e_content').summernote('isEmpty') !== true) {
        var content = $('#t_e_content').summernote('code');
        var form = new FormData();
        form.append("content", content);
        //AJAX REQUEST
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/customer/conversation/autosave/draft", true);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {

            }
        };
        xhr.send(form);
    }
}

function viewNotification(CaseMode, NotiId, Target) {
    var form = new FormData
    form.append("_NotiId", NotiId);
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/staff/notification/" + NotiId +"/seen", true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            if (CaseMode === "Staff-handle-Cus") {
                window.location = "/customer/profile/" + Target;
            } else {
                window.location = Target;
            }
           
        }
    };
    xhr.send(form);

}
// Menu - Bar Init END 

function verify_func_asign(code) {
    var str = "";
    var token = getCookie("Token");
    var flickerAPI = "https://api.immgroup.com/crm/check/func/" + token + "/" + code;
    $.getJSON(flickerAPI, {
        format: "json"
    }).done(function (data) {
        jQuery.each(data, function (i, val) {            
            if (val.SfaSignFlag === 1) {
                return true;
            }           
        })       
    });
    return false;
}

function rightToolsClick(_mode, _cus) {
    var tit = "";
    var text = "";
    var _noti = "";
    var _cusname = $("#cusname").val();
    switch (_mode) {
        case "reback":
            tit = "Bạn có chắc chắn muốn trả lại saleleads này? ";
            text = "Bạn sẽ không thể tương tác với khách " + _cusname + " sau khi trả lại";
            _noti = "ngừng chăm sóc và trả lại khách";
            break;
        case "sendinfo":
            tit = "Gửi thông tin đăng nhập cho khách hàng?";
            text = "Thông tin đăng nhập vào hệ thống web CRM và trên app IMM Group sẽ được gửi đến khách  " + _cusname + "  bằng email của bạn";
            _noti = "gửi thông tin đăng nhập vào hệ thống cho khách";
            break;
        case "redel":
            tit = "Bạn có chắc chắn muốn đề xuất xóa saleleads này?";
            text = "Bạn sẽ không thể tương tác với khách  " + _cusname + "  sau khi đề xuất xóa";
            _noti = "đề xuất xoá hồ sơ khách";
            break;
        case "delete":
            tit = "Bạn có chắc chắn muốn xóa hồ sơ này?";
            text = "Khách  " + _cusname + "  sẽ bị xoá hoàn toàn khỏi hệ thống, không thể truy cập được nữa";
            _noti = "xoá hồ sơ khách";
            break;
    }
    swal({
        title: tit,
        text: text,
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes",
        closeOnConfirm: false
    }, function () {
        var form = new FormData();
        form.append("_cusid", _cus);
        form.append("_mode", _mode);
        form.append("_noti", _noti);
        //AJAX REQUEST
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/customer/profile/" + _cus + "/act/" + _mode, true);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                var res = xhr.responseText;
                var j_res = JSON.parse(res);
                if (j_res.type === "success") {
                    b.ladda('stop');
                    $(".escape").toggleClass("d-none");
                    $(".escape").removeClass("escape");
                    swal({ title: j_res.header, text: j_res.mess, type: j_res.type },
                        function () { location.reload(); }
                    );
                } else {
                    swal({ title: j_res.header, text: j_res.mess, type: j_res.type });
                }
            }
        };
        xhr.send(form);
    });
}

function viewFileattach(_url) {
    $("#frameDocument").attr("src", _url);
    $("#DocumentViewModal").modal("show");
};

function formatNumber(n) {
    // format number 1000000 to 1,234,567
    return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
}

function formatCurrency(input, blur) {
    // appends $ to value, validates decimal side
    // and puts cursor back in right position.

    // get input value
    var input_val = input.val();

    // don't validate empty input
    if (input_val === "") { return; }

    // original length
    var original_len = input_val.length;

    // initial caret position 
    var caret_pos = input.prop("selectionStart");

    // check for decimal
    if (input_val.indexOf(".") >= 0) {

        // get position of first decimal
        // this prevents multiple decimals from
        // being entered
        var decimal_pos = input_val.indexOf(".");

        // split number by decimal point
        var left_side = input_val.substring(0, decimal_pos);
        var right_side = input_val.substring(decimal_pos);

        // add commas to left side of number
        left_side = formatNumber(left_side);

        // validate right side
        right_side = formatNumber(right_side);

        // On blur make sure 2 numbers after decimal
        //if (blur === "blur") {
        //    right_side += "00";
        //}

        // Limit decimal to only 2 digits
        right_side = right_side.substring(0, 2);

        // join number by .
        input_val = "$ " + left_side + "." + right_side;

    } else {
        // no decimal entered
        // add commas to number
        // remove all non-digits
        input_val = formatNumber(input_val);
        input_val = "$ " + input_val;

        // final formatting
        //if (blur === "blur") {
        //    input_val += ".00";
        //}
    }

    // send updated string to input
    input.val(input_val);

    // put caret back in the right position
    var updated_len = input_val.length;
    caret_pos = updated_len - original_len + caret_pos;
    input[0].setSelectionRange(caret_pos, caret_pos);
}

// Config box

function CallModal(src) {
    $("#ifrmcompose").attr('src', src);
    $("#ShareModal").modal("show");
}

function checkAccessProfile() {
    var _token = getCookie("Token");
    var _id = getCookie("Id");
    var _cusid = $("#cusid").val();
    var _cusname = $("#hovaten").val();
    var _flagappinstall = $("#ifrmsmallchat").attr("data-attr");
    if (_token != "" && _id != "" && _cusid != "") {

        if (_flagappinstall == "1") {
            var linkchat = "https://imm-crm.firebaseapp.com/chat/c/staffs/" + _token + "/customers/" + $("#ifrmsmallchat").attr("data-rowid") + "/popup/";
            $("#ifrmsmallchat").attr('src', linkchat)
        } else {
            $(".open-small-chat").addClass("not-app");
            $(".open-small-chat").attr('data-original-title', 'Khách hàng chưa cài đặt ứng dụng hoặc chưa đăng nhập ứng dụng trên điện thoại, vui lòng gửi thông tin đăng nhập cho khách hàng.');
            $(".small-chat-box").removeClass("active");
        }

        var folderAPI = "https://api.immgroup.com/crm/check/access/" + _cusid + "/" + _token + "/" + _id + "/";
        $.getJSON(folderAPI, {
            format: "json"
        }).done(function (data) {
            //return data
            var stringified = JSON.stringify(data);
            var parsedObj = JSON.parse(stringified);
            //Biding Parent menu
            var status = parsedObj[0];
            var erorrstr = "";
            var viewflag = "";
            if (status.CusRedelete == "T" && status.CusRedeleteAccessFlag == "F") {
                erorrstr += "- Khách này đã bị đề xuất xóa không thể xem thông tin \r\n";
            }
            if (status.CusInlistFollow == "F" && status.CusInlistFollowAccessFlag == "F") {
                if (status.CusInlistFollowViewFlag == "T") {    
                    viewflag = "T";
                    swal("Thông báo", "Bạn được xem hồ sơ và không thể thao tác do không phụ trách khách này.", "info");
                } else {
                    erorrstr += "- Bạn chỉ xem được những hồ sơ khách hàng có tên bạn tại danh sách nhân viên phụ trách \r\n";
                }               
            }
            if (status.CusReback == "T" && status.CusRebackAccessFlag == "F") {
                erorrstr += "- Team bạn đã trả lại SL này \r\n";
            }
            if (status.CusNotFollow == "T" && status.CusNotFollowAccessFlag == "F") {
                erorrstr += "- Đã 1 tháng hoặc lâu hơn bạn đã không tương tác với khách hàng " + _cusname + " vì vậy bạn đã bị khóa đối với khách này \r\n";
            }
            if (erorrstr != "") {
                erorrstr = "Bạn không thể truy cập hồ sơ này vì nguyên nhân sau: \r\n" + erorrstr;
                $(".frmcustomer,.customer-interactive-history").empty();
                swal("Thông báo", erorrstr, "warning");
            } else {
                if (viewflag !== "T") {
                    $(".not-use-this").removeClass("CusInlistFollowViewFlag");
                }
            }
        });
    }
}


function toggclass(item, clas) {
    if (item !== "") { 
        if (clas === "") {
            $("." + item).toggleClass("d-none");
            $("#" + item).toggleClass("d-none");
        } else {
            $("." + item).toggleClass(clas);
            $("#" + item).toggleClass(clas);
        }
        
    }
}

/*Library for file ultimate log*/
function fileManagerLoading(sender, e) {
    var fileManager = sender;

    logEvent(e);
}

function fileManagerLoaded(sender, e) {
    var fileManager = sender;

    logEvent(e);
}


function fileManagerChosen(sender, e) {
    var fileManager = sender;

    logEvent(e);
}

function fileManagerFolderChanged(sender, e) {
    var fileManager = sender;

    logEvent(e);
}

function fileManagerSelectionChanged(sender, e) {
    var fileManager = sender;

    logEvent(e);
}


function fileManagerCreating(sender, e) {
    var fileManager = sender;

    logEvent(e);
}

function fileManagerCreated(sender, e) {
    var fileManager = sender;

    logEvent(e);
}


function fileManagerDeleting(sender, e) {
    var fileManager = sender;

    logEvent(e);
}

function fileManagerDeleted(sender, e) {
    var fileManager = sender;

    logEvent(e);
}


function fileManagerRenaming(sender, e) {
    var fileManager = sender;

    logEvent(e);
}


function fileManagerRenamed(sender, e) {
    var fileManager = sender;

    logEvent(e);
}


function fileManagerCopying(sender, e) {
    var fileManager = sender;

    logEvent(e);
}

function fileManagerCopied(sender, e) {
    var fileManager = sender;

    logEvent(e);
}


function fileManagerMoving(sender, e) {
    var fileManager = sender;

    logEvent(e);
}

function fileManagerMoved(sender, e) {
    var fileManager = sender;

    logEvent(e);
}


function fileManagerCompressing(sender, e) {
    var fileManager = sender;

    logEvent(e);
}

function fileManagerCompressed(sender, e) {
    var fileManager = sender;

    logEvent(e);
}


function fileManagerExtracting(sender, e) {
    var fileManager = sender;

    logEvent(e);
}

function fileManagerExtracted(sender, e) {
    var fileManager = sender;

    logEvent(e);
}


function fileManagerUploading(sender, e) {
    var fileManager = sender;

    logEvent(e);
}

function fileManagerUploaded(sender, e) {
    var fileManager = sender;

    logEvent(e);
}


function fileManagerDownloading(sender, e) {
    var fileManager = sender;

    logEvent(e);
}

function fileManagerPreviewing(sender, e) {
    var fileManager = sender;

    logEvent(e);
}

function sampleCancelEventHandler(sender, e) {
    //Optionally displaying a message to the user when canceling
    e.cancelMessage = e.eventName + " event is canceled!";

    //Canceling a before event (stops the corresponding action):
    return false;
}

function clearLog() {
    var logTextBox = document.getElementById("LogTextBox");

    logTextBox.value = "";
}

function logEvent(e) {
    var now = new Date().toLocaleTimeString();
    var filenames = "";
    var folder = "";
    var _noti = "";
    switch (e.eventName) {
        case "created":
            _noti = "đã tạo thư mục " + e.itemName + " tại " + e.targetFolder.fullPath + " lúc " + now;
            break;
        case "uploaded":
            for (var i in e.items) {
                filenames += e.items[i].name + ";";
            }
            _noti = "đã upload " + filenames + " lên thư mục " + e.targetFolder.fullPath + " lúc " + now;
            folder = e.targetFolder.fullPath.replace(e.items[i].name, "");
            folder = folder.replace(/\\/g, "#");
            break;
        case "moved":
            for (var i in e.items) {
                filenames += e.items[i].name + ";";
            }
            _noti = "đã chuyển " + filenames + " từ " + e.items.fullPath + " đến " + e.targetFolder.fullPath + " lúc " + now;
            folder = e.targetFolder.fullPath.replace(e.items[i].name, "");
            folder = folder.replace(/\\/g, "#");
            break;
        case "deleted":
            for (var i in e.items) {
                filenames += e.items[i].name + ";";
                folder = e.items[i].fullPath.replace(e.items[i].name, "");
                folder = folder.replace(/\\/g, "#");
            }
            _noti = "đã xóa " + filenames + " khỏi thư mục " + folder + " lúc " + now;
            break;
        case "renamed":
            _noti = "đã đổi tên " + e.item.fullPath + " thành " + e.itemNewName + " lúc " + now;
            folder = e.item.fullPath.replace(e.item.name, "");
            folder = folder.replace(/\\/g, "#");
            break;
        case "downloading":
            for (var i in e.items) {
                filenames += e.items[i].name + ";";
                folder = e.items[i].fullPath.replace(e.items[i].name, "");
                folder = folder.replace(/\\/g, "#");
            }
            _noti = "đã tải xuống " + filenames + " từ thư mục " + folder + " lúc " + now;
            break;
    }  
    var arr = folder.split("#");    
    fileultimateNoti(_noti, arr[1]);
}

function fileultimateNoti(_noti, _folder) {
    var form = new FormData();
    var _cusid = $("#cusId").text();
    var _mode = $("#fileUltimate").text();    
    form.append("_noti", _noti);
    form.append("_mode", _mode);
    form.append("_cusid", _cusid);
    form.append("_folder", _folder);

    //AJAX REQUEST
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/home/fileultimateNoti", true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
        }
    };
    xhr.send(form);
}

// Enable/disable fixed top navbar
$('#fixednavbar').click(function () {
    if ($('#fixednavbar').is(':checked')) {
        $(".navbar-static-top").removeClass('navbar-static-top').addClass('navbar-fixed-top');
        $("body").removeClass('boxed-layout');
        $("body").addClass('fixed-nav');
        $('#boxedlayout').prop('checked', false);

        if (localStorageSupport) {
            localStorage.setItem("boxedlayout", 'off');
        }

        if (localStorageSupport) {
            localStorage.setItem("fixednavbar", 'on');
        }
    } else {
        $(".navbar-fixed-top").removeClass('navbar-fixed-top').addClass('navbar-static-top');
        $("body").removeClass('fixed-nav');
        $("body").removeClass('fixed-nav-basic');
        $('#fixednavbar2').prop('checked', false);

        if (localStorageSupport) {
            localStorage.setItem("fixednavbar", 'off');
        }

        if (localStorageSupport) {
            localStorage.setItem("fixednavbar2", 'off');
        }
    }
});

// Enable/disable fixed top navbar
$('#fixednavbar2').click(function () {
    if ($('#fixednavbar2').is(':checked')) {
        $(".navbar-static-top").removeClass('navbar-static-top').addClass('navbar-fixed-top');
        $("body").removeClass('boxed-layout');
        $("body").addClass('fixed-nav').addClass('fixed-nav-basic');
        $('#boxedlayout').prop('checked', false);

        if (localStorageSupport) {
            localStorage.setItem("boxedlayout", 'off');
        }

        if (localStorageSupport) {
            localStorage.setItem("fixednavbar2", 'on');
        }
    } else {
        $(".navbar-fixed-top").removeClass('navbar-fixed-top').addClass('navbar-static-top');
        $("body").removeClass('fixed-nav').removeClass('fixed-nav-basic');
        $('#fixednavbar').prop('checked', false);

        if (localStorageSupport) {
            localStorage.setItem("fixednavbar2", 'off');
        }
        if (localStorageSupport) {
            localStorage.setItem("fixednavbar", 'off');
        }
    }
});

// Enable/disable fixed sidebar
$('#fixedsidebar').click(function () {
    if ($('#fixedsidebar').is(':checked')) {
        $("body").addClass('fixed-sidebar');
        $('.sidebar-collapse').slimScroll({
            height: '100%',
            railOpacity: 0.9
        });

        if (localStorageSupport) {
            localStorage.setItem("fixedsidebar", 'on');
        }
    } else {
        $('.sidebar-collapse').slimScroll({ destroy: true });
        $('.sidebar-collapse').attr('style', '');
        $("body").removeClass('fixed-sidebar');

        if (localStorageSupport) {
            localStorage.setItem("fixedsidebar", 'off');
        }
    }
});

// Enable/disable collapse menu
$('#collapsemenu').click(function () {
    if ($('#collapsemenu').is(':checked')) {
        $("body").addClass('mini-navbar');
        SmoothlyMenu();

        if (localStorageSupport) {
            localStorage.setItem("collapse_menu", 'on');
        }

    } else {
        $("body").removeClass('mini-navbar');
        SmoothlyMenu();

        if (localStorageSupport) {
            localStorage.setItem("collapse_menu", 'off');
        }
    }
});

// Enable/disable boxed layout
$('#boxedlayout').click(function () {
    if ($('#boxedlayout').is(':checked')) {
        $("body").addClass('boxed-layout');
        $('#fixednavbar').prop('checked', false);
        $('#fixednavbar2').prop('checked', false);
        $(".navbar-fixed-top").removeClass('navbar-fixed-top').addClass('navbar-static-top');
        $("body").removeClass('fixed-nav');
        $("body").removeClass('fixed-nav-basic');
        $(".footer").removeClass('fixed');
        $('#fixedfooter').prop('checked', false);

        if (localStorageSupport) {
            localStorage.setItem("fixednavbar", 'off');
        }

        if (localStorageSupport) {
            localStorage.setItem("fixednavbar2", 'off');
        }

        if (localStorageSupport) {
            localStorage.setItem("fixedfooter", 'off');
        }


        if (localStorageSupport) {
            localStorage.setItem("boxedlayout", 'on');
        }
    } else {
        $("body").removeClass('boxed-layout');

        if (localStorageSupport) {
            localStorage.setItem("boxedlayout", 'off');
        }
    }
});

// Enable/disable fixed footer
$('#fixedfooter').click(function () {
    if ($('#fixedfooter').is(':checked')) {
        $('#boxedlayout').prop('checked', false);
        $("body").removeClass('boxed-layout');
        $(".footer").addClass('fixed');

        if (localStorageSupport) {
            localStorage.setItem("boxedlayout", 'off');
        }

        if (localStorageSupport) {
            localStorage.setItem("fixedfooter", 'on');
        }
    } else {
        $(".footer").removeClass('fixed');

        if (localStorageSupport) {
            localStorage.setItem("fixedfooter", 'off');
        }
    }
});

// SKIN Select
$('.spin-icon').click(function () {
    $(".theme-config-box").toggleClass("show");
});

// Default skin
$('.s-skin-0').click(function () {
    $("body").removeClass("skin-1");
    $("body").removeClass("skin-2");
    $("body").removeClass("skin-3");
});

// Blue skin
$('.s-skin-1').click(function () {
    $("body").removeClass("skin-2");
    $("body").removeClass("skin-3");
    $("body").addClass("skin-1");
});

// Inspinia ultra skin
$('.s-skin-2').click(function () {
    $("body").removeClass("skin-1");
    $("body").removeClass("skin-3");
    $("body").addClass("skin-2");
});

// Yellow skin
$('.s-skin-3').click(function () {
    $("body").removeClass("skin-1");
    $("body").removeClass("skin-2");
    $("body").addClass("skin-3");
});

if (localStorageSupport) {
    var collapse = localStorage.getItem("collapse_menu");
    var fixedsidebar = localStorage.getItem("fixedsidebar");
    var fixednavbar = localStorage.getItem("fixednavbar");
    var fixednavbar2 = localStorage.getItem("fixednavbar2");
    var boxedlayout = localStorage.getItem("boxedlayout");
    var fixedfooter = localStorage.getItem("fixedfooter");

    if (collapse == 'on') {
        $('#collapsemenu').prop('checked', 'checked')
    }
    if (fixedsidebar == 'on') {
        $('#fixedsidebar').prop('checked', 'checked')
    }
    if (fixednavbar == 'on') {
        $('#fixednavbar').prop('checked', 'checked')
    }
    if (fixednavbar2 == 'on') {
        $('#fixednavbar2').prop('checked', 'checked')
    }
    if (boxedlayout == 'on') {
        $('#boxedlayout').prop('checked', 'checked')
    }
    if (fixedfooter == 'on') {
        $('#fixedfooter').prop('checked', 'checked')
    }
}

$('.modifybtn-c').click(function () {
    //$(this).parent().children(".d-none").addClass("escape");
    $(this).parent().children().toggleClass("d-none");    
});

