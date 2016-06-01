requirejs.config({
    baseUrl: "/",
    waitSeconds:0,
    paths: {
        scripts: '../scripts',
        jQuery: 'scripts/lib/jquery/dist/jquery',
        jQueryValidation: 'scripts/lib/jquery-validation/dist/jquery.validate.min',
        jQueryUnobtrunsive: 'scripts/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min',
        site: 'scripts/js/site',
        angularMin:'scripts/lib/angular/angular.min',
        angularRoute:'scripts/lib/angular-route/angular-route.min',
        simpleControls:'scripts/js/simpleControls',
        appTrips: 'scripts/js/app',
        templateController:'scripts/js/templateController',
        bootstrap: 'scripts/lib/bootstrap/dist/js/bootstrap.min',
        angularComponents: "scripts/angularComponents",
        essentials: "scripts/essentials",
        mapService:"scripts/mapService",
        tripsController:'scripts/js/tripsController',
        tripsEditorController: 'scripts/js/tripEditorController',
        maskedInput: 'scripts/js/jquery.maskedinput.min',
        moment: ['https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.0.0/moment.min', 'scripts/lib/moment/min/moment.min'],
        underscore: 'scripts/lib/underscore/underscore-min',
        //gmapsLib: 'scripts/lib/gmaps/gmaps.min',
        "googlemaps!": "scripts/googlemapsapi",
        googlemaps: "scripts/googlemapsapi",
        gmapsLib: ['/scripts/lib/gmaps/gmaps'],
        gmapsUse: 'https://maps.googleapis.com/maps/api/js?key=AIzaSyAajnpD2EEBvAyjeFpfdIWKwMHrtH0fgCY',
        travelMap: 'scripts/lib/travelmap/travelmap.min',
        'async': 'scripts/lib/requirejs-plugins/src/async',
        async: 'scripts/lib/requirejs-plugins/src/async',
        goog: 'scripts/lib/requirejs-plugins/src/goog',
        propertyParser: 'scripts/lib/requirejs-plugins/src/propertyParser'
    },
    shim: {
        gmaps: {
            deps: ["googlemaps"],
            exports: "GMaps"
        }
    },
    config: {
        moment: {
            noGlobal: true
        }
    }
});
function callFn(fnc)
{
    if(fnc)
    fnc();
}

requirejs(['jQuery', 'async'], function ($,asenkron) {
    requirejs(['site', 'bootstrap'], function (site, boot) {
        if (typeof (onSiteStart)!=='undefined')
        callFn(onSiteStart)               
    });
});

