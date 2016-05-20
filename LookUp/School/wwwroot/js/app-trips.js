(function()
{
    "use strict";    
    angular.module("app-trips", ["simpleControls", "ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider.when("/",
            {
                controller: "tripsController",
                controllerAs: "vm",
                templateUrl: "/views/tripsView.html"
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