var app = angular.module('myApp', ['ngGrid']);
app.controller('MyCtrl', function($scope) {
    $scope.myData = [{test: "WBC", result: 100.1 ,unit:'#'},
                     {test: "RBC", result: 65,unit:'#'},
                     {test: "HGB", result: 70,unit:'#'},
                     {test: "Na+", result: 4.521,unit:'ml/dl'},
                     {test: "Cl-", result: 3.4,unit:'%'}];
    $scope.gridOptions = { 
        data: 'myData',
        enableCellSelection: false,
        enableRowSelection: true,
        enableCellEdit: true,
        columnDefs: [{field: 'test', displayName: 'Test', enableCellEdit: false}, 
                     {field:'result', displayName:'Result', enableCellEdit: true},
					 {field:'unit', displayName:'Unit', enableCellEdit: true},					 
					 ]
    };
});