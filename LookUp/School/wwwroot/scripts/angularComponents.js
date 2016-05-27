require(['angularMin'], function (angu) {
    require(['angularRoute', 'simpleControls'], function (ro, sc) {
        require(['appTrips'], function (app) {
            if (typeof (onAppTripsInstalled) !== 'undefined')
            callFn(onAppTripsInstalled);
        });
    })
});