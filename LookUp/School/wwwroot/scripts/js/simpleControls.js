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
        $(".dcDateControl").mask("99/99/9999", { placeholder: "dd/mm/yyyy" });        

        $scope.$watch('modelx', function (newValue) {
            if (newValue) {
                if (!isNotifyingDisabled) {
                    var d = new Date(newValue)
                    var formatted = moment(newValue).format("DD/MM/YYYY");
                    vm.tripDateInput = formatted;    //$filter('date')(newValue, 'dd.MM.yyyy');
                }
            }
        });
        $scope.$watch('vm.tripDateInput', function (newValue) {
            if (newValue) {
                var d = new moment.utc(newValue, 'DD/MM/YYYY');                
                isNotifyingDisabled = true;
                $scope.modelx = d.toDate().toJSON();
                isNotifyingDisabled = false;
            }
        });
    }

    module.directive("dcDate", dateControl);
    function dateControl() {
        return {
            controller:"dcDateController as vm",
            scope: {
                modelx: "=modelx",
                namex: "=namex",
                idx:"=idx",
                ptrn: "=ptrn"
            },
            restrict: "E",
            templateUrl: "/view/dcDateTemplate.html"
        };
    }
})();