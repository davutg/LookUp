﻿define('googlemaps', ['async!http://maps.google.com/maps/api/js?key=AIzaSyAajnpD2EEBvAyjeFpfdIWKwMHrtH0fgCY'],
    function (GMaps) {
        return window.google.maps;
    });