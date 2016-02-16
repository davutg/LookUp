/*Avoid of naming collusion , anonym method works outside of global scope*/
(function (nullMessage) {
    var element = document.getElementById("userName");
    if (element != null) {
        element.innerHTML = "Welcome <br>" + element.innerHTML;
        element.innerHTML += " !";

        element.onmouseover = function () {
            element.style["color"] = "red";
        }

        element.onmouseleave = function () {
            element.style["color"] = "";
        }
    } else {
        alert(nullMessage);
    }
})("element is null")