(
function()
{
    "use strict";
    angular.module("app-trips")
        .controller("tripEditorController", tripEditorController);
    
    function tripEditorController($http, $routeParams, $scope, $filter, $location) {
        var vm = this;
        vm.name = "Trip Editor";
        vm.Trip = {};
/*
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
*/        
        function getTimeStamp()
        {
            return encodeURI(new Date().toString());
        }
   
        vm.tripId = $routeParams.tripId;
        $http.get("/api/Trip/" + vm.tripId + "?" + getTimeStamp()).then(succeeded);

        function succeeded(response) {
            vm.Trip = response.data;
            _showMap(vm.Trip.destinations)
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
    
    function _compare(a,b) {
        if (a.long < b.long)
            return -1;
        else if (a.long > b.long)
            return 1;
        else 
            return 0;
    }

    function _showMap(stops) {
        var mapStops = _.map(stops, function (item) {
            return {
                lat: item.latitude,
                long: item.longitude,
                info:item.name
            }
        }).sort(_compare);

        if (stops && stops.length > 0)
        {
            var map=travelMap.createMap({
                stops: mapStops,
                selector: "#map",
                currentStop: 0,
                initialZoom: 3
            });
            //map.map.zoom = 3;
            map.map.fitZoom();
        }
    }
   
}
)();