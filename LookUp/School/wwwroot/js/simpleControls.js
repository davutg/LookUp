(function () {
    "use strict";
    angular.module("simpleControls", [])
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
})();