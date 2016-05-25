require(['angularMin'], function (angu) {
    require(['angularRoute','simpleControls'], function (ro, si) {
            console.log('simpleControls,angularRoute');
            require(['appTrips'], function (app) {
                console.log('appTrips');
                require(['templateController'], function (template) {
                    console.log('templateController');
                });

            });
        })
    } 
);
