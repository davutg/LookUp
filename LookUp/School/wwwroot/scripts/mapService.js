//require(['gmapsLib'], function (mi) {
define(['async!http://maps.google.com/maps/api/js?key=AIzaSyAajnpD2EEBvAyjeFpfdIWKwMHrtH0fgCY!callback'],
    function (_callback) {
        callback();
});

//});
function callback()
{
    //var GMaps = this;
    //window.GMaps = callback;
    require(['gmapsLib'], function (googlemaps) {
        window.GMaps = googlemaps;
        require(['travelMap'], function (tm) {
            if (typeof (onMapServiceInstalled) !== 'undefined')
                callFn(onMapServiceInstalled);
        });
    });
}