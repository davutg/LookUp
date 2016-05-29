require(['angularMin'], function (angu) {
    require(['angularRoute', 'simpleControls'], function (ro, sc) {
        require(['appTrips'], function (app) {
            if (typeof (onAppInstalled) !== 'undefined')
            callFn(onAppInstalled);
        });
    })
});