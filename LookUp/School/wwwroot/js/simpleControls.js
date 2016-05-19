(function () {
    "use strict";
    var module=angular.module("simpleControls", [])
    .directive("dcWait", waitControl);

    function waitControl() {
        return {
            scope: {
                show: "=displayWhen"
            },
            restrict: "E",
            templateUrl: "/view/dcWaitTemplate.html"
        };
    }    
    module.controller("dcDateController", dcDateController)
    function dcDateController($scope) {        
        var vm = this;
        var isNotifyingDisabled = false;
        $scope.$watch('modelx', function (newValue) {
            if (!isNotifyingDisabled) {
                vm.tripDateInput = new Date(newValue);    //$filter('date')(newValue, 'dd.MM.yyyy');
            }
        });
        $scope.$watch('vm.tripDateInput', function (newValue) {
            isNotifyingDisabled = true;
            $scope.modelx = newValue.toJSON();
            isNotifyingDisabled = false;
        });
    }

    module.directive("dcDate", dateControl);
    function dateControl() {
        return {
            controller:"dcDateController as vm",
            scope: {
                modelx: "=modelx",
                identifier: "=namex",
                pattern: "=ptrn"
            },
            restrict: "E",
            templateUrl: "/view/dcDateTemplate.html"
        };
    }
})();