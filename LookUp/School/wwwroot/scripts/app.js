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
        angularComponents: "scripts/angularComponents"
    }
});

requirejs(['jQuery'], function ($) {
    console.info("jquery");
    require(['angularMin'], function (angu) {
        require(['angularRoute', 'simpleControls'], function (ro, si) {
            console.log('simpleControls,angularRoute');
            require(['appTrips'], function (app) {
                console.log('appTrips');
                require(['templateController'], function (template) {
                    var tagMainApp = jQuery("#app").first().get();
                    angular.bootstrap(tagMainApp, ['app']);
                });

            });
        })
    }
);
 
    requirejs(['site', 'bootstrap'], function (site, boot) {
        console.info("site,bootstrap");

    });
});
