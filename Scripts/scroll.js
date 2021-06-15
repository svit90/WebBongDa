$(window).scroll(function () {
    if ($(this).scrollTop() > 60) {

        var leftscreem = $('.sidebar-collapse').width();
        var rightscreem = $('#page-wrapper').width()+30;
       // this.alert(leftscreem);
        $('.nav-srcoll').addClass("fixed-top-one");
        $('.nav-srcoll').css({ "left": leftscreem, "width": rightscreem});
        // add padding top to show content behind navbar
        $('body').css('padding-top', $('.navbar').outerHeight() + 'px');
    } else {
        $('.nav-srcoll').removeClass("fixed-top-one");
        $('.nav-srcoll').css({ "left": "initial", "width": "100%" });
        // remove padding top from body
        $('body').css('padding-top', '0');
    }
});