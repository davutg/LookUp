﻿/*Avoid of naming collusion , anonym method works outside of global scope*/

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
        element.html(element.html().replace(/\n/g, '<div/>')); //.html('some multiline\ntext').wrap.("<pre />");

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
    if (main != null) {
        main.on("mouseenter", function () {
            //main.style="color:red;"; ////doesn't work !!!
            main.css('background-color','#888');
        });
        main.on("mouseleave", function () {
            main.css('background-color', '');
        });
    }
    else {
        alert(nullMessage);
    }

    var menuItems = $("ul.menu li a");
    menuItems.on("click", function () {
        var me = $(this);
        alert(me.text());
    });

})("element is null"));


$.fn.multiline = function (txt) {
    this.text(txt);
    this.html(this.html().replace(/\n/g, '<br/>'));
    return this;
}