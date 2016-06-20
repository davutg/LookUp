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
        vm.tripDateInput = {};
        var isNotifyingDisabled = false;
        $(".dcDateControl").mask("99/99/9999", { placeholder: "dd/mm/yyyy" });        

        $scope.$watch('modelx', function (newValue) {
            if (newValue) {
                if (!isNotifyingDisabled) {
                    var d = new Date(newValue)
                    var formatted = moment(newValue).format("DD/MM/YYYY");
                    vm.tripDateInput = formatted;    //$filter('date')(newValue, 'dd.MM.yyyy');
                }
            } else {
                vm.tripDateInput = newValue;
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

        vm.checkValidity = function () {
            var d = new moment.utc(vm.tripDateInput, 'DD/MM/YYYY');
            if (d.isValid() == true) {
                var d = new Date(vm.tripDateInput)
                var formatted = moment(vm.tripDateInput).format("DD/MM/YYYY");
                vm.tripDateInput = formatted;
            } else {

            }
        }
    }

    module.directive("dcDate", dateControl);
    function dateControl() {
        return {
            controller:"dcDateController as vm",
            scope: {
                modelx: "=modelx",
//                namex: "=namex",
//                idx:"=idName",
                ptrn: "=ptrn"
            },
            restrict: "E",
            replace: true,
            templateUrl: "/view/dcDateTemplate.html"
        };
    }

    //Update on enter directive Attiribute A update-on-enter
   module.directive('updateOnEnter', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ctrl) {
                element.on("keyup", function (ev) {
                    if (ev.keyCode == 13) {
                        ctrl.$validate();
                        scope.$apply(ctrl.$setTouched);
                    }
                });
            }
        }
   });

    //Update on keyup directive Attiribute A update-on-keyup
   module.directive('updateOnKeyup', function () {
       return {
           restrict: 'A',
           require: 'ngModel',
           link: function (scope, element, attrs, ctrl) {
               element.on("blur keyup change", function (ev) {
                   if (!ctrl.$viewValue)
                       return;
                   var m = moment(ctrl.$viewValue, 'DD.MM.YYYY');
                   if (m) {
                       var isValid = m.isValid();
                       console.info(ctrl.$viewValue + " " + isValid);
                       ctrl.$setValidity("dcDate", isValid);
                       ctrl.$validate();
                       scope.$apply(ctrl.$setTouched);
                       scope.$apply(function () {
                           scope.$eval(attrs.updateOnKeyup);
                       });
                   }
               });
           }
       }
   });
})();