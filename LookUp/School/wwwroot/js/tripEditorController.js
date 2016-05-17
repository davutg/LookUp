(
function()
{
    "use strict";
    angular.module("app-trips")
        .controller("tripEditorController", tripEditorController);
    
    function tripEditorController($http, $routeParams, $scope, $filter, $location) {
        var vm = this;
        vm.Trip = {};

        var isNotifyingDisabled = false;
        $scope.$watch('vm.Trip.created', function (newValue) {
            if (!isNotifyingDisabled) {
                vm.tripDateInput = new Date(newValue);    //$filter('date')(newValue, 'dd.MM.yyyy');
            }
        });
        
        $scope.$watch('vm.tripDateInput', function (newValue) {
            isNotifyingDisabled = true;
            vm.Trip.created = newValue.toJSON();
            isNotifyingDisabled = false;
        });
        
        function getTimeStamp()
        {
            return encodeURI(new Date().toString());
        }
   
        vm.tripId = $routeParams.tripId;
        $http.get("/api/Trip/" + vm.tripId + "?" + getTimeStamp()).then(succeeded);

        function succeeded(response) {
            vm.Trip=response.data;
        }
        vm.updateTrip = function () {
            $http.put("/api/Trip/"+vm.Trip.id, vm.Trip).then(postSucceeded);
        }

        function postSucceeded(response)
        {
            vm.Trip = response.data;
            $location.path("/");
        }
    }
    
   
}
)();