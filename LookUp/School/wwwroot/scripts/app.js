requirejs.config({
    baseUrl: "/",
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
        tripsController:'scripts/js/tripsController',
        tripsEditorController: 'scripts/js/tripEditorController',
        maskedInput: 'scripts/js/jquery.maskedinput.min',
        moment: 'scripts/lib/moment/min/moment-with-locales.min',
        underscore: 'scripts/lib/underscore/underscore-min',
        gmapsx: 'scripts/lib/gmaps/gmaps.min',
        gmapsUse: 'https://maps.googleapis.com/maps/api/js?key=AIzaSyAajnpD2EEBvAyjeFpfdIWKwMHrtH0fgCY',
        travelMap: 'scripts/lib/travelmap/travelmap.min'
    }
});
function callFn(fnc)
{
    if(fnc)
    fnc();
}

requirejs(['jQuery'], function ($) {    
    requirejs(['site', 'bootstrap'], function (site, boot) {
        if (typeof (onSiteStart)!=='undefined')
        callFn(onSiteStart)               
    });
});