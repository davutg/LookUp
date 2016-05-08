(function () {
    "use strict";
    angular.module("app-trips")
    .controller("tripsController", tripsController);
    function tripsController($http, $scope) {
        var vm = this;
        vm.name = "UserName";
        vm.loadingError = "";
        vm.isBusy = true;
        vm.userName="";
        vm.Trips = [
            {
                name: "Ankara",
                TripDuration: "5 hours",
                created: new Date()
            },
            {
                name: "Istanbul",
                TripDuration: "12 hours",
                created: new Date(2016, 5)
            }
        ];
        vm.newTrip = {
            //name: ""
        };
        $http.get("/api/Trip")
        .then(function (response)
        {
            vm.Trips=vm.Trips.concat(response.data);
        },
        function (error)
        {
            vm.loadingError = error;
        }).finally()
        {            
            vm.isBusy = false;
        };

        vm.addTrip=function()
        {
            vm.isBusy = true;
            vm.newTrip.UserName = vm.userName;
            $http.post("/api/trip", vm.newTrip)
            .then(
            function (response){
                vm.Trips.push(response.data);
                vm.newTrip = {};
            },
            function (error) {

            }).finally()
            {
                vm.isBusy = false;
            };

            
            vm.infoClass = ""; 
 /*          vm.newTrip = {
                name: vm.newTrip.name,
                created: new Date(1453, 5, 8),
                TripDuration:'-'
            };
         
*/
        };
        vm.infoClass = "collapse";
    }
})();


function wait(ms) {
    var start = new Date().getTime();
    var end = start;
    while (end < start + ms) {
        end = new Date().getTime();
    }
}