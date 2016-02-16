
var element = document.getElementById("userName");
if (element != null) {
    element.innerHTML = "Welcome <br>" + element.innerHTML;
    element.innerHTML += " !";
}

element.onmouseover =function()
    {
        element.style["color"] = "red";
}

element.onmouseleave = function () {
    element.style["color"] = "";
}