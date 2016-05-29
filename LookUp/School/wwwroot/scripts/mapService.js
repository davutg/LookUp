//require(['gmapsLib'], function (mi) {
    window.GMaps = require(['googlemaps'], function (googlemaps) {
            require(['travelMap'], function (tm) {
                if (typeof (onMapServiceInstalled) !== 'undefined')
                    callFn(onMapServiceInstalled);
            })            
    })
//});
