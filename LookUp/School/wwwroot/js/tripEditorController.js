(
function()
{
    "use strict";
    angular.module("app-trips")
        .controller("tripEditorController", tripEditorController);
    
    function tripEditorController($http, $routeParams) {
        var vm = this;
        vm.Trip = {};
        vm.tripId = $routeParams.tripId;
        $http.get("api/" + vm.tripId).then(succeeded);

        function succeeded(response) {
            vm.Trip=response.data;
        }

    }
    
   
}
)();