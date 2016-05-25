(function () {
    "use strict";
    angular.module("app")
    .controller("tripsController", tripsController);
    function tripsController($http, $scope, $routeParams) {

        $scope.$on('$routeChangeSuccess', function () {
            console.info('routePrms:' + JSON.stringify($routeParams));
            // $routeParams will be populated here if
            // this controller is used outside ng-view
        });

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

        //GET Trips http://stackoverflow.com/a/16098904/413032
        $http(
            {
                url: "/api/Trip",
                params: { foo: new Date().getTime().toString() }
            })
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

        //DELETE
        vm.deleteTrip = function (tripID) {
            vm.isBusy = true;
            $http.delete("/api/trip/" + tripID)
            .then(function (response) {
                var element = $.grep(vm.Trips, function (x) {
                    return x.id == tripID;
                });
                var index = vm.Trips.indexOf(element[0]);
                vm.Trips.splice(index, 1);
                console.info("deleting...:"+element);
                //vm.Trips.splice()
            },function(error){

            }).finally()
            {
                vm.isBusy=false;
            };
        };

        //ADD
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