(function () {
    "use strict";
    angular.module("app-trips")
    .controller("tripsController", tripsController);
    function tripsController() {
        var vm = this;
        vm.name = "UserName";
        vm.Trips = [
            {
                TripName: "Ankara",
                TripDuration: "5 hours",
                Date: new Date()
            },
            {
                TripName: "Istanbul",
                TripDuration: "12 hours",
                Date: new Date(2016, 5)
            }
        ];
        vm.newTrip = {
            //name: ""
        };

        vm.addTrip=function()
        {
            vm.infoClass = ""; //Can't refresh DOM before giving an alert
            alert(vm.newTrip.name);
        };
        vm.infoClass = "collapse";
    }
})();