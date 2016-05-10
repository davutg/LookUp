/*Avoid of naming collusion , anonym method works outside of global scope*/


$.fn.multiline = function (txt) {
    if (this.html() == undefined)
        return this;
    this.html(this.html().replace(/\n/g, '<br/>'));
    return this;
}

$(document).ready(
(function (nullMessage) {
    /* Without JQuery=$
    var elementX = document.getElementById("userName");
    elementX.innerHTML = "Welcome <br>" + element.innerHTML;
    elementX.innerHTML += " !";
    elementX.onmouseover = function () {
        element.style["color"] = "red";
    }

    elementX = function () {
        element.style["color"] = "";
    }
    */
    var element = $("#userName");
    if (element != null) {
        element.text("Welcome \n" + element.text() + " !");
        element.multiline(element.text());
        //element.html(element.html().replace(/\n/g, '<div/>')); //.html('some multiline\ntext').wrap.("<pre />");

        element.on("mouseover", function () {
            element.css('color', 'red');
        });

        element.on("mouseleave", function () {
            element.css('color', '');            
        });
    } else {
        alert(nullMessage);
    }

    var main = $("#main");
    //if (main != null) {
    //    main.on("mouseenter", function () {
    //        //main.style="color:red;"; ////doesn't work !!!
    //        main.css('background-color','#888');
    //    });
    //    main.on("mouseleave", function () {
    //        main.css('background-color', '');
    //    });
    //}
    //else {
    //    alert(nullMessage);
    //}

    var menuItems = $("ul.menu li a");
    menuItems.on("click", function () {
        var me = $(this);
        console.info(me.text()+" page is navigated");
    });

    var $sidebarAndWrapper = $("#sidebar,#wrapper");

    var toggleButton = $("#toggleButton")
    var icon = $("#toggleButton i.fa")
    toggleButton.on("click", function () {

        $sidebarAndWrapper.toggleClass("toggle-sidebar");
        if ($sidebarAndWrapper.hasClass("toggle-sidebar"))
        {
            icon.removeClass("fa-angle-double-left ")
            icon.addClass("fa-angle-double-right fa-primary")
            //$(this).text("Show");
        }

        else
        {
            icon.addClass("fa-angle-double-left fa-primary")
            icon.removeClass("fa-angle-double-right fa-primary")
            //$(this).text("Hide");
        }
    });

    function supports_html5_storage() {
        try {
            return 'localStorage' in window && window['localStorage'] !== null;
        } catch (e) {
            return false;
        }
    }

    var supports_storage = supports_html5_storage();

    function set_theme(theme) {
        $('#bootstrapCss').attr('href', theme);
    }

    /* On load, set theme from local storage */
    if (supports_storage) {        
        var theme = localStorage.theme;
        if (theme) {
            set_theme(JSON.parse(theme).address);
        }
    } else {
        /* Don't annoy user with options that don't persist 
            $('#theme-dropdown').hide();
        */
    }

})("element is null"));


(function (mesaj) {
    console.info('Page refreshed!');
})('calistir');
