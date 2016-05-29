(function()
{
    var resolveController = function (dep)
    {
        console.info(dep);
        requirejs([dep], function (d)
        {
            return d;
        });
    }

    "use strict";    
    angular.module("app", ["simpleControls", "ngRoute"])
    .config(function ($routeProvider, $locationProvider) {
            //$locationProvider.html5Mode({
            //    enabled: true,
            //    requireBase: false
            //});

        $routeProvider.when("/",
            {                
                controller: "tripsController",
                controllerAs: "vm",
                templateUrl: "/views/tripsView.html",
                //http://stackoverflow.com/a/28195942/413032 resolve:resolveController('tripsController')
            }).when("/editor/:tripId?",
            {
                controller: "tripEditorController",
                controllerAs: "vm",
                templateUrl: "/views/tripEditorView.html"
            }).when("/test/:tripId?",
            {
                controller: "tripEditorController",
                controllerAs: "vm",
                templateUrl:"/views/MOCKTest.html"
            });
        $routeProvider.otherwise({ redirecTo: "/" });
    });
    
})();

///editor/:tripId? Question mark makes parameter optionan otherwise blank page!